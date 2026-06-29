using Kiosk.Application.Payloads.Code;
using Kiosk.Application.Services;
using Kiosk.Domain.Utils;

namespace Kiosk.Application.Features.Auth_;

public class StartToken(
    ICodeService service
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(Guid organizationId, CancellationToken cancellationToken)
    {
        DateTime endDate;
        try
        {
          var hours = int.Parse(Environment.GetEnvironmentVariable("TOKEN_CODE_DURATION")!);
          endDate = DateTime.UtcNow.AddHours(hours);
        }
        catch
        {
            endDate = DateTime.MaxValue;
        }
        

        var payload = new CreatePayload
        {
            Code = RandomCodeGenerator.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8),
            OrganizationId = organizationId,
            StartDate = DateTime.UtcNow,
            EndDate = endDate
        };
        var response = await service.Create(payload, cancellationToken);
        if(!response.IsSuccess)
            return "Something went wrong. sorry :(." + payload.OrganizationId;

        return new GetTokenPayload{Token = response.Value.Code};
    }
}