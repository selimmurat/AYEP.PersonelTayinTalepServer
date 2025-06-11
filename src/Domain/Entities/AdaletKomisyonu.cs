using Domain.Abstracts;

namespace Domain.Entities
{
    public class AdaletKomisyonu : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int IlId { get; set; }

        public ICollection<Adliye> Adliyeler { get; set; } = [];
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
