using Domain.Entities;
using Domain.Repositories.Adliyeler;

namespace Application.Features.Adliyeler.Rules
{
    public class AdliyeBusinessRules(IAdliyeRepository adliyeRepository)
    {
        public readonly IAdliyeRepository _adliyeRepository = adliyeRepository;

        public async Task EnsureAdliyeNameIsUniqueAsync(string adliyeAdi, int komisyonId, CancellationToken cancellationToken)
        {
            var exists = await _adliyeRepository.AnyAsync(
         x => x.Ad.Equals(adliyeAdi, StringComparison.CurrentCultureIgnoreCase) && x.KomisyonId == komisyonId, cancellationToken);

            if (exists)
                throw new Exception("Bir ilde aynı isimde adliye olamaz!");

        }

        public async Task<Adliye> GetAdliyeOrThrowAsync(int id, CancellationToken cancellationToken = default)
        {
            var adliye = await _adliyeRepository.GetByIdAsync(id, cancellationToken) 
                ?? throw new Exception("Böyle bir Adliye bulunamadı!");
            return adliye;
        }
    }
}
