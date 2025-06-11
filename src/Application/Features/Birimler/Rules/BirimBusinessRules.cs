using Domain.Entities;
using Domain.Repositories.Birimler;

namespace Application.Features.Birimler.Rules
{
    public class BirimBusinessRules(IBirimRepository birimRepository)
    {
        private readonly IBirimRepository _birimRepository = birimRepository;

        public async Task EnsureBirimNameIsUniqueAsync(string birimAdi, int adliyeId, CancellationToken cancellationToken)
        {
            var exists = await _birimRepository.ExistsByNameAsync(birimAdi, adliyeId, cancellationToken);
            if (exists)
                throw new Exception("Aynı adliye altında aynı isimde birim olamaz!");
        }

        public async Task<Birim> GetBirimOrThrowAsync(int id, CancellationToken cancellationToken)
        {
            var birim = await _birimRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new Exception("Birim bulunamadı!");
            return birim;
        }
    }
}
