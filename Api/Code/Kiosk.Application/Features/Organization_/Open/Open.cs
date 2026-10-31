using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Features.Organization_.Open;

public class Open(
    IJwtService jwtService,

    IOrganizationService organizationService,
    IUserOrganizationService userOrganizationService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(OpenRequest request, CancellationToken cancellationToken)
    {
        var organization = await organizationService.Get(o => o.Id == request.OrganizationId, cancellationToken);
        var userOrganization = await userOrganizationService.Get(
            uo => uo.OrganizationId == request.OrganizationId && uo.UserId == request.UserId,
            cancellationToken
        );

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                UserId = request.UserId,
                OrganizationId = request.OrganizationId,
                OrganizationRole = userOrganization.Roles,
                Email = request.Email,
                TokenType = TokenType.User,
                TokenPurpose = TokenPurpose.Access,
            },
            request.ExpiresAt
        );
        return tokenPayload;
    }
}