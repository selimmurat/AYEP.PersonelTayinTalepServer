namespace Application.Features.Personeller.Dtos
{
    public class CreatedPersonelDto
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string SicilNo { get; set; } = string.Empty;
        public string? Unvan { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime MemuriyetBaslamaTarihi { get; set; }
        public DateTime? AsaletTarihi { get; set; }
        public DateTime? AyrilisTarihi { get; set; }
        public string AyrilisNedeni { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string? PlainPassword { get; set; } // Sadece ilk oluşturma için!
    }
}
