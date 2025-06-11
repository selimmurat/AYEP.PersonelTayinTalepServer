using Domain.Entities;
using Domain.Repositories.Personeller;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Auth
{
    public class AuthRepository(AppDbContext context) : BaseRepository<Personel>(context), IAuthRepository
    {
        public async Task<Personel> GetBySicilNoWithSifreAndGorevlendirmelerAsync(string sicilNo)
        {
            return await context.Personel
                .Include(p => p.KullaniciSifre)
                .Include(p => p.PersonelGorevlendirmeleri)
                    .ThenInclude(pg => pg.Birim)
                .FirstOrDefaultAsync(p => p.SicilNo.sicilNo == sicilNo)
                ?? throw new InvalidOperationException($"Sicil Numarası '{sicilNo}' bulunamadı!");
        }
    }
}
