using Application.Features.PersonelTayinTalepleri.Rules;
using Application.Interfaces;
using Domain.Entities;
using Domain.Shared.Enums;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Update
{
    public class UpdatePersonelTayinTalepCommandHandler(
        IUnitOfWork unitOfWork,
        PersonelTayinTalepBusinessRules businessRules)
        : IRequestHandler<UpdatePersonelTayinTalepCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly PersonelTayinTalepBusinessRules _businessRules = businessRules;

        public async Task<IResultBase> Handle(UpdatePersonelTayinTalepCommand request, CancellationToken cancellationToken)
        {
            // Business rule: Talep gerçekten var mı?
            var talep = await _unitOfWork.PersonelTayinTalepRepository.GetByIdWithDetailsAsync(request.Id, cancellationToken);
            if (talep == null)
                return ResultBase.FailureResult("Tayin talebi bulunamadı.");

            if (talep.TayinTalepDurumu != TayinTalepDurumu.Beklemede)
                return ResultBase.FailureResult("Sadece beklemede olan tayin talepleri güncellenebilir.");

            // Alan güncellemeleri (AutoMapper ile veya manuel)
            talep.TalepTuru = (Domain.Shared.Enums.TayinTalepTuru)request.TalepTuru;
            talep.TalepNedeni = (Domain.Shared.Enums.TayinTalepNedeni)request.TalepNedeni;
            talep.Aciklama = request.Aciklama;

            // Gerekçeler güncellemesi
            if (request.Gerekceler != null)
            {
                talep.Gerekceler.Clear();
                foreach (var gerekce in request.Gerekceler)
                {
                    talep.Gerekceler.Add(new PersonelTayinTalepGerekce
                    {
                        Gerekce = (TayinTalepGerekce)gerekce,
                        PersonelTayinTalepId = talep.Id
                    });
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultBase.SuccessResult("Tayin talebi başarıyla güncellendi.");
        }
    }
}
