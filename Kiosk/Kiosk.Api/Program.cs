using Kiosk.Application.Config;
using Kiosk.Persistence.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDb();
builder.Services.ConfigureServices();
builder.Services.ConfigureFeatures();

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
