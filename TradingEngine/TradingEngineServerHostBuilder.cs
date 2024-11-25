using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradingEngineServer.Core.Configuration;
namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder
    {
        public static IHost BuildTradingEngineServer() => Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); 
                    logging.AddConsole();    
                 
                })
                .ConfigureServices((context, services) =>
                {
            // Start with config
            services.AddOptions();
            services.Configure<TradingServerConfig>(context.Configuration.GetSection(nameof(TradingServerConfig)));

            // Add singleton objects
            services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

            // Add Hosted service
            services.AddHostedService<TradingEngineServer>();

        }).Build();
    }
}
