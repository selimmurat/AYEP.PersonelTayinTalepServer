using Application.Features.Personeller.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Command.Update
{
    public class UpdatePersonelCommandHandler
        (
        IMapper mapper,
        IUnitOfWork unitOfWork,
        PersonelBusinessRules personelBusinessRules
        ) : IRequestHandler<UpdatePersonelCommand, IResultBase>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly PersonelBusinessRules _personelBusinessRules = personelBusinessRules;

        public async Task<IResultBase> Handle(UpdatePersonelCommand request, CancellationToken cancellationToken)
        {
            var personel = await _personelBusinessRules.GetPersonelOrThrowAsync(request.id, cancellationToken);

            _mapper.Map(request, personel);
            _unitOfWork.PersonelRepository.Update(personel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Personel>.SuccessResult(personel, "Personel güncellendi.");
        }
    }
}
