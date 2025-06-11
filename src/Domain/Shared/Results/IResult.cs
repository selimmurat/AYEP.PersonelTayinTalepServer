using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Results
{
    public interface IResult<T> : IResultBase
    {
        T Data { get; }
    }
}
