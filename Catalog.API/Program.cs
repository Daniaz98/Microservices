using Catalog.API.Data;
using Catalog.API.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var mongoConnectionString = builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString");

// Configuração do MongoClient
var mongoClient = new MongoClient(mongoConnectionString);
//var database = mongoClient.GetDatabase("CatalogDb");
builder.Services.AddSingleton(mongoClient);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ICatalogContext>();

    try
    {
        CatalogContextSeed.SeedData(context.Products);
        Console.WriteLine("Banco de dados inicializado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERRO ao inicializar o banco de dados: {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.RoutePrefix = "swagger";
        //Injetando o css nas configurações do swagger
        s.InjectStylesheet("/swagger.css");
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Api");
    });
    app.UseStaticFiles();
}

app.MapControllers();

app.Run();

