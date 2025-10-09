using Csharp3_A1.Data;
using Csharp3_A1.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Csharp3_A1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            builder.Services.AddAuthentication();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<HospitalService>(); //Register HospitalService
            builder.Services.AddScoped<PatientService>(); //Register PatientService
            builder.Services.AddScoped<StaffService>(); //Register StaffService
            builder.Services.AddScoped<NewsService>(); //Register NewsService
            builder.Services.AddScoped<AccountService>(); //Register AccountService

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                await DemoData.InitializeAsync(scope.ServiceProvider);
            }

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

			app.UseAuthentication();
			app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
