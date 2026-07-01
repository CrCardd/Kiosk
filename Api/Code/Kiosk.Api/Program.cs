using Kiosk.Api.Common.Convert;
using Kiosk.Api.Config;
using Kiosk.Application.Config;
using Kiosk.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDb();
builder.Services.ConfigureServices();
builder.Services.ConfigureFeatures();
builder.Services.ConfigureJwt();
builder.Services.ConfigureException();

builder.Services.AddControllers(options => options.Filters.Add<ResultFilterAttribute>());



var app = builder.Build();
app.ConfigureException();
app.MapControllers();
await app.Migrate();
app.Run();
