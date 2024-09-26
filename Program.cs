using ModuloAPI.Context; // Importamos
using Microsoft.EntityFrameworkCore; // Importamos

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"))); // Falando que o AgendaContext.cs vai usar a string de conexão do JSON

// AddDbContext<AgendaContext>: Adiciona um dbContext do tipo AgendaContext
// options => options.UseSqlServer: Passa as opções e usa o SQL Server (se fosse MYSQL seria UseMsql)
// builder.Configuration: Pega as configurações do appsettings.Development.json
// GetConnectionString: Pega a chave ConnectionStrings
// "ConexaoPadrao": Acessa o valor da chave ConnectionStrings: "ConexaoPadrao"


builder.Services.AddControllers(); // Adiciona controladores
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

// Mapeia controladores
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
