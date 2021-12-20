using Blazored.LocalStorage;
using Käpy.Business.Services;
using Käpy.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Käpy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage(config =>
            { 
                config.JsonSerializerOptions.WriteIndented = true;
                config.JsonSerializerOptions.DictionaryKeyPolicy = null; // PascalCase
                config.JsonSerializerOptions.PropertyNamingPolicy = null; // PascalCase
                config.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                config.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });


            builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All));

            builder.Services.AddScoped<IGameStateStorageService, LocalStorageGameStateService>();
            builder.Services.AddScoped<IGameManager, GameManager>();


            await builder.Build().RunAsync();
        }
    }
}
