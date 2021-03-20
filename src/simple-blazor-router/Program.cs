using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using simple_blazor_router.Models;
using simple_blazor_router.Services.TicTakToeApplicationServices;

namespace simple_blazor_router
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ITicTacToeGame, TicTacToeGame>();
            builder.Services.AddScoped<ITicTacToeDiagonalChecker, TicTacToeDiagonalChecker>();
            builder.Services.AddScoped<ITicTacToeHorizontalChecker, TicTacToeHorizontalChecker>();
            builder.Services.AddScoped<ITicTacToeVerticalChecker, TicTacToeVerticalChecker>();

            await builder.Build().RunAsync();
        }
    }
}
