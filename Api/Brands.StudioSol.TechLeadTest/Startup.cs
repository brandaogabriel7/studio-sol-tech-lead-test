using Brands.StudioSol.TechLeadTest.GraphQL;
using Brands.StudioSol.TechLeadTest.Services;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Brands.StudioSol.TechLeadTest
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
            // setup GraphQL
            services.AddGraphQL(builder => builder
                .AddSchema<RomanNumbersSchema>()
                .AddGraphTypes(typeof(RomanNumbersSchema).Assembly)
                .AddSystemTextJson());

            // Inject services
            services.AddSingleton<IRomanNumbersService, RomanNumbersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGraphQLAltair();
            });
        }
    }
}
