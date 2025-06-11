using Domain.Abstracts;
using Domain.Shared.Enums;
using Domain.Shared.ValueObjects;

namespace Domain.Entities
{
    public class Personel : Kisi
    {
        public SicilNo SicilNo { get; set; } = default!; // ab156994
        public Unvan Unvan { get; set; } = default!;    // zabıt katibi
        public PhoneNumber? PhoneNumber { get; set; }
        public Email? Email { get; set; }
        public DateTime MemuriyetBaslamaTarihi { get; set; } = default!;
        public DateTime? AsaletTarihi { get; set; }
        public DateTime? AyrilisTarihi { get; set; }
        public string AyrilisNedeni { get; set; } = string.Empty;
        public KullaniciSifre KullaniciSifre { get; set; } = null!;
        public Rol Rol { get; private set; } = Rol.Personel;

        public ICollection<PersonelBirimGorevlendirme> PersonelGorevlendirmeleri { get; set; } = [];

        public void RolAyarla(Rol rol)
        {
            Rol = rol;
        }
        private Personel() { }
        public Personel(SicilNo sicilNo, TCKimlikNo tckimlikNo, string ad, string soyad, Cinsiyet cinsiyet, PhoneNumber phoneNumber, Email email)
        {
            SicilNo = sicilNo;
            TCKimlikNo = tckimlikNo;
            Ad = ad;
            Soyad = soyad;
            Cinsiyet = cinsiyet;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
