using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;
using Infosys.TravelAwayWebServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<TravelAwayDBContext>();
builder.Services.AddTransient<LoginRepository>(
    c => new LoginRepository(c.GetRequiredService<TravelAwayDBContext>()));
builder.Services.AddTransient<RegisterUserRepositiory>(
    c => new RegisterUserRepositiory(c.GetRequiredService<TravelAwayDBContext>()));
builder.Services.AddTransient<PackageDetailsRepository>(
    c => new PackageDetailsRepository(c.GetRequiredService<TravelAwayDBContext>()));
builder.Services.AddTransient<PackageRepository>(
    c => new PackageRepository(c.GetRequiredService<TravelAwayDBContext>()));
builder.Services.AddTransient<BookPackageRepository>(
    c => new BookPackageRepository(c.GetRequiredService<TravelAwayDBContext>()));
builder.Services.AddTransient<ReportsRepository>(
    c => new ReportsRepository(c.GetRequiredService<TravelAwayDBContext>()));


// TokenService
builder.Services.AddSingleton<TokenService>();

// Configure JWT authentication
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (!string.IsNullOrEmpty(jwtKey))
{
    var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateLifetime = true,
            ClockSkew = System.TimeSpan.FromMinutes(2)
        };
    });
}
else
{
    // Optional: log a warning that JWT key is missing
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//test