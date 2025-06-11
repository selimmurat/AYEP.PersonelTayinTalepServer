using Domain.Abstracts;

namespace Domain.Entities
{
    public class Birim : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int AdliyeId { get; set; } = default!;
        public Adliye Adliye { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;

        public ICollection<PersonelBirimGorevlendirme> PersonelGorevlendirmeleri { get; set; } = new List<PersonelBirimGorevlendirme>();
    }
}
