using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Create
{
    public class CreateAdaletKomisyonuCommand : IRequest<IResultBase>
    {
        public string Ad { get; set; } = default!;
        public int IlId { get; set; } = default!;
    }
}
