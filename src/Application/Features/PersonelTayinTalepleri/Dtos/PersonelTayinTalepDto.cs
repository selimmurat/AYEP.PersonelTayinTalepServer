namespace Application.Features.PersonelTayinTalepleri.Dtos
{
    public class PersonelTayinTalepDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public DateTime BasvuruTarihi { get; set; }
        public int TalepTuru { get; set; }
        public int TalepNedeni { get; set; }
        public string Aciklama { get; set; } = string.Empty;
        public int TayinTalepDurumu { get; set; }
        public List<PersonelTayinTalepTercihDto> Tercihler { get; set; } = [];
        public List<int> Gerekceler { get; set; } = [];
    }
}
