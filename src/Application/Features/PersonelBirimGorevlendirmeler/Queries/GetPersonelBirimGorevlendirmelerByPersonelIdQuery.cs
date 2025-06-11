using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Queries
{
    public class GetPersonelBirimGorevlendirmelerByPersonelIdQuery : IRequest<IResultBase>
    {
        public int PersonelId { get; set; }
    }
}