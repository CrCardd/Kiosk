using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Kiosk.Application.Features.Auth_.OAuthProviderLogin;

public class OAuthProviderLogin 
(
    IUserService userService,
    IOAuthProviderService providerService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(ProviderRequest request, CancellationToken cancellationToken)
    {
        var clientId = Environment.GetEnvironmentVariable("OAUTH_CLIENT_ID");
        var settings = new ValidationSettings { Audience = [clientId] };
        Payload payload;
        
        try
        {
            payload = await ValidateAsync(request.IdToken, settings);
        } 
        catch (Exception e)
        {
            throw new UnauthorizedEx("invalid provider account\n" + e.Message);
        }

        var providerType = OAuthProviderTypes.GetProviderType(request.Provider);
        if(providerType == OAuthProviderType.Invalid)
            throw new BadRequestEx("invalid provider type");

        string subject = payload.Subject;
        string email = payload.Email;
        string name = payload.Name;
        string picture = payload.Picture;

    
        Payloads.User.GetPayload user;
        try
        {
            user = userService.Get(o => o.Email == email);
        }
        catch(NotFoundEx)
        {
            user = (await userService.Create(
                new Payloads.User.CreatePayload {
                    Name = name,
                    Email = email,
                    Password = ""
                },
                cancellationToken
            )).Value!;
        }

    
    
        var hasProviderLinked = await providerService.ExistsBySubjectAsync(subject, cancellationToken);
        
        if (!hasProviderLinked)
        {
            await providerService.Create(
                new Payloads.Provider.CreatePayload
                {
                    Name = name,
                    Email = email,
                    Picture = picture,
                    Subject = subject,
                    Type = providerType
                },
                cancellationToken
            );
        }
                
    
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = user.Id,
                Email = email,
                TokenTypes = [TokenType.User],
            }
        );

        return tokenPayload;
    }
}