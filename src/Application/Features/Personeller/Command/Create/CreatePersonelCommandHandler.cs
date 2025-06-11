using Application.Features.Personeller.Dtos;
using Application.Features.Personeller.Rules;
using Application.Features.PersonelBirimGorevlendirmeler.Command.Create;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;
using PasswordGenerator;

namespace Application.Features.Personeller.Command.Create
{
    public class CreatePersonelCommandHandler(
        IMapper mapper,
        PersonelBusinessRules personelBusinessRules,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IMediator mediator) 
        : IRequestHandler<CreatePersonelCommand, IResultBase>
    {
        private readonly PersonelBusinessRules _personelBusinessRules = personelBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IMediator _mediator = mediator;

        public async Task<IResultBase> Handle(CreatePersonelCommand request, CancellationToken cancellationToken)
        {
            await _personelBusinessRules.EnsureSicilNoIsUniqueAsync(request.SicilNo, cancellationToken);

            // 1. Şifre oluşturuluyor
            var passwordGenerator = new Password(true, true, true, true, 10);
            string plainPassword = passwordGenerator.Next();

            string salt = string.Empty;
            string hash = _passwordHasher.HashPassword(plainPassword, out salt);

            // 2. KullaniciSifre entity'si
            var kullaniciSifre = _mapper.Map<KullaniciSifre>(request);
            kullaniciSifre.SifreSalt = salt;
            kullaniciSifre.SifreHash = hash;
            kullaniciSifre.IlkGirisMi = true;

            // 3. Personel entity'si
            var personelEntity = _mapper.Map<Personel>(request);
            personelEntity.KullaniciSifre = kullaniciSifre;

            // 4. Personel'i ekle ve kaydet (Id lazım!)
            _unitOfWork.PersonelRepository.Add(personelEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // 5. Eğer görevlendirme alanları doluysa CQRS ile handler'ı çağır
            if (request.BirimId.HasValue && request.UnvanId.HasValue && request.GorevlendirmeBaslangicTarihi.HasValue)
            {
                var gorevlendirmeCommand = new CreatePersonelBirimGorevlendirmeCommand
                {
                    PersonelId = personelEntity.Id,
                    BirimId = request.BirimId.Value,
                    UnvanId = request.UnvanId.Value,
                    BaslangicTarihi = request.GorevlendirmeBaslangicTarihi.Value,
                    GorevAciklama = request.GorevAciklama
                };
                // Not: Bu handler zaten UnitOfWork ile transaction içinde devam edecek!
                await _mediator.Send(gorevlendirmeCommand, cancellationToken);
            }

            // 6. DTO ile dönüş
            var personelDto = _mapper.Map<CreatedPersonelDto>(personelEntity);
            personelDto.PlainPassword = plainPassword;

            return Result<CreatedPersonelDto>.SuccessResult(personelDto, "Personel başarıyla oluşturuldu.");
        }
    }
}
