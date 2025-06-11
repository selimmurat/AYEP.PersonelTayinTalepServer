using Domain.Entities;
using Domain.Repositories.AdaletKomisyonlari;

namespace Application.Features.AdaletKomisyonlari.Rules
{
    public class AdaletKomisyonuBusinessRules(IAdaletKomisyonuRepository adaletKomisyonuRepository)
    {
        public readonly IAdaletKomisyonuRepository _adaletKomisyonuRepository = adaletKomisyonuRepository;

        public async Task ExistsByNameAsync(string komisyonAdi, int ilId, CancellationToken cancellationToken)
        {
            var exists = await _adaletKomisyonuRepository.AnyAsync(
         x => x.Ad.Equals(komisyonAdi, StringComparison.CurrentCultureIgnoreCase) && x.IlId == ilId, cancellationToken);

            if (exists)
                throw new Exception("Bir ilde aynı komisyon adında bir komisyon oluşturamazsınız");

        }
        public async Task<AdaletKomisyonu> CheckKomisyonExistsOrThrowAsync(int komisyonId, CancellationToken cancellationToken)
        {
            var entity = await _adaletKomisyonuRepository.GetByIdAsync(komisyonId, cancellationToken)
                ?? throw new Exception("İşlem yapılmak istenen komisyon bulunamadı. Lütfen yöneticinize başvurun");
            return entity;
        }
    }
}
