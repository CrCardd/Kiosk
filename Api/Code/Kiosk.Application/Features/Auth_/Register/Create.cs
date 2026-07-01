using Kiosk.Application.Common.Enums;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.Auth_.Register;

public class Create(
    IOrganizationService service,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(CreatePayload request, CancellationToken cancellationToken)
    {
        var responseGetByName = await service.GetByName(request.Name, cancellationToken);
        if(responseGetByName.IsSuccess)
            return new ConflictEx("An organization with this name already exists.");
        
        request.Password = passwordService.Hash(request.Password);
        var responseCreate = await service.Create(request, cancellationToken);
        if(!responseCreate.IsSuccess)
            return new InternalServerErrorEx("Somenthing went wrong, sorry...");

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = responseCreate.Value.Id,
                Role = Role.Organization
            }
        );

        return tokenPayload;
    }
}
