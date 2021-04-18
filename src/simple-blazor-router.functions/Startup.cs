using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using simple_blazor_router.application.WeatherConditions;

[assembly: FunctionsStartup(typeof(simple_blazor_router.functions.Startup))]

namespace simple_blazor_router.functions 
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IWeatherConditionsProvider, WeatherConditionsProvider>();
        }
    }
}