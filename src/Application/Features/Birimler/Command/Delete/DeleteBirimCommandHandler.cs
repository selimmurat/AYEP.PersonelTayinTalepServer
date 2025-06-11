using Application.Features.Birimler.Rules;
using Application.Interfaces;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Command.Delete
{
    public class DeleteBirimCommandHandler(
         BirimBusinessRules birimBusinessRules,
         IUnitOfWork unitOfWork) : IRequestHandler<DeleteBirimCommand, IResultBase>
    {
        private readonly BirimBusinessRules _birimBusinessRules = birimBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(DeleteBirimCommand request, CancellationToken cancellationToken)
        {
            var birim = await _birimBusinessRules.GetBirimOrThrowAsync(request.Id, cancellationToken);

            _unitOfWork.BirimRepository.Delete(birim);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Birim>.SuccessResult(birim, "Birim silindi.");
        }
    }
}
