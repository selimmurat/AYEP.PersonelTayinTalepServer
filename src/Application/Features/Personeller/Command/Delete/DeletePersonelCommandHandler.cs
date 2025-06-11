using Application.Features.Personeller.Rules;
using Application.Interfaces;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Command.Delete
{
    public class DeletePersonelCommandHandler(
        PersonelBusinessRules personelBusinessRules,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeletePersonelCommand, IResultBase>
    {
        private readonly PersonelBusinessRules _personelBusinessRules = personelBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(DeletePersonelCommand request, CancellationToken cancellationToken)
        {
            var personel = await _personelBusinessRules.GetPersonelOrThrowAsync(request.Id, cancellationToken);

            _unitOfWork.PersonelRepository.Delete(personel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Personel>.SuccessResult(personel, "Personel başarıyla silindi.");
        }
    }
}
