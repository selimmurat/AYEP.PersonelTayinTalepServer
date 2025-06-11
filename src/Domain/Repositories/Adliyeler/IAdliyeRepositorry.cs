using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.Adliyeler
{
    public interface IAdliyeRepository : IBaseRepository<Adliye>
    {
        Task<bool> ExistsByNameAsync(string adliyeAdi, int komisyonId, CancellationToken cancellationToken);
    }
}
