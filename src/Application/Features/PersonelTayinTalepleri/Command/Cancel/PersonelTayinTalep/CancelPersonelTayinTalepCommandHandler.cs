using Application.Interfaces;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Shared.Enums;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Cancel.CanselPersonelTayinTalep
{
    public class CancelPersonelTayinTalepCommandHandler(
        IPersonelTayinTalepRepository personelTayinTalepRepository, 
        IUnitOfWork unitOfWork) : IRequestHandler<CancelPersonelTayinTalepCommand, IResultBase>
    {
        private readonly IPersonelTayinTalepRepository _personelTayinTalepRepository = personelTayinTalepRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(CancelPersonelTayinTalepCommand request, CancellationToken cancellationToken)
        {
            var talep = await _personelTayinTalepRepository.GetByIdAsync(request.Id, cancellationToken);

            if (talep == null)
                return ResultBase.FailureResult("Tayin talebi bulunamadı.");

            talep.TayinTalepDurumu = TayinTalepDurumu.KullaniciIptalEtti;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultBase.SuccessResult("Tayin talebi iptal edildi.");
        }
    }
}
