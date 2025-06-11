using Application.Interfaces;
using Domain.Repositories.Personeller;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Update.PersonelTayinTalepTercih
{
    public class UpdatePersonelTayinTalepTercihCommandHandler(
        IPersonelTayinTalepRepository personelTayinTalepRepository, 
        IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonelTayinTalepTercihCommand, IResultBase>
    {
        private readonly IPersonelTayinTalepRepository _personelTayinTalepRepository = personelTayinTalepRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(UpdatePersonelTayinTalepTercihCommand request, CancellationToken cancellationToken)
        {
            // Tercihi bul
            var talep = await _personelTayinTalepRepository.GetByIdWithDetailsAsync(request.Id, cancellationToken);
            var tercih = talep?.Tercihler.FirstOrDefault(x => x.Id == request.Id);

            if (tercih == null)
                return ResultBase.FailureResult("Tercih bulunamadı.");

            tercih.AdliyeId = request.AdliyeId;
            tercih.TercihSirasi = request.TercihSirasi;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ResultBase.SuccessResult( "Tercih güncellendi.");
        }
    }
}
