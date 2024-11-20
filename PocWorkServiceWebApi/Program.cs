using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace PocWorkServiceWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilderLinear(args).Build();
            app.MapControllers();
            app.UseRouting();
            app.Run();

        }


        public static WebApplicationBuilder CreateHostBuilderLinear(string[] args)
        {
            var host = WebApplication.CreateBuilder(args);
            host.Logging.AddConsole();
            host.Services.AddHostedService<Worker>();
            host.Services.AddControllers();
            host.Host.UseWindowsService();
            return host;

        }

        /***

        // This is by older .net core paradigms, read
        // https://stackoverflow.com/questions/75229793/host-createdefaultbuilder-vs-host-createapplicationbuilder-in-net-platform-exte

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(LoggingBuilderExtensions =>
                    {
                        LoggingBuilderExtensions.AddConsole();
                    });
                    services.AddHostedService<Worker>();

                })

            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        }
        */

    }
}