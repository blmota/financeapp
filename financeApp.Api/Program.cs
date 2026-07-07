using financeApp.Application;
using financeApp.Infrastructure;
using financeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    var host = builder.Configuration["DB_HOST"]
               ?? throw new InvalidOperationException("DB_HOST não configurado.");

    var port = builder.Configuration["DB_PORT"] ?? "3306";

    var database = builder.Configuration["DB_NAME"]
                   ?? throw new InvalidOperationException("DB_NAME não configurado.");

    var user = builder.Configuration["DB_USER"]
               ?? throw new InvalidOperationException("DB_USER não configurado.");

    var password = builder.Configuration["DB_PASSWORD"]
                   ?? throw new InvalidOperationException("DB_PASSWORD não configurado.");

    var connectionString =
        $"Server={host};Port={port};Database={database};User={user};Password={password};";

    x.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
        {
            mySqlOptions.MigrationsAssembly("financeApp.Api");
        });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();