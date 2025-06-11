using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Delete.PersonelTayinTalepTercih
{
    public class DeletePersonelTayinTalepTercihCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}