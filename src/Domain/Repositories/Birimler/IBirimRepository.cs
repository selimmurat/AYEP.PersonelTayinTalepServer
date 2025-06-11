using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories.Birimler
{
    public interface IBirimRepository : IBaseRepository<Birim>
    {
        /// <summary>
        /// Aynı adliye altında aynı isimde birim var mı?
        /// </summary>
        Task<bool> ExistsByNameAsync(string birimAdi, int adliyeId, CancellationToken cancellationToken);
    }
}
