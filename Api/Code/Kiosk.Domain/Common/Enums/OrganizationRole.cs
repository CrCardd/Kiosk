namespace Kiosk.Domain.Common.Enums;

public enum OrganizationRole
{
    Owner = 1 << 0,
    Admin = 1 << 1,
    Viwer =  1 << 2
}