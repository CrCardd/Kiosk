using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.User;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IUserService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken);
    GetPayload Get(Expression<Func<UserModel, bool>> predicate);
    bool TryGet(Expression<Func<UserModel, bool>> predicate, [NotNullWhen(true)]  out GetPayload? getPayload);
}