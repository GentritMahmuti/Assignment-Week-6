using Assignment_Week_6.Data;
using Assignment_Week_6.Helpers;
using Assignment_Week_6.Services.IService;
using Assignment_Week_6.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Assignment_Week_6.Data.Repository;
using Assignment_Week_6.Data.Repository.IRepository;
using StackExchange.Redis;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mapperConfiguration = new MapperConfiguration(
    mc => mc.AddProfile(new AutoMapperConfigurations()));
IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var mp = ConnectionMultiplexer.Connect("localhost");
builder.Services.AddSingleton<IConnectionMultiplexer>(mp);

builder.Services.AddDbContext<LifeDbContext>(options => options.UseSqlite("DataSource=LifeAssignment6"));
builder.Services.AddMemoryCache();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
