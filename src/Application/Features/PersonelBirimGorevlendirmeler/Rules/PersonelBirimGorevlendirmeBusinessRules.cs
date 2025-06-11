using Domain.Repositories.PersonelGorevlendirmeler;

namespace Application.Features.PersonelBirimGorevlendirmeler.Rules
{
    public class PersonelBirimGorevlendirmeBusinessRules(IPersonelBirimGorevlendirmeRepository repository)
    {
        private readonly IPersonelBirimGorevlendirmeRepository _repository = repository;

        public async Task ExistsActiveByPersonelBirimUnvanAsync(int personelId, int birimId, int unvan, CancellationToken cancellationToken)
        {
            bool exists = await _repository.ExistsActiveByPersonelBirimUnvanAsync(personelId, birimId, unvan, cancellationToken);
            if (exists)
                throw new Exception("Bu personel aynı birimde ve unvanda aktif görevlendirilmiş durumda.");
        }

        public async Task ExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            bool exists = await _repository.ExistsByIdAsync(id, cancellationToken);
            if (!exists)
                throw new Exception("Görevlendirme bulunamadı");

        }
    }
}
