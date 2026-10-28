using Kiosk.Application.Payloads._Misc;
using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Application.Services.Client;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Email;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Utils;

namespace Kiosk.Application.Features.AuthCode_.CreateAccount;

public class CreateAccount(
    IAuthCodeService service,
    IUserService userService,

    IPasswordService passwordService,
    IEmailService emailService
) : BaseFeature
{
    public async Task<Result> ExecuteAsync(string email, CancellationToken cancellationToken)
    {
        if(userService.TryGet(o => o.Email == email, out var user))
            throw new BadRequestEx("There is already an account for this e-mail");

        var orgEmail = Environment.GetEnvironmentVariable("RESEND_EMAIL");
        if(orgEmail is null)
            throw new Exception(
                $"""
                    RESEND_EMAIL environment  
                    variable was not setted!
                """ 
            );

        var code = RandomCodeGenerator.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8);
        var minutes = int.Parse(Environment.GetEnvironmentVariable("INTERNAL_TOKEN_AUTHCODE_DURATION")!);
        if(orgEmail is null)
            throw new Exception(
                $"""
                    INTERNAL_TOKEN_AUTHCODE_DURATION environment variable
                    was not setted or is in incorrect format!    
                """ 
            );



        var payload = new CreatePayload
        {
            Code = passwordService.Hash(code),
            Email = email,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddMinutes(minutes)
        };

        var authCode = await service.Create(payload, cancellationToken);
        
        await emailService.SendVerificationEmail(
            new VerificationCodePayload
            {
                From = orgEmail,
                To = email,
                Subject = "Verification Code",
                Code = code,
                Minutes = minutes
            },
            cancellationToken
        );

        return Result.Created();
    }
}