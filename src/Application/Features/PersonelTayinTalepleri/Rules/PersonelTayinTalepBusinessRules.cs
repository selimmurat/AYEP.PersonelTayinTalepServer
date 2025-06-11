using Domain.Entities;
using Domain.Repositories.PersonelTayinTalepleri;

namespace Application.Features.PersonelTayinTalepleri.Rules
{
    public class PersonelTayinTalepBusinessRules(IPersonelTayinTalepRepository personelTayinTalepRepository)
    {
        private readonly IPersonelTayinTalepRepository _personelTayinTalepRepository = personelTayinTalepRepository;

        public async Task PersonelMustExist(int personelId)
        {
            var exists = await _personelTayinTalepRepository.ExistsAsync(personelId);
            if (!exists)
                throw new Exception("Personel bulunamadı.");
        }

        /// <summary>
        /// Bir personelin aktif bir tayin talebi olup olmadığını kontrol eder.
        /// (İptal edilmemiş ve sonucu beklemede/işleniyor olan kayıt var mı?)
        /// </summary>
        public async Task EnsureNoActiveTayinTalepExistsAsync(int personelId, CancellationToken cancellationToken)
        {
            bool exists = await _personelTayinTalepRepository.AnyAsync(
                x => x.PersonelId == personelId && !x.IptalEdildi &&
                     (x.TayinTalepDurumu == Domain.Shared.Enums.TayinTalepDurumu.Beklemede
                      || x.TayinTalepDurumu == Domain.Shared.Enums.TayinTalepDurumu.Onaylandi),
                cancellationToken);

            if (exists)
                throw new Exception("Daha önce oluşturulmuş ve halen aktif olan bir tayin talebiniz var. Önce mevcut talebi iptal edin veya tamamlanmasını bekleyin.");
        }

        public async Task<PersonelTayinTalep> GetTalepOrThrowAsync(int id, CancellationToken cancellationToken)
        {
            var talep = await _personelTayinTalepRepository.GetByIdAsync(id, cancellationToken);

            return talep ?? throw new Exception("İlgili tayin talebi bulunamadı!");
        }
    }
}
