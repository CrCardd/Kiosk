using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.AuthCode_.Validate;

public class Validate(
    IAuthCodeService authCodeService,

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
                OrganizationId = Guid.Empty,
                Email = request.Email,
                Role = Role.Register,
            }
        );

        return tokenPayload;
    }
}
