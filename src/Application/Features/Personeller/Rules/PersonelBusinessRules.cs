using Domain.Entities;
using Domain.Repositories.Personeller;

namespace Application.Features.Personeller.Rules
{
    public class PersonelBusinessRules(IPersonelRepository personelRepository)
    {
        private readonly IPersonelRepository _personelRepository = personelRepository;

        public async Task EnsureSicilNoIsUniqueAsync(string sicilNo, CancellationToken cancellationToken = default)
        {
            bool exists = await _personelRepository.AnyAsync(
                x => x.SicilNo.sicilNo == sicilNo, cancellationToken);
            if (exists)
                throw new Exception("Aynı Sicil Numarası ile personel zaten var.");
        }

        public async Task<Personel> GetPersonelOrThrowAsync(int id, CancellationToken cancellationToken)
        {
            var personel = await _personelRepository.GetByIdAsync(id, cancellationToken)
               ?? throw new Exception("Personel bulunamadı!");
            return personel;
        }
    }
}
