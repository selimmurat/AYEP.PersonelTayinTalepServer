using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using Application.Features.PersonelBirimGorevlendirmeler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Update
{
    public class UpdatePersonelBirimGorevlendirmeCommandHandler(
        IMapper mapper,
        PersonelBirimGorevlendirmeBusinessRules personelBirimGorevlendirmeBusinessRules,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonelBirimGorevlendirmeCommand, IResultBase>
    {
        private readonly IMapper _mapper = mapper;
        private readonly PersonelBirimGorevlendirmeBusinessRules _personelBirimGorevlendirmeBusinessRules = personelBirimGorevlendirmeBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(UpdatePersonelBirimGorevlendirmeCommand request, CancellationToken cancellationToken)
        {
            // İş kuralları           
            await _personelBirimGorevlendirmeBusinessRules.ExistsByIdAsync(request.Id, cancellationToken);

            var entity = _mapper.Map<PersonelBirimGorevlendirme>(request);

            _unitOfWork.PersonelBirimGorevlendirmeRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var dto = _mapper.Map<PersonelBirimGorevlendirmeDto>(entity);

            return Result<PersonelBirimGorevlendirmeDto>.SuccessResult(dto, "Görevlendirme başarıyla güncellendi");

        }
    }
}
