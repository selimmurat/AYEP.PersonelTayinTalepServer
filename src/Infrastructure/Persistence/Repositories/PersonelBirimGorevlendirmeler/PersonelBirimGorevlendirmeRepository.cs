using Domain.Entities;
using Domain.Repositories.PersonelGorevlendirmeler;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.PersonelBirimGorevlendirmeler
{
    public class PersonelBirimGorevlendirmeRepository(AppDbContext context) : BaseRepository<PersonelBirimGorevlendirme>(context), IPersonelBirimGorevlendirmeRepository
    {
        public async Task<bool> ExistsActiveByPersonelBirimUnvanAsync(int personelId, int birimId, int unvan, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AnyAsync(x => x.PersonelId == personelId && x.BirimId == birimId
                                                          && (int)x.Personel.Unvan == unvan && x.AktifMi, cancellationToken);
        }

        public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
