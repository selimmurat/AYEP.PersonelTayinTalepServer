using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Update
{
    public class UpdatePersonelBirimGorevlendirmeCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int BirimId { get; set; }
        public int Unvan { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
    }
}
