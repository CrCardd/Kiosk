using Kiosk.Api.Common.Convert;
using Kiosk.Api.Config;
using Kiosk.Application.Config;
using Kiosk.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDb();
builder.ConfigureServices();
builder.ConfigureFeatures();
builder.ConfigureJwt();
builder.ConfigureException();
builder.ConfigureEmail();

builder.Services.AddControllers(options => options.Filters.Add<ResultFilterAttribute>());



var app = builder.Build();
app.ConfigureException();
app.MapControllers();
await app.Migrate();
app.Run();
