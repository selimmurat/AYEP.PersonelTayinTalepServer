using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Queries
{
    public class GetBirimlerByAdliyeIdQuery : IRequest<IResultBase>
    {
        public int AdliyeId { get; set; }
    }
}
