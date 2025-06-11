using Domain.Entities;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Shared.Enums;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.PersonelTayinTalepleri
{
    public class PersonelTayinTalepRepository(AppDbContext context) : BaseRepository<PersonelTayinTalep>(context), IPersonelTayinTalepRepository
    {
        public async Task<bool> ExistsActiveByPersonelIdAsync(int personelId, CancellationToken cancellationToken)
        {
            // Sadece aktif (iptal edilmemiş, tamamlanmamış) kayıtlar
            return await _dbSet.AnyAsync(x =>
                x.PersonelId == personelId &&
                !x.IptalEdildi &&
                (x.TayinTalepDurumu == TayinTalepDurumu.Beklemede
                 || x.TayinTalepDurumu == TayinTalepDurumu.Onaylandi),
                cancellationToken);
        }

        public async Task<List<PersonelTayinTalep>> GetByPersonelIdAsync(int personelId, CancellationToken cancellationToken = default)
        {
            // İster sadece aktifleri, ister hepsini getir.
            return await context.PersonelTayinTalep
                .Where(x => x.PersonelId == personelId)
                .Include(x => x.Tercihler)
                .Include(x => x.Gerekceler)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<PersonelTayinTalep?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(x => x.Tercihler)
                .Include(x => x.Gerekceler)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<PersonelTayinTalep>> GetListByPersonelIdWithDetailsAsync(int personelId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(x => x.PersonelId == personelId)
                .Include(x => x.Tercihler)
                .Include(x => x.Gerekceler)
                .ToListAsync(cancellationToken);
        }

        public async Task<PersonelTayinTalep> GetOrThrowAsync(int id, CancellationToken cancellationToken = default)
        {
            var talep = await _dbSet
                .Include(x => x.Tercihler)
                .Include(x => x.Gerekceler)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (talep == null)
                throw new Exception("Tayin talebi bulunamadı!");

            return talep;
        }
    }
}
