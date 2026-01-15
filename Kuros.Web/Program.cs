using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Kuros.Web;
using Kuros.Web.Services;
using MudBlazor.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure MudServices
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
});

// Configure dark theme
var theme = new MudTheme()
{
    PaletteDark = new PaletteDark
    {
        Primary = "#64b5f6",
        Secondary = "#ba68c8",
        Surface = "#1e1e2e",
        Background = "#121212",
        AppbarBackground = "#1e1e2e",
    },
    Typography = new Typography
    {
        Default = new DefaultTypography
        {
            FontFamily = new[] { "Segoe UI", "sans-serif" },
            FontSize = ".875rem",
        }
    }
};

builder.Services.AddScoped<MudTheme>(sp => theme);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5076/") });
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
