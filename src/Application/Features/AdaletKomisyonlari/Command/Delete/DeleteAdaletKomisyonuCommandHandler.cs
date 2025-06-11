using Application.Features.AdaletKomisyonlari.Rules;
using Application.Interfaces;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Delete
{
    public class DeleteAdaletKomisyonuCommandHandler(
         IUnitOfWork unitOfWork,
         AdaletKomisyonuBusinessRules adaletKomisyonuBusinessRules)
         : IRequestHandler<DeleteAdaletKomisyonuCommand, IResultBase>
    {
        private readonly AdaletKomisyonuBusinessRules _businessRules = adaletKomisyonuBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(DeleteAdaletKomisyonuCommand request, CancellationToken cancellationToken)
        {
            // Komisyonu getir ve varsa sil, yoksa hata fırlat
            var komisyon = await _businessRules.CheckKomisyonExistsOrThrowAsync(request.Id, cancellationToken);

            _unitOfWork.AdaletKomisyonuRepository.Delete(komisyon);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<AdaletKomisyonu>.SuccessResult(komisyon, "Komisyon ve bağlı tüm adliye ve birimler silindi.");
        }
    }
}
