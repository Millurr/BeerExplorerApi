using BeerExplorerApi.Models;
using BeerExplorerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// This code snippet configures the BeerExplorerDatabaseSettings using the configuration 
// settings from "BeerExplorerDatabase". It also adds controllers with custom JSON 
// serialization options that disable property naming policy.
builder.Services.Configure<BeerExplorerDatabaseSettings>(builder.Configuration.GetSection("BeerExplorerDatabase"));
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddSingleton<IItemService<Beer>, BeerService>();

// Add services to the container.
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

app.MapControllers();

app.Run();
