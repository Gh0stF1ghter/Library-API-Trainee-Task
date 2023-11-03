using Core;
using Core.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using System.Text;
using Core.Models.Auth;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddDbContext<LibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Data")));

services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<LibraryContext>()
    .AddDefaultTokenProviders();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

services.AddTransient<IAuthentication, Authentication>();

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddTransient<IGenreService, GenreService>();
services.AddTransient<IAuthorService, AuthorService>();
services.AddTransient<IBookService, BookService>();


services.AddAutoMapper(typeof(Program));

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(s =>
{
    s.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Libary API",
            Description = "A sample of basic API that provides information about books and their authors, genres and ISBN"
        });
});

var app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
