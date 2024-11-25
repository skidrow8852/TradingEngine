using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    public interface ILogger
    {
        void Debug(string module, string message);
        void Debug(string module, string message, Exception exception);
        void Info(string module, string message);
        void Info(string module, string message, Exception exception);
        void Warn(string module, string message);
        void Warn(string module, string message, Exception exception);
        void Error(string module, string message);
        void Error(string module, string message, Exception exception);

    }
}
