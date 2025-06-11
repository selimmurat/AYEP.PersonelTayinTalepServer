using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppLogger
    {
        void LogInfo(string message);
        void LogError(string message, Exception? ex = null);
        void LogWarning(string message);
    }
}
