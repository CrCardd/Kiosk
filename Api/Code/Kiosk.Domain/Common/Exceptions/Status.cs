
namespace Kiosk.Domain.Common.Enums;

public enum Status
{
    Ok = 200,
    Created = 201,

    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Conflict = 409,
    ImATeapot = 418,
    InternalServerError = 500,
    NotImplemented = 501,
}
