namespace Domain.Entities
{
    public class PersonelBirimGorevlendirme
    {
        public int Id { get; set; }
        public int PersonelId { get; set; } = default!;
        public Personel Personel { get; set; } = default!; 
        public int BirimId { get; set; } = default!;
        public Birim Birim { get; set; } = default!;   
        public int UnvanId { get; set; } = default!;
        public DateTime BaslangicTarihi { get; set; } = default!;
        public DateTime? BitisTarihi { get; set; }
        public bool AktifMi => BitisTarihi == null || BitisTarihi < DateTime.Today;
        public string GorevAciklama { get; set; } = string.Empty;
    }
}
