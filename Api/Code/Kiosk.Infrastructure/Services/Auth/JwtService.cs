using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Utils;
using Microsoft.IdentityModel.Tokens;

namespace Kiosk.Infrastructure.Services.Auth;

public class JWTService : IJwtService
{
    public GetTokenPayload Generate(CreateTokenPayload payload, int durationMinutes = 120)
    {
        try
        {
            var jwtSecret = Environment.GetEnvironmentVariable("INTERNAL_JWT_KEY");
            var keyBytes = Encoding.UTF8.GetBytes(jwtSecret!);
            var key = new SymmetricSecurityKey(keyBytes);
            
            var claims = new List<Claim>
            {
                new(MyClaims.Email, payload.Email),
            };
            
            foreach(var role in payload.TokenTypes)
                claims.Add(new Claim(MyClaims.TokenType, TokenTypes.GetTokenTypeName(role)));
            
            // segment
            if (payload?.SegmentId is not null)
                claims.Add(new(MyClaims.SegmentId, payload.SegmentId.ToString()!));
            if (payload?.SegmentRole is not null)
                claims.Add(new(MyClaims.SegmentRoles, ((int)payload.SegmentRole).ToString()!));

            // organization
            if (payload?.OrganizationId is not null)
                claims.Add(new(MyClaims.OrganizationId, payload.OrganizationId.ToString()!));
            if (payload?.OrganizationRole is not null)
                claims.Add(new(MyClaims.OrganizationRoles, ((int)payload.OrganizationRole).ToString()!));


            // cart
            if (payload?.CartId is not null)
                claims.Add(new(MyClaims.CartId, payload.CartId.ToString()!));

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(durationMinutes),
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
            throw new Exception(
                $"""
                INTERNAL_JWT_KEY environment variable was 
                not setted or is in incorrect format!
                ${ex}
                """ 
            );
        }
    }
}