using Di.Sample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace Di.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var provider = services.BuildServiceProvider();

            provider.GetService<SimpleApplication>().Run();
        }

        static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var appConfig = new AppConfig();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.Console()
                .CreateLogger();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            config.Bind(appConfig);

            Console.WriteLine($"App Config has been loaded my successfully. The settings value is {appConfig.SomeSetting}");


            services.Scan(scan =>
            {
                scan.FromAssemblyOf<SimpleApplication>()
                .AddClasses(classes =>
                {
                    classes.InNamespaceOf<GreetingsService>();
                })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });


            services.AddLogging(c => c.AddSerilog());
            services.AddSingleton<SimpleApplication>();

            return services;
        }
    }
}
