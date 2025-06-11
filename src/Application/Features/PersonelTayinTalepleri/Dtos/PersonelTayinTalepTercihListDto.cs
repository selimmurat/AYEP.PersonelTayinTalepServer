namespace Application.Features.PersonelTayinTalepleri.Dtos
{
    public class PersonelTayinTalepTercihListDto
    {
        public int Id { get; set; }
        public int AdliyeId { get; set; }
        public string AdliyeAdi { get; set; } = string.Empty;
        public int TercihSirasi { get; set; }
    }
}
