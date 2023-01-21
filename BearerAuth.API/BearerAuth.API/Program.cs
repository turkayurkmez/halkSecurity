using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BearerAuth.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(config =>
                            {
                                config.TokenValidationParameters = new TokenValidationParameters()
                                {
                                    ValidateAudience = false,
                                    ValidateIssuer = false,
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bu gizli bir cumle")),
                                    ValidIssuer = "api.halkbank.com.tr",
                                    ValidAudience = "client.halkbank.com.tr", //ValidateAudience ve ValidateIssuer değerleri true ise ValidIssuer ve ValidAudience'i belirtmek zorundasınız,
                                    ValidateIssuerSigningKey = true
                                };
                            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (context, next) =>
            {
                if (!context.Response.Headers.ContainsKey("X-Frame-Options"))
                {
                    context.Response.Headers.Add("X-Frame-Options", "DENY");
                    //https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Headers_Cheat_Sheet.html
                }
                await next();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}