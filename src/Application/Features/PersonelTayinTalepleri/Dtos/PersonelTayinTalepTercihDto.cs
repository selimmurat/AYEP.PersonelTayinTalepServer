namespace Application.Features.PersonelTayinTalepleri.Dtos
{
    public class PersonelTayinTalepTercihDto
    {
        public int Id { get; set; }
        public int PersonelTayinTalepId { get; set; }
        public int TercihSirasi { get; set; }
        public int AdliyeId { get; set; }
        public string AdliyeAd { get; set; } = string.Empty;
        public int KomisyonId { get; set; }
        public string KomisyonAd { get; set; } = string.Empty;
        public int IlId { get; set; }
        public string IlAd { get; set; } = string.Empty;
        public bool IptalEdildi { get; set; } = false;
        public DateTime? IptalTarihi { get; set; }
        public int? IptalEdenPersonelId { get; set; }
    }
}
