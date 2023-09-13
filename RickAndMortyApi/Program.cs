using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Newtonsoft.Json;
using RickAndMortyApi;
using System.Diagnostics;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Conexión a la API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/") });

await builder.Build().RunAsync();
