using Domain.Entities;
using Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<AdaletKomisyonu> AdaletKomisyonu => Set<AdaletKomisyonu>();
        public DbSet<Adliye> Adliye { get; set; }
        public DbSet<Birim> Birim { get; set; }
        public DbSet<KullaniciSifre> KullaniciSifre { get; set; }
        public DbSet<LogEntry> Log { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelBirimGorevlendirme> PersonelBirimGorevlendirme { get; set; }
        public DbSet<PersonelTayinTalep> PersonelTayinTalep { get; set; }
        public DbSet<PersonelTayinTalepTercih> PersonelTayinTalepTercih { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Komisyon -> Adliye : Cascade
            modelBuilder.Entity<Adliye>()
                .HasOne(a => a.Komisyon)
                .WithMany(k => k.Adliyeler)
                .HasForeignKey(a => a.KomisyonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Adliye -> Birim : Cascade
            modelBuilder.Entity<Birim>()
                .HasOne(b => b.Adliye)
                .WithMany(a => a.Birimler)
                .HasForeignKey(b => b.AdliyeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Personel -> KullaniciSifre Cascade
            modelBuilder.Entity<Personel>()
                .HasOne(p => p.KullaniciSifre)
                .WithOne(k => k.Personel)
                .HasForeignKey<KullaniciSifre>(k => k.PersonelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonelTayinTalepTercih>()
                .HasOne(t => t.PersonelTayinTalep)
                .WithMany(t => t.Tercihler)
                .HasForeignKey(t => t.PersonelTayinTalepId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonelTayinTalepGerekce>()
                .HasOne(g => g.PersonelTayinTalep)
                .WithMany(t => t.Gerekceler)
                .HasForeignKey(g => g.PersonelTayinTalepId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Personel>().OwnsOne(p => p.SicilNo);
            modelBuilder.Entity<Personel>().OwnsOne(p => p.Email);
            modelBuilder.Entity<Personel>().OwnsOne(p => p.PhoneNumber);
            modelBuilder.Entity<Personel>().OwnsOne(p => p.TCKimlikNo);

        }
    }
}
