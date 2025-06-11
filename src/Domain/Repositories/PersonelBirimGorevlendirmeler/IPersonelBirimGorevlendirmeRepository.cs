using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.PersonelGorevlendirmeler
{
    public interface IPersonelBirimGorevlendirmeRepository : IBaseRepository<PersonelBirimGorevlendirme>
    {
        /// <summary>
        /// Aynı personel aynı birimde aynı unvan ile görevlendirilişmi ve halen görevlendirme aktif mi? 
        /// Aktif ise görevlendirme izin verilmeyecek
        /// </summary>
        Task<bool> ExistsActiveByPersonelBirimUnvanAsync(int personelId, int birimId, int unvan, CancellationToken cancellationToken);

        /// <summary>
        /// Aynı personel aynı birimde aynı unvan ile görevlendirilişmi ve halen görevlendirme aktif mi? 
        /// Aktif ise görevlendirme kalıcı silenecek 
        /// </summary>
        Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
    }
}
