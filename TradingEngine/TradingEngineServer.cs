using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {   
        private readonly ILogger _logger;
        private readonly TradingServerConfig _config;
        public TradingEngineServer(ILogger<TradingEngineServer> logger, IOptions<TradingServerConfig> config) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config.Value ?? throw new ArgumentNullException(nameof(config));
            
        }

        public Task Run(CancellationToken token) => ExecuteAsync(token);
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Started {nameof(TradingEngineServer)}");
            while(!stoppingToken.IsCancellationRequested)
            {

            }
            _logger.LogInformation($"Stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}
