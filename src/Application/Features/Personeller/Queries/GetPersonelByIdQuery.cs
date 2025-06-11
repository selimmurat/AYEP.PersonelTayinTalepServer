using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Queries
{
    public class GetPersonelByIdQuery : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
