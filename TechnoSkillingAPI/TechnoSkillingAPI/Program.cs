using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.Infra;
using TechnoSkillingAPI.Repo;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            var config = builder.Configuration;
            builder.Host.AddSerilog();
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey= ConfigValueReader.GetKey(config),
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ConfigValueReader.GetIssuer(config),
                    ValidAudience = ConfigValueReader.GetIssuer(config)
                };
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IConfiguration>(config);
            builder.Services.AddScoped<TechnoSkillingDbContext>();
           
            builder.Services.AddRepo<BlogCategoryRequestDTO, BlogCategoryResponseDTO>(typeof(TechnoSkillingAPI.Repo.BlogCategoryRepo));
            builder.Services.AddRepo<BlogPostRequestDTO, BlogPostResponseDTO>(typeof(TechnoSkillingAPI.Repo.BlogPostRepo));
            builder.Services.AddRepo<GallaryRequestDTO, GallaryResponseDTO>(typeof(TechnoSkillingAPI.Repo.GallaryRepo));

            builder.Services.AddCors(act =>
            {
                act.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("OnlyAdmin", pol =>
                {
                    pol.RequireRole("Admin");
                });
            });
            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAll");

            app.MapControllers();

            app.Run();
        }
    }
}
