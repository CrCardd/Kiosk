using Kiosk.Application.Config;
using Kiosk.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDb();
builder.Services.ConfigureServices();
builder.Services.ConfigureFeatures();

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
