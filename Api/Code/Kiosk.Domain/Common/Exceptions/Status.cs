
namespace Kiosk.Application.Common.Enums;

public enum Status
{
    Ok = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Conflict = 409,
    ImATeapot = 418,
    InternalServerError = 500,
    NotImplemented = 501,
}
