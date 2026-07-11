using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Auth_.Register;

public class Create(
    IOrganizationClientService organizationService,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {

        if(organizationService.TryGet(o => o.Email == request.Email, out var responseGetByEmail))
            throw new ConflictEx("An organization with this email already exists.");
            
        
        request.Password = passwordService.Hash(request.Password);
        var responseCreate = await organizationService.Create(request, cancellationToken);
        if(!responseCreate.IsSuccess)
            throw new Exception("Somenthing went wrong, sorry...");

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = responseCreate.Value.Id,
                Email = request.Email,
                Roles = [Role.Organization],
            }
        );

        return tokenPayload;
    }
}
