namespace Kiosk.Api.Controllers.Api;

public interface IApiResponse<T>
{
    T? Value {get;}
    bool Ok {get;}
    string Message {get;}
}
public record ApiResponse : IApiResponse<bool?>
{
    public bool? Value => null;

    public required bool Ok {get;init;}
    public required string Message {get;init;}
}
public record ApiResponse<T> : IApiResponse<T>
{
    public required T? Value {get;init;}
    public required bool Ok {get;init;}
    public string Message {get;init;} = "";
}