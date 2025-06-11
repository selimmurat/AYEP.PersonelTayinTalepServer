using Application.Features.Auth.Commands.Dtos;
using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories.Personeller;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginPersonelCommandHandler(
        IAuthRepository authRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        IMapper mapper) : IRequestHandler<LoginPersonelCommand, IResultBase>
    {
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IMapper _mapper = mapper;

        public async Task<IResultBase> Handle(LoginPersonelCommand request, CancellationToken cancellationToken)
        {
            // 1. Kullanıcıyı çek (şifresi ve görevlendirmeleriyle)
            var personel = await _authRepository.GetBySicilNoWithSifreAndGorevlendirmelerAsync(request.SicilNo);

            if (personel == null)
                return ResultBase.FailureResult("Personel bulunamadı.");

            var sifreEntity = personel.KullaniciSifre;
            if (sifreEntity == null)
                return ResultBase.FailureResult("Şifre bilgisi bulunamadı.");

            // 2. Şifre kontrolü
            bool passwordCorrect = _passwordHasher.VerifyPassword(request.Sifre, sifreEntity.SifreHash, sifreEntity.SifreSalt);
            if (!passwordCorrect)
                return ResultBase.FailureResult("Şifre hatalı.");

            // 3. Şifre ilk giriş flag'i kontrolü
            bool sifreDegistirZorunlu = sifreEntity.IlkGirisMi;

            // 4. Aktif görevlendirmeleri getiriyoruz.

            var aktifGorevlendirmeler = _mapper.Map<List<PersonelBirimGorevlendirmeDto>>(
                                                        personel.PersonelGorevlendirmeleri.Where(pg => pg.AktifMi));

            // 5. Token üretilir
            var token = _jwtTokenGenerator.GenerateToken(
                personel.Id,
                personel.SicilNo.sicilNo,
                personel.Ad,
                personel.Soyad,
                personel.Rol.ToString());

            // 6. Response DTO oluşturulur
            var response = _mapper.Map<LoginPersonelSuccesResponseDto>(personel);
            response.Token = token;
            response.AktifGorevlendirmeler = aktifGorevlendirmeler;
            response.SifreDegistirZorunlu = sifreDegistirZorunlu;

            // 7. Result wrapper ile dön
            return Result<LoginPersonelSuccesResponseDto>.SuccessResult(response, "Giriş başarılı.");
        }
    }
}
