using Application.Interfaces;
using Domain.Repositories.AdaletKomisyonlari;
using Domain.Repositories.Adliyeler;
using Domain.Repositories.Birimler;
using Domain.Repositories.LogEntrys;
using Domain.Repositories.PersonelGorevlendirmeler;
using Domain.Repositories.Personeller;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Repositories.PersonelTayinTalepTercihleri;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork(
        AppDbContext context,
        IAdaletKomisyonuRepository adaletKomisyonuRepository,
        IAdliyeRepository adliyeRepository,
        IBirimRepository birimRepository,
        IAuthRepository authRepository,
        ILogEntryRepository logEntryRepository,
        IPersonelBirimGorevlendirmeRepository personelBirimGorevlendirmeRepository,
        IPersonelRepository personelRepository,
        IPersonelTayinTalepRepository personelTayinTalepRepository,
        IPersonelTayinTalepTercihRepository personelTayinTalepTercihRepository) : IUnitOfWork
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public IAdaletKomisyonuRepository AdaletKomisyonuRepository { get; } = adaletKomisyonuRepository ?? throw new ArgumentNullException(nameof(adaletKomisyonuRepository));
        public IAdliyeRepository AdliyeRepository { get; } = adliyeRepository ?? throw new ArgumentNullException(nameof(adliyeRepository));
        public IAuthRepository AuthRepository { get; } = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        public ILogEntryRepository LogEntryRepository { get; } = logEntryRepository ?? throw new ArgumentNullException(nameof(logEntryRepository));
        public IPersonelBirimGorevlendirmeRepository PersonelBirimGorevlendirmeRepository { get; } = personelBirimGorevlendirmeRepository ?? throw new ArgumentNullException(nameof(personelBirimGorevlendirmeRepository));
        public IPersonelRepository PersonelRepository { get; } = personelRepository ?? throw new ArgumentNullException(nameof(personelRepository));
        public IBirimRepository BirimRepository { get; } = birimRepository ?? throw new ArgumentNullException(nameof(birimRepository));
        public IPersonelRepository PersonelRepositRepository { get; } = personelRepository ?? throw new ArgumentNullException(nameof(personelRepository));
        public IPersonelTayinTalepRepository PersonelTayinTalepRepository { get; } = personelTayinTalepRepository ?? throw new ArgumentNullException(nameof(personelTayinTalepRepository));

        public IPersonelTayinTalepTercihRepository PersonelTayinTalepTercihRepository { get; } = personelTayinTalepTercihRepository ??  throw new ArgumentNullException(nameof(personelTayinTalepTercihRepository));

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
