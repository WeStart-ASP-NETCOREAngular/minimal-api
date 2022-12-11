using Mapster;
using Microsoft.EntityFrameworkCore;
using MinimalApiIntro.Data;
using MinimalApiIntro.Endpoints;
using MinimalApiIntro.Repositories;
using System.Reflection;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton(config);

builder.Services.AddScoped<IMapper, ServiceMapper>();


builder.Services.AddDbContext<CustomerDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/Customer", async (CustomerDbContext context) =>
{
    return await context.Customers.ToListAsync();
    //return Results.Ok(new { message = "Hello from Minimal Api" });
});

app.MapGet("/api/Customer/{id}", async (int id, ICustomerRepository repo) =>
{
    return await repo.GetCustomerById(id);
});


app.MapCustomerEndpoints();


app.Run();
