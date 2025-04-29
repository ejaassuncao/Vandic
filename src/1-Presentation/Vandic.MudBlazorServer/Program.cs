using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.Translations;
using Vandic.CrossCutting.Resources.Configurations;
using Vandic.Data.efcore.Context;
using Vandic.MudBlazorServer.Components;
using Vandic.MudBlazorServer.Components.Resources;
using Vandic.MudBlazorServer.Configurations;

namespace Vandic.MudBlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'VandicMudBlazorServerContext' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add MudBlazor services
            builder.Services.AddMudServices();
            builder.Services.AddMudTranslations();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


           // builder.Services.AddTransient<MudLocalizer, MudLocalizationPtBr>();

            builder.Services.AddVandicServices(builder.Configuration);
            builder.Services.AddLocalization();
            builder.Services.AddVandicResources();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();


            var supportedCultures = new[] { "en-US", "pt-BR", "es" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("pt-BR")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);


            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}
