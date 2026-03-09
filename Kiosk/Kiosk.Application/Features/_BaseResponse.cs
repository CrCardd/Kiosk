// using System.Diagnostics.CodeAnalysis;

// namespace Kiosk.Domain.Services;

// public record Result<T>(
//     bool Ok,
//     string? Message,
//     T? Value
// )
// {
//     [MemberNotNullWhen(true, nameof(Value))]
//     public bool IsSuccess => Ok;
//     public static Result<T> Fail(string message)
//         => new(false, message, default);
//     public static implicit operator Result<T>(string error)
//         => Fail(error);
//     public static implicit operator Result<T>(T value)
//         => new(true, null, value);
// }

// // using System.Reflection;

// // namespace Kiosk.Domain.Services;

// // public record BaseResponse(
// //     bool Successfully,
// //     string? Message,
// //     object? Value,
// //     bool Empty
// // )
// // {
// //     public static BaseResponse<T> Success<T>(T value)
// //     => new(true, null, value, false);
// //     public static BaseResponse Success()
// //     => new(true, null, default, true);
// //     public static BaseResponse Fail(string? message)
// //     => new(false, message, default, true);
// // }


// // public record BaseResponse<T>(
// //     bool Successfully,
// //     string? Message,
// //     T? Value,
// //     bool Empty
// // )
// // {

// //     public static BaseResponse<T> Success(T value)
// //     {
// //         return new(true, null, value, false);
// //     }
// //     public static BaseResponse<T> Success()
// //     {
// //         return new(true, null, default, true);
// //     }
// //     public static BaseResponse<T> Fail(string message)
// //     {
// //         return new(false, message, default, true);
// //     }



// //     public static implicit operator BaseResponse<T>(BaseResponse value)
// //     {
// //         if(!value.Successfully)
// //         {
// //             return Fail(value.Message ?? "Failed without a reason");
// //         }
// //         if(value.Value is T v)
// //         {
// //             var source = v.GetType();
// //             var destin = typeof(T);

// //             var constructor = destin.GetConstructors().First();
// //             var args = constructor.GetParameters()
// //                 .Select(p => source.GetProperty(p.Name!, BindingFlags.IgnoreCase)?.GetValue(v))
// //                 .ToArray();


// //             return Success((T)constructor.Invoke(args));
// //         }
// //         if(value.Empty)
// //         {
// //             return Success();
// //         }


// //         throw new Exception(
// //             "idk"
// //         );
// //     }
// // }