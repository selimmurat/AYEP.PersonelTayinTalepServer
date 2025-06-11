using Application.Features.Adliyeler.Rules;
using Application.Interfaces;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Delete
{
    public class DeleteAdliyeCommandHandler(
        AdliyeBusinessRules adliyeBusinessRules,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteAdliyeCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly AdliyeBusinessRules _adliyeBusinessRules = adliyeBusinessRules;

        public async Task<IResultBase> Handle(DeleteAdliyeCommand request, CancellationToken cancellationToken)
        {
            var adliye = await _adliyeBusinessRules.GetAdliyeOrThrowAsync(request.Id, cancellationToken);
            _unitOfWork.AdliyeRepository.Delete(adliye);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Adliye>.SuccessResult(adliye, "Adliye ve Adliyeye bağlı tüm  birimler silinmiştir.");
        }
    }
}
