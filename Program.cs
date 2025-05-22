using FacturaWilmer.Data;
using FacturaWilmer.Interfaces.IRepositories;
using FacturaWilmer.Interfaces.IServices;
using FacturaWilmer.Mappings;
using FacturaWilmer.Repositories;
using FacturaWilmer.Services;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

//Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

//Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddDbContext<DevLabContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
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

app.UseCors("PermitirAngular");

app.MapControllers();

app.Run();
