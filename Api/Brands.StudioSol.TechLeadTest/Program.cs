using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Brands.StudioSol.TechLeadTest
{
    public class Program
    {
        private const string PORT_ENVIRONMENT_VARIABLE = "PORT";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://*.:{Environment.GetEnvironmentVariable(PORT_ENVIRONMENT_VARIABLE)}");
                });
    }
}
