using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.PersonelTayinTalepTercihleri
{
    public interface IPersonelTayinTalepTercihRepository : IBaseRepository<PersonelTayinTalepTercih>
    {
        Task<PersonelTayinTalepTercih?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<PersonelTayinTalepTercih>> GetByTalepIdAsync(int talepId, CancellationToken cancellationToken = default);
    }
}
