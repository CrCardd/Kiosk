namespace Kiosk.Api.Controllers.Api;

public record ApiResponse<T>
{
    public required T? Value {get;init;}
    public required bool Ok {get;init;}
    public string Message {get;init;} = "";
}