using Domain.Shared.Enums;

namespace Domain.Entities
{
    public class PersonelTayinTalep
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public Personel Personel { get; set; } = default!;

        public DateTime BasvuruTarihi { get; set; } = DateTime.UtcNow;

        // Genel mi, Mazeret mi?
        public TayinTalepTuru TalepTuru { get; set; }

        // Talep Nedeni (enum, açıklaması içinde)
        public TayinTalepNedeni TalepNedeni { get; set; }

        public string Aciklama { get; set; } = string.Empty;

        // Başvuru durumu
        public TayinTalepDurumu TayinTalepDurumu { get; set; } = TayinTalepDurumu.Beklemede;

        // Navigation: Tercih edilen adliyeler (max 5)
        public ICollection<PersonelTayinTalepTercih> Tercihler { get; set; } = [];

        public ICollection<PersonelTayinTalepGerekce> Gerekceler { get; set; } = [];

        public bool IptalEdildi { get; set; } = false;
        public DateTime? IptalTarihi { get; set; }
        public int? IptalEdenPersonelId { get; set; }
    }
}
