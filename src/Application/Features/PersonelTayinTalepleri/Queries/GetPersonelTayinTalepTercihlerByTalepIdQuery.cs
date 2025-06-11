using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries.PersonelTayinTalepTercih
{
    public class GetPersonelTayinTalepTercihlerByTalepIdQuery : IRequest<IResultBase>
    {
        public int TalepId { get; }

        public GetPersonelTayinTalepTercihlerByTalepIdQuery(int talepId)
        {
            TalepId = talepId;
        }
    }
}