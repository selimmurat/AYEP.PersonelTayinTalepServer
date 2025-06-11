using Application.Features.PersonelTayinTalepleri.Command.Create.PersonelTayinTalepTercih;

namespace Application.Features.PersonelTayinTalepleri.Dtos
{
    public class CreatePersonelTayinTalepDto
    {
        public int PersonelId { get; set; }
        public int TalepTuru { get; set; }
        public int TalepNedeni { get; set; }
        public string Aciklama { get; set; } = string.Empty;
        public List<CreatePersonelTayinTalepTercihCommand> Tercihler { get; set; } = [];
        public List<int> Gerekceler { get; set; } = [];
    }
}
