using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.User;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IUserService : IBaseService<UserModel, GetPayload>
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken);
}