using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Cancel.CanselPersonelTayinTalep
{
    public class CancelPersonelTayinTalepCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
