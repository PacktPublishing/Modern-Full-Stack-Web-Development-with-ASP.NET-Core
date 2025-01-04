using Asp.Versioning;
using Asp.Versioning.ApiExplorer;

namespace Chapter8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the DI container
            builder.Services.AddControllers();

            // Add API Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            // Add Versioned API Explorer
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // e.g., v1, v2
                options.SubstituteApiVersionInUrl = true;
            });

            // Add Swagger Generator
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure middleware and Swagger UI
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                //app.UseSwaggerUI(options =>
                //{
                //    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                //    foreach (var description in provider.ApiVersionDescriptions)
                //    {
                //        options.SwaggerEndpoint(
                //            $"/swagger/{description.GroupName}/swagger.json",
                //            $"API {description.ApiVersion}"
                //        );
                //    }
                //});
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
