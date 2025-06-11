using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Command.Delete
{
    public class DeletePersonelCommand : IRequest<IResultBase>
    {        public int Id { get; set; }
    }
}
