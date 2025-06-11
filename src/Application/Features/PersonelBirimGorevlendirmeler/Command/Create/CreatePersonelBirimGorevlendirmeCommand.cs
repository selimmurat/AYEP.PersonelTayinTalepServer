using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Create
{
    public class CreatePersonelBirimGorevlendirmeCommand : IRequest<IResultBase>
    {
        public int PersonelId { get; set; }
        public int BirimId { get; set; }
        public int UnvanId { get; set; } 
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string GorevAciklama { get; set; } = string.Empty;
    }
}
