using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services.Client;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services;

namespace Kiosk.Application.Features.AuthCode_.Validate;

public class Validate(
    IAuthCodeClientService authCodeService,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(ValidateRequest request, CancellationToken cancellationToken)
    {   
        if(!authCodeService.TryGet(ac => ac.Email == request.Email, out var authCode))
            throw new BadRequestEx("Inconsistent email, the email must be the same that receive the verification code");

        if(!passwordService.Compare(request.Code, authCode.Code))
            throw new BadRequestEx("Incorrect verification code!");

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                SegmentId = Guid.Empty,
                Email = request.Email,
                TokenTypes = [TokenType.Register],
            }
        );

        return tokenPayload;
    }
}
