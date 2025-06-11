using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Queries
{
    public class GetBirimByIdQuery : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
