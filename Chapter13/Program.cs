using Chapter13.Services;

namespace Chapter13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            builder.Services.AddSingleton<WorkoutService>();
            builder.Services.AddSingleton<FitnessGoalService>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthorization();

            app.UseCors("AllowAllOrigins");

            app.MapControllers();

            app.Run();
        }
    }
}
