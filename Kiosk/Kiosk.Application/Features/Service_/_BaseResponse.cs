namespace Kiosk.Application.Features;


public record BaseResponse(
    bool Successfull,
    string? Reason,
    bool EmptyBody,
    object? Value
)
{
    public static BaseResponse<T> Success<T>(T value)
        => new(true, null, value);
    
    public static BaseResponse Success()
        => new(true, null, true, null);
    
    public static BaseResponse Fail(string reason)
        => new(false, reason, false, null);
}

public record BaseResponse<T>(
    bool Successfull,
    string? Reason,
    T? Value
)
{
    public static BaseResponse<T> Success()
    {
        try
        {
            var value = Activator.CreateInstance<T>();
            return Success(value);
        }
        catch
        {
            throw new Exception(
                """
                A função Success vazia só pode ser chamada se o
                Response for vazio, como este:
                """
            );
        }
    }

    public static BaseResponse<T> Success(T value)
        => new(true, null, value);
    
    public static BaseResponse<T> Fail(string? reason = null)
        => new(false, reason, default);
}