using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Update
{
    public class UpdatePersonelTayinTalepCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int TalepTuru { get; set; }
        public int TalepNedeni { get; set; }
        public string Aciklama { get; set; } = string.Empty;
        public List<int> Gerekceler { get; set; } = [];
    }
}
