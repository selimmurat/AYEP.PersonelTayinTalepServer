using Domain.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Birimler.Command.Create
{
    public class CreateBirimCommand : IRequest<IResultBase>
    {
        public string Ad { get; set; } = default!;
        public int AdliyeId { get; set; }
    }
}
