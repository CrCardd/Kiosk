using Kiosk.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();
builder.Services.ConfigureFeatures();

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
