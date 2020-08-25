using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stocktrader.Models.Configuration;
using stocktrader.Services;
using System;
using System.Threading.Tasks;

namespace stocktrader
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static async Task Main(string[] args)
        {
            await ConfigureApp();
            Console.ReadKey();
        }

        private static async Task ConfigureApp()
        {
            var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(env) ||
                                env.ToLower() == "development";
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }
            Configuration = builder.Build();
            IServiceCollection services = new ServiceCollection();
            services
                .Configure<AlpacaClient>(Configuration.GetSection(nameof(AlpacaClient)))
                .AddOptions()
                .AddLogging()
                .AddSingleton<ISecretRevealer, SecretRevealer>()
                .AddSingleton<TradingService>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();
            var tradingService = serviceProvider.GetService<TradingService>();
            await tradingService.Init();
        }
    }
}
