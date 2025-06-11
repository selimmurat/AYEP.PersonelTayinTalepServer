using Domain.Repositories.AdaletKomisyonlari;
using Domain.Repositories.Adliyeler;
using Domain.Repositories.Birimler;
using Domain.Repositories.LogEntrys;
using Domain.Repositories.PersonelGorevlendirmeler;
using Domain.Repositories.Personeller;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Repositories.PersonelTayinTalepTercihleri;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAdaletKomisyonuRepository AdaletKomisyonuRepository { get; }
        IAdliyeRepository AdliyeRepository { get; }
        IBirimRepository BirimRepository { get; }
        ILogEntryRepository LogEntryRepository { get; }
        IPersonelRepository PersonelRepository { get; }
        IPersonelBirimGorevlendirmeRepository PersonelBirimGorevlendirmeRepository { get; }
        IPersonelTayinTalepRepository PersonelTayinTalepRepository { get; }
        IPersonelTayinTalepTercihRepository PersonelTayinTalepTercihRepository { get; }
        IAuthRepository AuthRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
