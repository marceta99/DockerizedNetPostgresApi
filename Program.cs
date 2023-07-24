using DockerizedNetPostgresApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
//var connectionString = "User ID=postgres;Password=postgres;Server=baza_aplikacija;Port=5432;Database=novaBaza;IntegratedSecurity=true;Pooling=true;";
//var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
var connectionString = "Host=localhost;User ID=admin;Password=admin;Port=5432;Database=novaBaza;IntegratedSecurity=true;Pooling=true;";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});


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

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApiDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

