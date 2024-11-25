using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Core.Configuration
{
     class TradingServerConfig
    {
        public TradinEngineServerSettings TradinEngineServerSettings { get; set; }
    }
    class TradinEngineServerSettings
    {
        public int Port { get; set; }
    }
}
