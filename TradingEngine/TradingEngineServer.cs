using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Logging;
namespace TradingEngineServer.Core
{
    sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {   
        private readonly ITextLogger _logger;
        private readonly IOptions<TradingServerConfig> _config;
        public TradingEngineServer(IOptions<TradingServerConfig> config, ITextLogger textLogger) {
            _logger = textLogger ?? throw new ArgumentNullException(nameof(textLogger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            
        }

        public Task Run(CancellationToken token) => ExecuteAsync(token);
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Info(nameof(TradingEngineServer), "Starting Trading Engine");
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            _logger.Info(nameof(TradingEngineServer), "Stopping Trading Engine");
            return Task.CompletedTask;
        }
    }
}
