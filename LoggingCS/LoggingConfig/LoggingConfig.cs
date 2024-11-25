using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TradingEngineServer.Logging.LoggingConfig
{
    public class LoggingConfig
    {
        public LoggerType LoggerType { get; set; }  
        public TextLoggerConfig TextLoggerConfig { get; set; }
    }
    public class TextLoggerConfig
    {
        public string Directory { get; set; }

        public string Filename { get; set; }    

        public string FileExtension { get; set; }   
    }
}
