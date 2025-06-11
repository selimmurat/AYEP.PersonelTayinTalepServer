using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.AdaletKomisyonlari
{
    public interface IAdaletKomisyonuRepository : IBaseRepository<AdaletKomisyonu>
    {
        Task<bool> ExistsByNameAsync(string komisyonAdi, int ilId, CancellationToken cancellationToken);
    }
}
