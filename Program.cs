
using FirstDotNetApi.Data;
using FirstDotNetApi.Repositorios;
using FirstDotNetApi.Repositorios.Interfaces;

namespace FirstDotNetApi;

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

        /* builder.Services.AddIdentityFrameworkSqlServer()
            .AddDbContext<SistemaTarefasDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            ); se estiver usando sqlserver */
        builder.Services.AddDbContext<SistemaTarefasDBContext>();
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); //Injeção de dependência
        builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>(); //Injeção de dependência

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
