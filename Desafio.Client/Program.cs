using Desafio.Client;
using Desafio.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddHttpClient<ICityRepository, CityRepository>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5079/api/City/");
});

await builder.Build().RunAsync();
