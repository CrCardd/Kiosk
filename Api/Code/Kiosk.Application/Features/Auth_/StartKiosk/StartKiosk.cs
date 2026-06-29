using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;

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
            return "Login failed. Incorrect code";
        var codeEntity = response.Value
            .FirstOrDefault(c => 
                passwordService.Compare(code, c.Code)
                && DateTime.UtcNow < c.EndDate
            );
        if(codeEntity is null)
            return "Login failed. Incorrect code";
            
        
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
