using Kiosk.Application.Common.Enums;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.Auth_.Create;

public class Login 
(
    IOrganizationService service,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        Result<GetPayload> response;
        response = await service.GetByName(request.Login, cancellationToken);
        if(!response.IsSuccess)
            return new UnauthorizedEx("Login failed. Incorrect password or e-mail");
        if(!passwordService.Compare(request.Password, response.Value.Password))
            return new UnauthorizedEx("Login failed. Incorrect password or e-mail");
            
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = response.Value.Id,
                Role = Role.Organization
            }
        );

        return tokenPayload;
    }
}
