using Application.Features.Adliyeler.Dtos;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAdliyelerByKomisyonIdQuery : IRequest<IResult<List<AdliyeDto>>>
    {
        public int KomisyonId { get; set; }
    }
}
