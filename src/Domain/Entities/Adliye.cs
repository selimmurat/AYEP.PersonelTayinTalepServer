using Domain.Abstracts;

namespace Domain.Entities
{
    public class Adliye : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int KomisyonId { get; set; } = default!;
        public AdaletKomisyonu Komisyon { get; set; } = default!;
        public ICollection<Birim> Birimler { get; set; } = [];
        public bool IsMerkez { get; set; } // true = merkez, false = mülhakat
        public int HizmetBolgesi { get; set; } = default!; 
        public int HizmetPuani { get; set; } = default!;  
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
