using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Authentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {

                var policy = new AuthorizationPolicyBuilder()

                .RequireAuthenticatedUser()

                .Build();

                options.Filters.Add(new AuthorizeFilter(policy));

            });


            #region Cookie Authentication
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{

            //    options.LoginPath = "/Account/Login";

            //    options.AccessDeniedPath = "/Account/AccessDenied";

            //    options.ExpireTimeSpan = TimeSpan.FromDays(5);

            //});


            #endregion

            #region JWT

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

              .AddJwtBearer(options =>

              {

                  options.TokenValidationParameters = new TokenValidationParameters

                  {

                      ValidateIssuerSigningKey = true,

                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")),

                      ValidateIssuer = true,

                      ValidateAudience = true,

                      ValidIssuer = "YourIssuer",

                      ValidAudience = "YourAudience",

                      ClockSkew = TimeSpan.Zero  // Reduce default clock skew to immediate token expiration handling 

                  };

              });
            #endregion

            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));

            });

            builder.Services.AddHsts(options =>
            {

                options.Preload = true;

                options.IncludeSubDomains = true;

                options.MaxAge = TimeSpan.FromDays(365); // Adjust based on your requirements 

            });

            builder.Services.Configure<KestrelServerOptions>(options =>
            {

                options.ConfigureHttpsDefaults(httpsOptions =>

                {

                    httpsOptions.ServerCertificate = LoadCertificate(); // Method to load your certificate 

                });

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static X509Certificate2? LoadCertificate()
        {
            throw new NotImplementedException();
        }
    }
}
