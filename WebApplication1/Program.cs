using Core;
using Core.Services;
using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddTransient<IGenreService, GenreService>();
services.AddTransient<IAuthorService, AuthorService>();
services.AddTransient<IBookService, BookService>();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
