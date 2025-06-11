using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Delete
{
    public class DeleteAdliyeCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
