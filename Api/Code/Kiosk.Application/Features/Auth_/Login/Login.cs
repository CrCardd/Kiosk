using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Domain.Common.Enums;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Common.Exceptions.Exceptions;

namespace Kiosk.Application.Features.Auth_.Create;

public class Login 
(
    IUserService userService,

    IPasswordService passwordService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        if(!userService.TryGet(o => o.Email == request.Email, out var user))
            throw new UnauthorizedEx("Login failed. Incorrect password or e-mail");
        if(!passwordService.Compare(request.Password, user.Password))
            throw new UnauthorizedEx("Login failed. Incorrect password or e-mail");
            
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                UserId = user.Id,
                Email = user.Email,
                TokenType = TokenType.User,
                TokenPurpose = TokenPurpose.Access,
            }
        );

        return tokenPayload;
    }
}
