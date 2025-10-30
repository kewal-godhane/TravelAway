using Infosys.TravelAwayDAL.Models;
using Infosys.TravelAwayDAL.TravelAwayRepository;

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

app.UseAuthorization();

app.MapControllers();

app.Run();

//test