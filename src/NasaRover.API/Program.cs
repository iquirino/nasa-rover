using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using NasaRover.Domain.Business.Rover;
using NasaRover.Infrastructure.Persistence;
using System.Reflection;
using NasaRover.Domain.Business.Terrain;
using NasaRover.API;
using NasaRover.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Rover"));

builder.Services.AddTransient<IRoverRepository, RoverRepository>();
builder.Services.AddTransient<ITerrainRepository, TerrainRepository>();
builder.Services.AddTransient<RoverService>();
builder.Services.AddTransient<TerrainService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rover API",
        Description = "An ASP.NET Core Web API for managing Rover",
        Contact = new OpenApiContact
        {
            Name = "Igor Quirino",
            Url = new Uri("https://github.com/iquirino")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
