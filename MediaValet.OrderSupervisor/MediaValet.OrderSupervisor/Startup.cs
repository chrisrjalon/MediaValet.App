using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.DataAccess.Repositories;
using MediaValet.OrderSupervisor.Business.Mapper.Profiles;
using MediaValet.OrderSupervisor.DataAccess.Helpers;
using Scrutor;

namespace MediaValet.OrderSupervisor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("MediaValet"))
                .AddClasses(publicOnly: true)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation =>
                        implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());
            services.AddSingleton(typeof(IEntityManager<>), typeof(EntityManager<>));
            services.AddScoped(typeof(IQueueStorage<>), typeof(QueueStorage<>));
            services.AddScoped(typeof(ITableStorage<>), typeof(TableStorage<>));
            services.AddAutoMapper(typeof(MainProfile).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediaValet.OrderSupervisor", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediaValet.OrderSupervisor v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
