using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Delete
{
    public class DeletePersonelBirimGorevlendirmeCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int BirimId { get; set; }
        public int Unvan { get; set; }
    }
}
