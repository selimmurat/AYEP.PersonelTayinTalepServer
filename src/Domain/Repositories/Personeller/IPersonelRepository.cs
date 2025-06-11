using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.Personeller
{
    public interface IPersonelRepository : IBaseRepository<Personel>
    {
        Task<Personel?> GetBySicilNoWithSifreAsync(string sicilNo);
    }
}