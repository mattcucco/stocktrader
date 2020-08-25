using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stocktrader.Configuration;
using System;

namespace stocktrader
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
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
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();
            var revealer = serviceProvider.GetService<ISecretRevealer>();

            revealer.Reveal();
            Console.ReadKey();
        }
    }
}
