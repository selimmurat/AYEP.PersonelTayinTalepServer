// Dosya: Infrastructure/Persistence/Repositories/PersonelTayinTalepTercihleri/PersonelTayinTalepTercihRepository.cs

using Domain.Entities;
using Domain.Repositories.PersonelTayinTalepTercihleri;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.PersonelTayinTalepTercihleri
{
    public class PersonelTayinTalepTercihRepository(AppDbContext context) : BaseRepository<PersonelTayinTalepTercih>(context), IPersonelTayinTalepTercihRepository
    {
        public async Task<PersonelTayinTalepTercih?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(x => x.Adliye)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<PersonelTayinTalepTercih>> GetByTalepIdAsync(int talepId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(x => x.PersonelTayinTalepId == talepId)
                .Include(x => x.Adliye)
                .ToListAsync(cancellationToken);
        }
    }
}
