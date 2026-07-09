using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.Auth_.Create;

public class Login 
(
    IOrganizationService organizationService,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        if(!organizationService.TryGet(o => o.Email == request.Email, out var organization))
            throw new UnauthorizedEx("Login failed. Incorrect password or e-mail");
        if(!passwordService.Compare(request.Password, organization.Password))
            throw new UnauthorizedEx("Login failed. Incorrect password or e-mail");
            
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = organization.Id,
                Role = Role.Organization,
                Email = organization.Email
            }
        );

        return tokenPayload;
    }
}
