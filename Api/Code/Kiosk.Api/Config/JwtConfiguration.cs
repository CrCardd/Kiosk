using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Kiosk.Application.Config; 

public static class JwtConfiguration 
{ 
    public static void ConfigureJwt(this WebApplicationBuilder builder) 
    {
        var jwtSecret = Environment.GetEnvironmentVariable("INTERNAL_JWT_KEY");
        var keyBytes = Encoding.UTF8.GetBytes(jwtSecret!);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

      builder.Services.AddAuthorization();
    }
}