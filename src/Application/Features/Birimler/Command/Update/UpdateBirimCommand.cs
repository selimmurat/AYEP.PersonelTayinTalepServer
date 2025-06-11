using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Command.Update
{
    public class UpdateBirimCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int AdliyeId { get; set; }
    }   
}
