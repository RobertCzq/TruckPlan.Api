using TruckPlan.Api.ApiClient;
using TruckPlan.Api.ApiClient.Interfaces;
using TruckPlan.Api.Data;
using TruckPlan.Api.Data.Interfaces;
using TruckPlan.Api.Services;
using TruckPlan.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataStore, DataStore>();
builder.Services.AddScoped<IAgeCalculatorService, AgeCalculatorService>();
builder.Services.AddScoped<IDistanceCalculatorService, DistanceCalculatorService>();
builder.Services.AddScoped<ITruckPlanService, TruckPlanService>();
builder.Services.AddHttpClient<IGeonamesApiClient, GeonamesApiClient>(c =>
{
    var baseAddress = builder.Configuration.GetSection("GeonamesApi");
    c.BaseAddress = new Uri(baseAddress.Value);
});

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
