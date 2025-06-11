using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Create
{
    public class CreateAdliyeCommand : IRequest<IResultBase>
    {
        public string Ad { get; set; } = default!;
        public int AdaletKomisyonuId { get; set; }
        public int IlId { get; set; }
    }
}
