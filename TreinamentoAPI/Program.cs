using Microsoft.EntityFrameworkCore;
using TreinamentoAPI.Data;
using TreinamentoAPI.Repositorios;
using TreinamentoAPI.Repositorios.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<TreinamentoAPIDBContext>(
        options => options.UseNpgsql(
            builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IExercicioRepositorio, ExercicioRepositorio>();

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
