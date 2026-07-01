using Kiosk.Application.Common.Enums;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.Auth_.StartKiosk;

public class StartKiosk(
    ICodeService service,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(string code, CancellationToken cancellationToken)
    {
        var response = await service.GetAll(cancellationToken);
        if(!response.IsSuccess)
            return new InternalServerErrorEx("Something went wrong. sorry :(");
        var codeEntity = response.Value
            .FirstOrDefault(c => passwordService.Compare(code, c.Code));
        if(codeEntity is null)
            return new UnauthorizedEx("Login failed. Incorrect code");
        if(codeEntity.EndDate < DateTime.UtcNow)
            return new BadRequestEx("Code out of date. Generate a new code");
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = codeEntity.OrganizationId,
                Role = Role.Kiosk
            }
        );

        return tokenPayload;
    }
}
