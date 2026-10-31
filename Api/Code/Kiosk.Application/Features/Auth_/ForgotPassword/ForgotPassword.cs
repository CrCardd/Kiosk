using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Email;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;

namespace Kiosk.Application.Features.Auth_.ForgotPassword;

public class ForgotPassword 
(
    IUserService userService,

    IEmailService emailService,
    IJwtService jwtService
) : BaseFeature
{
    public async Task<Result> ExecuteAsync(string email, CancellationToken cancellationToken)
    {
        if(!userService.TryGet(o => o.Email == email, out var user))
            throw new NotFoundEx("Email not found");

        var orgEmail = Environment.GetEnvironmentVariable("RESEND_EMAIL");
        if(orgEmail is null)
            throw new Exception(
                $"""
                    RESEND_EMAIL environment  
                    variable was not setted!
                """ 
            );       
        
        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                UserId = user.Id,
                Email = user.Email,
                TokenType = TokenType.User,
                TokenPurpose = TokenPurpose.Password,
            },
            5
        );

        await emailService.SendPasswordEmail(
            new PasswordPayload
            {
                From = orgEmail,
                To = email,
                Subject = "Recover Password",
                Token = tokenPayload,
                Minutes = 5
            },
            cancellationToken
        );

        return Result.Ok();
    }
}
