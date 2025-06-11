using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.Personeller
{
    public interface IAuthRepository : IBaseRepository<Personel>
    {
        Task<Personel> GetBySicilNoWithSifreAndGorevlendirmelerAsync(string sicilNo);
    }
}
