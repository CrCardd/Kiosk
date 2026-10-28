using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Auth_.StartKiosk;

public class StartKiosk(
    ICodeService codeService,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(string code, CancellationToken cancellationToken)
    {
        var response = await codeService.GetAll(cancellationToken);
        if(!response.IsSuccess)
            throw new Exception("Something went wrong. sorry :(");
        var codeEntity = response.Value
            .FirstOrDefault(c => passwordService.Compare(code, c.Code));
        if(codeEntity is null)
            throw new UnauthorizedEx("Login failed. Incorrect code");
        if(codeEntity.EndDate < DateTime.UtcNow)
            throw new BadRequestEx("Code out of date. Generate a new code");
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                SegmentId = codeEntity.Segment.Id,
                TokenTypes = [TokenType.Kiosk],
            }
        );

        return tokenPayload;
    }
}
