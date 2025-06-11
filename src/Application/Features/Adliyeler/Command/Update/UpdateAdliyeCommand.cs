using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Update
{
    public class UpdateAdliyeCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int AdaletKomisyonuId { get; set; }
        public int IlId { get; set; }
    }
}
