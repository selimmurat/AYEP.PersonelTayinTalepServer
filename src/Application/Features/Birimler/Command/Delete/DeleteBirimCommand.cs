using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Command.Delete
{
    public class DeleteBirimCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
