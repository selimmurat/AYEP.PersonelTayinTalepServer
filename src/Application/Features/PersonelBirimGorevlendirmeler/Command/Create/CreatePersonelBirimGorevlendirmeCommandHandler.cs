using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using Application.Features.PersonelBirimGorevlendirmeler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Create
{
    public class CreatePersonelBirimGorevlendirmeCommandHandler(
       IMapper mapper,
       PersonelBirimGorevlendirmeBusinessRules businessRules,
       IUnitOfWork unitOfWork
   ) : IRequestHandler<CreatePersonelBirimGorevlendirmeCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly PersonelBirimGorevlendirmeBusinessRules _businessRules = businessRules;

        public async Task<IResultBase> Handle(CreatePersonelBirimGorevlendirmeCommand request, CancellationToken cancellationToken)
        {
            // İş kuralları
            await _businessRules.ExistsActiveByPersonelBirimUnvanAsync(request.PersonelId, request.BirimId, request.UnvanId, cancellationToken);

            // Mapleme ve kayıt
            var entity = _mapper.Map<PersonelBirimGorevlendirme>(request);
            _unitOfWork.PersonelBirimGorevlendirmeRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<PersonelBirimGorevlendirmeDto>(entity);

            return Result<PersonelBirimGorevlendirmeDto>.SuccessResult(dto, "Görevlendirme başarıyla oluşturuldu");
        }
    }
}
