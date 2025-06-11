using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Queries
{
    public class GetPersonelBirimGorevlendirmeByIdQuery : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}