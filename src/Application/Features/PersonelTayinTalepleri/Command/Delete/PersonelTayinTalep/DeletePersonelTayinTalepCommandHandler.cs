using Application.Features.PersonelTayinTalepleri.Rules;
using Application.Interfaces;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Delete
{
    public class DeletePersonelTayinTalepCommandHandler(
        PersonelTayinTalepBusinessRules businessRules,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeletePersonelTayinTalepCommand, IResultBase>
    {
        private readonly PersonelTayinTalepBusinessRules _businessRules = businessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(DeletePersonelTayinTalepCommand request, CancellationToken cancellationToken)
        {
            //Talep var mı? 
            var talep = await _businessRules.GetTalepOrThrowAsync(request.Id, cancellationToken);
            if (talep.IptalEdildi)
                return ResultBase.FailureResult("Bu tayin talebi zaten iptal edilmiş.");

            // Durum kontrolü: Sadece beklemede ise iptal edilsin
            if (talep.TayinTalepDurumu != Domain.Shared.Enums.TayinTalepDurumu.Beklemede)
                return ResultBase.FailureResult("Sadece beklemede olan talepler iptal edilebilir.");

            // Soft delete
            talep.IptalEdildi = true;
            talep.IptalTarihi = DateTime.UtcNow;
            talep.IptalEdenPersonelId = request.IptalEdenPersonelId;

            _unitOfWork.PersonelTayinTalepRepository.Update(talep);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultBase.SuccessResult("Tayin talebi başarıyla iptal edildi.");
        }
    }
}
