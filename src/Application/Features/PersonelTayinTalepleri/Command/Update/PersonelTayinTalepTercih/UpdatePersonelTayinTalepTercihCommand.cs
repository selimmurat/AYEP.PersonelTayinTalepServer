using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Update.PersonelTayinTalepTercih
{
    public class UpdatePersonelTayinTalepTercihCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public int AdliyeId { get; set; }
        public int TercihSirasi { get; set; }
    }
}
