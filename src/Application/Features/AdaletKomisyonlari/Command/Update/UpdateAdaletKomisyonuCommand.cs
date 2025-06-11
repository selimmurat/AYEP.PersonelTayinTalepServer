using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Update
{
    public class UpdateAdaletKomisyonuCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int IlId { get; set; } = default!;
    }
}
