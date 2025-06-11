using Application.Features.PersonelTayinTalepleri.Dtos;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries.GetPersonelTayinTalepTercihList
{
    public class GetPersonelTayinTalepTercihListQuery : IRequest<List<PersonelTayinTalepTercihListDto>>
    {
        public int PersonelTayinTalepId { get; set; }

        public GetPersonelTayinTalepTercihListQuery(int personelTayinTalepId)
        {
            PersonelTayinTalepId = personelTayinTalepId;
        }
    }
}
