using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EasyShopWeb_Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app"); // Add the root component like VueJs where we have to load the component to the builder => #app in a css file in wwwroot folder
builder.RootComponents.Add<HeadOutlet>("head::after");

// Only 1 client service using HTTP will retrieve data
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

