using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Models;

public class UserSegmentModel : BaseModelWithSegment
{
    //================PROPERTIES================
    public required SegmentRole Roles {get;set;}
    //================MY-RELATIONS================
    public required UserModel User {get;set;}
    public required Guid UserId {get;set;}
    //================RELATIONS================
}