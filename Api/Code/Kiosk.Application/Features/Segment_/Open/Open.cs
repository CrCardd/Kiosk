using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Services;
using Kiosk.Application.Services.Auth;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Features.Segment_.Open;

public class Open(
    IJwtService jwtService,

    ISegmentService segmentService,
    IUserSegmentService userSegmentService,
    IUserOrganizationService userOrganizationService
) : BaseFeature
{
    public async Task<Result<GetTokenPayload>> ExecuteAsync(OpenRequest request, CancellationToken cancellationToken)
    {
        var segment = await segmentService.Get(o => o.Id == request.SegmentId, cancellationToken);
        var userSegment = await userSegmentService.Get(
            us => us.SegmentId == request.SegmentId && us.UserId == request.UserId,
            cancellationToken
        );
        
        userOrganizationService.TryGet(uo => uo.OrganizationId == segment.OrganizationId && uo.UserId == request.UserId, out var userOrganization);

        var tokenPayload = jwtService.Generate(
            new CreateTokenPayload
            {
                UserId = request.UserId,
                Email = request.Email,
                SegmentId = userSegment.Id,
                SegmentRole = userSegment.Roles,
                OrganizationId = segment.OrganizationId,
                OrganizationRole = userOrganization?.Roles,
                TokenType = TokenType.User,
                TokenPurpose = TokenPurpose.Access,
            },
            request.ExpiresAt
        );
        return tokenPayload;
    }
}