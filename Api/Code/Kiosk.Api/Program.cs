using Kiosk.Api.Config;
using Kiosk.Application.Config;
using Kiosk.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDb();
builder.Services.ConfigureServices();
builder.Services.ConfigureFeatures();
builder.Services.ConfigureJwt();

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
await app.Migrate();
app.Run();
