using Application.Features.Adliyeler.Dtos;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAdliyeByIdQuery : IRequest<IResult<AdliyeDto>>
    {
        public int Id { get; set; }
    }
}
