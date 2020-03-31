using Di.Sample.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

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

            services.AddSingleton<SimpleApplication>();

            return services;
        }
    }
}
