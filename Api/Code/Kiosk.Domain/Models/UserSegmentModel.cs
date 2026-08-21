using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Models;

public class UserSegmentModel : BaseModel
{
    //================PROPERTIES================
    public required SegmentRole Roles {get;set;}
    //================MY-RELATIONS================
    public required SegmentModel Segment {get;set;}
    public required Guid SegmentId {get;set;}
    public required UserModel User {get;set;}
    public required Guid UserId {get;set;}
    //================RELATIONS================
}