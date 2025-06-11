using Domain.Entities;
using Domain.Repositories.AdaletKomisyonlari;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.AdaletKomisyonlari
{
    public class AdaletKomisyonuRepository(AppDbContext context) : BaseRepository<AdaletKomisyonu>(context), IAdaletKomisyonuRepository
    {
        public async Task<bool> ExistsByNameAsync(string komisyonAdi, int ilId, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(x => x.Ad == komisyonAdi && x.IlId == ilId, cancellationToken);
        }
    }
}
