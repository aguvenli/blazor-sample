using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sotsera.Blazor.Toaster.Core.Models;
using System.Globalization;
using WWI.Warehouse.Audit.Client;
using WWI.Warehouse.Audit.Client.Localization;
using WWI.Warehouse.Audit.Client.Localization.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WWI.Warehouse.Audit.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();


builder.Services.AddHttpClient("StaticFileHttpClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WWI.Warehouse.Audit.ServerAPI"));


builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://407efac1-1569-4dba-828a-302dd2a77130/Wharehouse.Audit.Access");
    options.ProviderOptions.LoginMode = "redirect";
});


builder.Services.AddSingleton<IExtendedStringLocalizer, LocalizationProvider>();

builder.Services.AddTelerikBlazor();
builder.Services.AddToaster(config =>
{
    //example customizations
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
    config.ShowTransitionDuration = 500;
    config.HideTransitionDuration = 500;
    config.MaximumOpacity = 100;
    config.ShowCloseIcon = false;
    config.ShowProgressBar = false;
});

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var httpClient = serviceScope.ServiceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("StaticFileHttpClient");
    var localizer = serviceScope.ServiceProvider.GetRequiredService<IExtendedStringLocalizer>();
    await localizer.LoadCatalogs(httpClient, new List<string>() { "en-US", "nl-NL" });
}

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nl-NL");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("nl-NL");

await app.RunAsync();
