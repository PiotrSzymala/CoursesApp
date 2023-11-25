using System.Text;
using AplikacjaMetodyki.Data;
using AplikacjaMetodyki.IoC;
using AplikacjaMetodyki.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AplikacjaMetodyki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region EF core - DbContext registrations
            builder.Services.AddTransient<MsSqlAppDbContextConnectionString>();
            builder.Services.AddDbContext<ApplicationDbContext>((sp, o) =>
            {
                var connectionString = sp.GetRequiredService<MsSqlAppDbContextConnectionString>().Value;
                o.UseSqlServer(connectionString);
            });
            #endregion
            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            #region Connector Database migrations
            app.UseDatabaseMigrations();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}