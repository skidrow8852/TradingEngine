using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Logging;

namespace LoggingCS
{
    public record LogInformation(LogLevel LogLevel, string Module ,string Message, DateTime Now, int ThreadId, string ThreadName)
    {
    }
}
