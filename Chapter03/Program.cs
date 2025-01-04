using Chapter03.Middlewares;
using Chapter03.Services;
using Microsoft.Extensions.Options;

namespace Chapter03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ILoggingService, FileLoggingService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IAnotherService, AnotherService>();
            builder.Services.AddScoped<IComplexService>(provider =>
            {
                var anotherService = provider.GetRequiredService<IAnotherService>();

                var config = provider.GetRequiredService<IOptions<ServiceConfig>>();

                return new ComplexService(anotherService, config);

            });

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {

                app.UseExceptionHandler("/Home/Error");

            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<CustomLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthorization();
            app.MapControllerRoute(

                name: "default",

                    pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
