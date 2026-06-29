
namespace Iduca.Api.Config;

public static class CorsPolicyConfiguration
{
    public static void ConfigureCorsPolicy(this IServiceCollection service)
    {
        service.AddCors(opt =>
            opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
        ));
    }
}
