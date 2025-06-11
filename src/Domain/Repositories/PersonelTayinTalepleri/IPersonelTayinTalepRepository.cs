using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.PersonelTayinTalepleri
{
    public interface IPersonelTayinTalepRepository : IBaseRepository<PersonelTayinTalep>
    {
        Task<PersonelTayinTalep?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default);

        Task<List<PersonelTayinTalep>> GetListByPersonelIdWithDetailsAsync(int personelId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Talep var mı diye hızlı kontrol için
        /// </summary>
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Talep yoksa hata fırlatır (iş katmanında exception handling kolaylaşır)
        /// </summary>
        Task<PersonelTayinTalep> GetOrThrowAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> ExistsActiveByPersonelIdAsync(int personelId, CancellationToken cancellationToken = default);

        Task<List<PersonelTayinTalep>> GetByPersonelIdAsync(int personelId, CancellationToken cancellationToken = default);
    }
}
