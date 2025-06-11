using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using Application.Features.PersonelBirimGorevlendirmeler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Delete
{
    public class DeletePersonelBirimGorevlendirmeCommandHandler(
        IMapper mapper, 
        PersonelBirimGorevlendirmeBusinessRules businessRules, 
        IUnitOfWork unitOfWork) : IRequestHandler<DeletePersonelBirimGorevlendirmeCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly PersonelBirimGorevlendirmeBusinessRules _businessRules = businessRules;
        public async Task<IResultBase> Handle(DeletePersonelBirimGorevlendirmeCommand request, CancellationToken cancellationToken)
        {
            // İş kuralları
            await _businessRules.ExistsByIdAsync(request.Id, cancellationToken);

            var entity = await _unitOfWork.PersonelBirimGorevlendirmeRepository.GetByIdAsync(request.Id, cancellationToken);

            _unitOfWork.PersonelBirimGorevlendirmeRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<PersonelBirimGorevlendirmeDto>(entity);

            return Result<PersonelBirimGorevlendirmeDto>.SuccessResult(dto, "Görevlendirme başarıyla silindi");
        }
    }
}
