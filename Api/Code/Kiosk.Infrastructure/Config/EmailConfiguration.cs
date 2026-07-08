using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Resend;

namespace Kiosk.Infrastructure.Config;

public static class EmailConfiguration
{
    public static void ConfigureEmail(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<ResendClient>();
        builder.Services.Configure<ResendClientOptions>(o =>
        {
            o.ApiToken = Environment.GetEnvironmentVariable("RESEND_TOKEN")!;
        });
        builder.Services.AddTransient<IResend, ResendClient>();
    }
}