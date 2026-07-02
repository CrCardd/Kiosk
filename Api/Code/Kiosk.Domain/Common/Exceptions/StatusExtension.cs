using Kiosk.Domain.Common.Enums;

namespace Kiosk.Domain.Common.Exceptions;

public static class StatusExtension
{
    public static int Code(this Status status)
        => (int)status;



    public static bool IsSuccess(this Status status)
        => status.Code() >= 200 && status.Code() < 300;
    public static bool IsError(this Status status)
        => status.Code() >= 400 && status.Code() < 600;
        public static bool IsClientError(this Status status)
            => status.Code() >= 400 && status.Code() < 500;
        public static bool IsServerError(this Status status)
            => status.Code() >= 500 && status.Code() < 600;




    public static bool IsInfo(this Status status)
        => status.Code() >= 100 && status.Code() < 200;
    public static bool IsRedirect(this Status status)
        => status.Code() >= 300 && status.Code() < 400;
    
}