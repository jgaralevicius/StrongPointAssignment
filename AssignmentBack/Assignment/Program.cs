using Assignment.DataAccess;
using Assignment.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var origins = configuration["AllowedOrigins:reactApp"];

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .WithOrigins(origins)
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlite(configuration.GetConnectionString("Default")));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSingleton<ICalculator>(new Calculator());
services.AddSingleton<ICommentsMapper>(new CommentsMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
