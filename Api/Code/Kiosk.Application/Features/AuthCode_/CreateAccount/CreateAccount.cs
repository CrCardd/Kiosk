using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Email;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Utils;

namespace Kiosk.Application.Features.AuthCode_.CreateAccount;

public class CreateAccount(
    IAuthCodeService service,

    IJwtService jwtService,
    IPasswordService passwordService,
    IEmailService emailService
) : BaseFeature
{
public async Task<Result<GetTokenPayload>> ExecuteAsync(string email, CancellationToken cancellationToken)
    {
        var orgEmail = Environment.GetEnvironmentVariable("RESEND_EMAIL");
        if(orgEmail is null)
            throw new Exception(
                $"""
                    INTERNAL_TOKEN_AUTHCODE_DURATION environment  
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
        
        await emailService.Send(
            email,
            orgEmail,
            "Verification Code",
            $$$$"""
                <!DOCTYPE html>
                <html lang="en">
                <head>
                    <meta charset="UTF-8">
                    <title>Verification Code</title>
                </head>
                <body style="margin:0;padding:0;background:#f4f4f4;font-family:Arial,Helvetica,sans-serif;">
                    <table width="100%" cellpadding="0" cellspacing="0" style="padding:40px 0;">
                        <tr>
                            <td align="center">
                                <table width="600" cellpadding="0" cellspacing="0" style="background:#ffffff;border-radius:12px;padding:40px;box-shadow:0 4px 16px rgba(0,0,0,.08);">
                                    <tr>
                                        <td align="center">
                                            <h1 style="margin:0;color:#222;">Verify your account</h1>

                                            <p style="margin:24px 0 12px;color:#555;font-size:16px;line-height:1.6;">
                                                Use the verification code below to continue.
                                            </p>

                                            <div style="
                                                display:inline-block;
                                                margin:20px 0;
                                                padding:18px 36px;
                                                background:#f5f7fa;
                                                border:2px dashed #2d7ff9;
                                                border-radius:10px;
                                                font-size:36px;
                                                font-weight:bold;
                                                letter-spacing:10px;
                                                color:#2d7ff9;">
                                                {{{{code}}}}
                                            </div>

                                            <p style="margin:24px 0 0;color:#666;font-size:14px;line-height:1.6;">
                                                This code will expire in <strong>{{{{minutes}}}} minutes</strong>.
                                            </p>

                                            <p style="margin:8px 0 0;color:#666;font-size:14px;line-height:1.6;">
                                                If you didn't request this verification, you can safely ignore this email.
                                            </p>

                                            <hr style="margin:36px 0;border:none;border-top:1px solid #eee;">

                                            <p style="margin:0;color:#999;font-size:12px;">
                                                This is an automated email. Please do not reply.
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>
            """

        );

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                OrganizationId = Guid.Empty,
                Role = Role.Register
            }
        );

        return tokenPayload;
    }
}