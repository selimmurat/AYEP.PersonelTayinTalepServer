namespace Domain.Entities
{
    public class KullaniciSifre
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string SifreHash { get; set; } = null!;
        public string SifreSalt { get; set; } = null!;
        public DateTime SonDegisimTarihi { get; set; } = DateTime.UtcNow;
        public Personel Personel { get; set; } = null!;

        public bool IlkGirisMi { get; set; } = true; // İlk atandığında true olur, şifre değişince false yapılır.
    }
}
