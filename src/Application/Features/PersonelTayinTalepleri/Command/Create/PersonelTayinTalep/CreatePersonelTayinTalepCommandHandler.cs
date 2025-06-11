using Application.Features.PersonelTayinTalepleri.Dtos;
using Application.Features.PersonelTayinTalepleri.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Create.CreatePersonelTayinTalep
{
    public class CreatePersonelTayinTalepCommandHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper,
        PersonelTayinTalepBusinessRules personelTayinTalepBusinessRules) : IRequestHandler<CreatePersonelTayinTalepCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly PersonelTayinTalepBusinessRules _personelTayinTalepBusiness = personelTayinTalepBusinessRules;

        public async Task<IResultBase> Handle(CreatePersonelTayinTalepCommand request, CancellationToken cancellationToken)
        {
            
            // personel daha önce tayin talebi oluşturulmuş mu kontrol ediliyor,
            await _personelTayinTalepBusiness.EnsureNoActiveTayinTalepExistsAsync(request.Model.PersonelId, cancellationToken);

            // Entity mapping
            var entity = _mapper.Map<PersonelTayinTalep>(request.Model);

            _unitOfWork.PersonelTayinTalepRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<PersonelTayinTalepDto>(entity);

            return Result<PersonelTayinTalepDto>.SuccessResult(dto, "Tayin talebi başarılı şekilde oluşturuldu.");
        }
    }
}
