namespace Domain.Entities
{
    public class PersonelTayinTalepTercih
    {
        public int Id { get; set; }

        public int PersonelTayinTalepId { get; set; }
        public PersonelTayinTalep PersonelTayinTalep { get; set; } = default!;
        public int TercihSirasi { get; set; }
        public int AdliyeId { get; set; }
        public Adliye Adliye { get; set; } = default!;

        // --- Soft Delete ve Audit Alanları ---
        /// <summary>
        /// Kullanıcı tarafından iptal edildi mi?
        /// </summary>
        public bool IptalEdildi { get; set; } = false;
        public DateTime? IptalTarihi { get; set; }
        public int? IptalEdenPersonelId { get; set; }
    }
}
