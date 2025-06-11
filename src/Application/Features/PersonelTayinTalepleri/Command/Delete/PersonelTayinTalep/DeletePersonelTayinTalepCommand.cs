using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Delete
{
    public class DeletePersonelTayinTalepCommand : IRequest<IResultBase>
    {       
        public int Id { get; set; }       
        public int IptalEdenPersonelId { get; set; }
    }
}
