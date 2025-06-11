using Application.Features.PersonelBirimGorevlendirmeler.Dtos;

namespace Application.Features.Personeller.Dtos
{
    public class PersonelDto
    {
        public int Id { get; set; }
        public string SicilNo { get; set; } = string.Empty;
        public string TCKimlikNo { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public int Cinsiyet { get; set; }
        public string CinsiyetText => ((Domain.Shared.Enums.Cinsiyet)Cinsiyet).ToString();
        public string Unvan { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime MemuriyetBaslamaTarihi { get; set; }
        public DateTime? AsaletTarihi { get; set; }
        public DateTime? AyrilisTarihi { get; set; }
        public string AyrilisNedeni { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        // Aktif görev bilgileri (güncel birimde, birim/adliye/komisyon detayı)
        public List<PersonelBirimGorevlendirmeDto> AktifGorevlendirmeler { get; set; } = [];
        // Kullanıcı aktif mi
        public bool AktifMi { get; set; }
    }
}
