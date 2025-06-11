

using Domain.Shared.Enums;
using Domain.Shared.ValueObjects;

namespace Domain.Abstracts
{
    public abstract class Kisi : IEntity
    {
        public int Id { get; set; }
        public TCKimlikNo TCKimlikNo { get; set; } = default!;
        public string Ad { get; set; } = default!;
        public string Soyad { get; set; } = default!;
        public Cinsiyet Cinsiyet { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
