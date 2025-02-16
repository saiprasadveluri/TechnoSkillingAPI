
using Microsoft.EntityFrameworkCore;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.Infra;
using TechnoSkillingAPI.Repo;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;

namespace TechnoSkillingAPI
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
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped<TechnoSkillingDbContext>();
            builder.Services.Inject<BlogCategoryRequestDTO, BlogCategoryResponseDTO>(typeof(TechnoSkillingAPI.Repo.BlogCategoryRepo));
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
