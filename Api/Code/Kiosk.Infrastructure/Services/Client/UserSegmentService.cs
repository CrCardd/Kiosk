using Kiosk.Application.Payloads.UserSegment;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;

namespace Kiosk.Infrastructure.Services.Client;

public class UserSegmentService(
    KioskContext context
) : BaseService<UserSegmentModel, GetPayload>(context, "userSegment"), 
    IUserSegmentService
{
}