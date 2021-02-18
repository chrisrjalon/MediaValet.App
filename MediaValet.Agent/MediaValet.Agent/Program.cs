using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.Business.Mapper.Profiles;
using MediaValet.OrderSupervisor.DataAccess.Helpers;
using MediaValet.OrderSupervisor.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace MediaValet.Agent
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables()
                .Build();

            services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("MediaValet"))
                .AddClasses(publicOnly: true)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation =>
                        implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(typeof(IEntityManager<>), typeof(EntityManager<>));
            services.AddScoped(typeof(IQueueStorage<>), typeof(QueueStorage<>));
            services.AddScoped(typeof(ITableStorage<>), typeof(TableStorage<>));
            services.AddAutoMapper(typeof(MainProfile).GetTypeInfo().Assembly);

            services.AddTransient<App>();
        }
    }
}
