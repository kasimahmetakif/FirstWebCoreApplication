using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;
using FirstWebCoreApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /////////////////////////// Eklediðimiz kýsým ///////////////////////////
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection")));
            
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            /////////////////////////// Eklediðimiz kýsým ///////////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}