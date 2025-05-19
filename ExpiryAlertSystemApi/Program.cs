using Infra.Models;
using Infra.Services.Classes;
using Infra.Services.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PerishableAlertOptions>(
     builder.Configuration.GetSection("PerishableService")
    );

builder.Services.AddScoped<IPerishableProductService>(sp => { 

    var options = sp.GetRequiredService<IOptions<PerishableAlertOptions>>().Value;
    return new PerishableProductService(options.FilePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/expiry-alerts",async Task<IResult> (IPerishableProductService perishableProductService, int daysThreshold = 7) =>
{
    var perishableProducts =  await perishableProductService.GetExpiryAlertsAsync(daysThreshold);
    return Results.Ok(perishableProducts);
})
.WithName("expiry-alerts")
.WithOpenApi();

app.Run();
