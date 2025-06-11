using Application.Interfaces;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Delete.PersonelTayinTalepTercih
{
    public class DeletePersonelTayinTalepTercihCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeletePersonelTayinTalepTercihCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(DeletePersonelTayinTalepTercihCommand request, CancellationToken cancellationToken)
        {
            // Tercih bulunuyor
            var tercih = await _unitOfWork.PersonelTayinTalepTercihRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (tercih == null)
                return ResultBase.FailureResult("Tercih bulunamadı.");

            // Soft delete işlemi
            tercih.IptalEdildi = true;
            tercih.IptalTarihi = DateTime.UtcNow;
            // Burada iptal eden personel id bilgisini isteğe bağlı olarak ekleyebilirsin

            _unitOfWork.PersonelTayinTalepTercihRepository.Update(tercih);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultBase.SuccessResult("Tercih başarıyla iptal edildi (soft delete).");
        }
    }
}
