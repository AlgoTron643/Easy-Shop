using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EasyShop_Web_Server.Data;

var builder = WebApplication.CreateBuilder(args); // Can pass in args from command line

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build(); // We will build the builder

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // We will use the developer exception pages
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting(); // Default routing with .NET CORE or .NET routing

// Add the endpoint for the razor
// We are adding or configuring the signalR connection (talks to the main application that is running informing changes specially on the UI making it responsive like JS) for our Blazor application
app.MapBlazorHub(); // Add BlazorHub to the default path, configures everything for you
app.MapFallbackToPage("/_Host"); // If it does not find anything else to route, then look for a page in "_Host.cshtml" from Pages and see routing in action

app.Run();

