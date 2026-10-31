namespace Kiosk.Domain.Common.Enums;

public enum SegmentRole
{
    Owner = 1 << 0,
    Admin = 1 << 1,
    Agent = 1 << 2,
    Chef = 1 << 3,
}