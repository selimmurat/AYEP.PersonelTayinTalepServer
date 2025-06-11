using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries
{
    public class GetPersonelTayinTalepleriByPersonelIdQuery : IRequest<IResultBase>
    {
        public int PersonelId { get; set; }
        public GetPersonelTayinTalepleriByPersonelIdQuery(int personelId)
        {
            PersonelId = personelId;
        }
    }
}
