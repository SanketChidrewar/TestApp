using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Repositories.Implementation;
using TestApp.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TestAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestApp"), builder =>
    {
        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

