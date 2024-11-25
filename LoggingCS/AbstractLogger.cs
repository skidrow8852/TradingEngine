using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    public abstract class  AbstractLogger : ILogger
    {
        protected AbstractLogger() { }
        public void Debug(string module, string message) => Log(LogLevel.Debug, module, message);

        public void Debug(string module, string message, Exception exception) => Log(LogLevel.Debug, module, exception.ToString());

        public void Error(string module, string message) => Log(LogLevel.Error, module, message);

        public void Error(string module, string message, Exception exception) => Log(LogLevel.Error, module, exception.ToString());

        public void Info(string module, string message) => Log(LogLevel.Info, module, message);

        public void Info(string module, string message, Exception exception) => Log(LogLevel.Info, module, exception.ToString());

        public void Warn(string module, string message) => Log(LogLevel.Warn, module, message);

        public void Warn(string module, string message, Exception exception) => Log(LogLevel.Warn, module, exception.ToString());

        protected abstract void Log(LogLevel level, string module, string message);
    }
}
