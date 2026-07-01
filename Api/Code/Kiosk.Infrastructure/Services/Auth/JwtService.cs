using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kiosk.Application.Common.Enums;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Utils;
using Microsoft.IdentityModel.Tokens;

namespace Kiosk.Infrastructure.Services.Auth;

public class JWTService : IJwtService
{
    public Result<GetTokenPayload> Generate(CreateTokenPayload payload, int durationHours = 2)
    {
        try
        {
            var jwtSecret = Environment.GetEnvironmentVariable("JWT_KEY");
            var keyBytes = Encoding.UTF8.GetBytes(jwtSecret!);
            var key = new SymmetricSecurityKey(keyBytes);
            
            var jwt = new JwtSecurityToken(
                claims: [
                    new Claim(MyClaims.OrganizationId, payload.OrganizationId.ToString()),
                    new Claim(MyClaims.Role, Roles.GetRoleName(payload.Role)),
                ],
                expires: DateTime.UtcNow.AddHours(durationHours),
                signingCredentials: new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256Signature
                )
            );
            var handler = new JwtSecurityTokenHandler();
            return new GetTokenPayload{Token = handler.WriteToken(jwt)};
        }
        catch(Exception ex)
        {
            throw new InternalServerErrorEx(
                $"""
                JWT_KEY environment variable was 
                not setted or is in incorrect format!
                ${ex}
                """ 
            );
        }
    }
}