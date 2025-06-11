using Domain.Entities;
using Domain.Repositories.Adliyeler;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Adliyeler
{
    public class AdliyeRepository(AppDbContext context) : BaseRepository<Adliye>(context), IAdliyeRepository
    {
        public async Task<bool> ExistsByNameAsync(string adliyeAdi, int komisyonId, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(x => x.Ad == adliyeAdi && x.KomisyonId == komisyonId, cancellationToken);
        }
    }
}
