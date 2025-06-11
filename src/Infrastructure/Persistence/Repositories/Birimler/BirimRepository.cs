using Domain.Entities;
using Domain.Repositories.Birimler;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Birimler
{
    public class BirimRepository(AppDbContext context) : BaseRepository<Birim>(context), IBirimRepository
    {
        public async Task<bool> ExistsByNameAsync(string birimAdi, int adliyeId, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(x => x.Ad == birimAdi && x.AdliyeId == adliyeId, cancellationToken);
        }
    }
}
