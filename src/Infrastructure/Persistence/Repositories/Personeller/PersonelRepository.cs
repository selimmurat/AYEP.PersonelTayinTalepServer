using Domain.Entities;
using Domain.Repositories.Personeller;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Personeller
{
    public class PersonelRepository(AppDbContext context)
        : BaseRepository<Personel>(context), IPersonelRepository
    {
        public async Task<Personel?> GetBySicilNoWithSifreAsync(string sicilNo, CancellationToken cancellationToken = default)
        {
            return await context.Personel
                .Include(p => p.KullaniciSifre)
                .Include(p => p.PersonelGorevlendirmeleri)
                    .ThenInclude(pg => pg.Birim)
                .FirstOrDefaultAsync(p => p.SicilNo.sicilNo == sicilNo, cancellationToken);
        }

        public async Task<Personel?> GetBySicilNoWithSifreAsync(string sicilNo)
        {
            return await GetBySicilNoWithSifreAsync(sicilNo, CancellationToken.None);
        }
    }
}
