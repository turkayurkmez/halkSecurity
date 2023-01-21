using BasicAuth.API.Security;

namespace BasicAuth.API
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

            builder.Services.AddAuthentication("Basic")
                            .AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);

            builder.Services.AddCors(opt =>
                 opt.AddPolicy("allow", cpb =>
                 {
                     cpb.AllowAnyHeader();
                     cpb.AllowAnyMethod();
                     cpb.AllowAnyOrigin();

                     /*
                      * https://www.halkbank.com.tr/
                      * http://www.halkbank.com.tr
                      * https://api.halkbak.com.tr
                      * https://www.halkbank.com.tr:8082
                      */

                 }
           ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("allow");

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}