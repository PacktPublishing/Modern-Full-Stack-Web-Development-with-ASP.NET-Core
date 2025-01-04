namespace Chapter12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSpaStaticFiles(configuration =>
            {
#if DEBUG
                configuration.RootPath = "ClientApp";
#else
                configuration.RootPath = "ClientApp/dist/spa";
#endif
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalDevelopmentOrigin",
                    policy => policy.WithOrigins("http://localhost:8080")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });


            app.UseCors("AllowLocalDevelopmentOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}
