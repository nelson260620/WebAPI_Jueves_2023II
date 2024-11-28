using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using ShoppingAPI_Jueves_2023II.DAL;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;
using ShoppingAPI_Jueves_2023II.Domain.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//linea de codigo para configurar la conexion a la BD
builder.Services.AddDbContext<DataBaseContext>(Options=> Options.UseSqlServer(builder.Configuration.GetConnectionString
    ("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//contenedor de dependencias
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddTransient<SeederDB>();

//builder.Services.AddTransient<ICountryService, CountryService>();
//builder.Services.AddSingleton<ICountryService, CountryService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeederData();
void SeederData()
{
    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }

}


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
