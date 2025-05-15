using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentAcar.Application.Services.CarServices;
using RentAcar.Application.Services.RentedCarServices;
using RentAcar.Application.Services.UserServices;
using RentAcar.Persistence.Context;
using RentAcar.Persistence.Repositories.CarRepositories;
using RentAcar.Persistence.Repositories.RentedCarRepositories;
using RentAcar.Persistence.Repositories.UserRepositories;
using RentAcar.Persistence.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region JWT Ayarlarý
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();
#endregion

#region Controller Servisleri
builder.Services.AddControllers(); // <-- Burasý eksikti!
#endregion

#region Veritabaný ve Uygulama Servisleri
builder.Services.AddDbContext<RentCarDbContext>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarServices, CarServices>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IRentedCarRepository, RentedCarRepository>();
builder.Services.AddScoped<IRentedCarServices, RentedCarServices>();

builder.Services.AddScoped<IAuthServices, AuthServices>();
#endregion

#region Swagger Ayarlarý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rent Car Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Örnek: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
#endregion

var app = builder.Build();

#region HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent Car Api v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // JWT burada aktifleþir
app.UseAuthorization();  // [Authorize] attribute buraya dayanýr

app.MapControllers(); // Controller'lar route'lanýr
#endregion

app.Run();
