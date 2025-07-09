// using DairyManagement.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using DairyManagement.Common.Extensions;
using DairyManagement.Application.Common.Interfaces;
using DairyManagement.Infrastructure.Repositories;
using DairyManagement.Application.IServices;
using DairyManagement.Application.Services;
using DairyManagement.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<DairyDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DairyDb")));

// Use your extension method
builder.Services.AddDairyDbContext<DairyDbContext>(builder.Configuration);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductService, ProductService>();

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
