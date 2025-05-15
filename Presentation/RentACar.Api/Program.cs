using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentAcar.Application.Services.CarServices;
using RentAcar.Application.Services.RentedCarServices;
using RentAcar.Application.Services.UserServices;
using RentAcar.Persistence.Context;
using RentAcar.Persistence.Repositories.CarRepositories;
using RentAcar.Persistence.Repositories.RentedCarRepositories;
using RentAcar.Persistence.Repositories.UserRepositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Token�� kim verdi? (Senin API)
            ValidateAudience = true, //Token�� kim kullanacak ?
            ValidateLifetime = true, // Token s�resinin ge�erlili�ini kontrol et
            ValidateIssuerSigningKey = true, // Token��n imzas�n� kontrol et
            ValidIssuer = builder.Configuration["Jwt:Issuer"], //
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddDbContext<RentCarDbContext>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarServices, CarServices>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IRentedCarRepository, RentedCarRepository>();
builder.Services.AddScoped<IRentedCarServices, RentedCarServices>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
// Authentication middleware must be placed before Authorization middleware
app.UseAuthorization();

app.MapControllers();

app.Run();
