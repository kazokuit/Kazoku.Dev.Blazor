using Kazoku.Dev.Blazor.Models.Configs;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Configurations
var connectionStringsSection = builder.Configuration.GetSection(ConnectionStringsConfig.Key);
builder.Services.Configure<ConnectionStringsConfig>(connectionStringsSection);
var apiUrl = connectionStringsSection["Api"];

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

// Add authorization 
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

// Adds views
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

// Logging
builder.Logging.ClearProviders();
builder.Services.AddLogging(options =>
{
    options.AddSimpleConsole(c =>
    {
        c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
        c.UseUtcTimestamp = false;
    });
});

var app = builder.Build();

if (string.IsNullOrEmpty(apiUrl))
{
    app.Logger.LogError("No API url found, stopping app.");
    app.StopAsync();
}
else
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.Logger.LogWarning("IN DEVELOPMENT MODE, NOT FOR USE IN PRODUCTION.");
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}