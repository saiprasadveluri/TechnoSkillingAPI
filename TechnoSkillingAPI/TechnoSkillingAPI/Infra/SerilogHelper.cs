using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
namespace TechnoSkillingAPI.Infra
{
    public static class SerilogHelper
    {
        public static void AddSerilog(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
                    configuration.ReadFrom.Configuration(context.Configuration));            
        }
    }
}
