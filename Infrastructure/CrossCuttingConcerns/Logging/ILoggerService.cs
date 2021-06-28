using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    public interface ILoggerService
    {
        void Info(object logMessage);
        void Debug(object logMessage);
        void Warn(object logMessage);
        void Fatal(object logMessage);
        void Error(object logMessage);

    }
}
