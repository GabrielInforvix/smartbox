
using Microsoft.EntityFrameworkCore;
using SmartBox.DB;
using SmartBox.Repositorios;
using SmartBox.Repositorios.Interfaces;

namespace smartbox
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

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SmartBoxDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUsuariosRepositorio, UsuarioRepository>();
            builder.Services.AddScoped<IBoxesRepository, BoxesRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IColumnsRepository, ColumnsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
