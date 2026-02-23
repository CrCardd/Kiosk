
namespace Kiosk.Domain.Common.Messages;

public static class ExceptionMessage
{
    public static class BadRequest
    {
        public const string Default = "Bad request";
    }

    public static class DuplicityModel
    {
        public const string Default = "It's already exists!";
    }

    public static class InternalServerError
    {
        public const string Default = "Internal server error";
    }

    public static class NotFound
    {
        public const string Default = "Item not found";
    }
}
