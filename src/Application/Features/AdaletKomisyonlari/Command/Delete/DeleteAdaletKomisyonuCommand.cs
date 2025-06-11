using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Delete
{
    public class DeleteAdaletKomisyonuCommand : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }
}
