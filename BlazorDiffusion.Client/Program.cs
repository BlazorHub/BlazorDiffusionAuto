using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDiffusion.Client;
using BlazorDiffusion.Client.UI;
using Ljbc1994.Blazor.IntersectionObserver;
using ServiceStack.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

// Use / for local or CDN resources
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress;
builder.Services.AddBlazorApiClient(apiBaseUrl);
builder.Services.AddLocalStorage();
builder.Services.AddScoped<KeyboardNavigation>();
builder.Services.AddScoped<UserState>();
builder.Services.AddIntersectionObserver();

await builder.Build().RunAsync();
