using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Firmovac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Load site config
            Utils.LoadConfig();

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorPagesOptions(o =>
            {
                o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            // Save configs on exit
            app.Lifetime.ApplicationStopped.Register(() => {
                Utils.SaveConfig();
            });

            app.Run();
        }

    }
}