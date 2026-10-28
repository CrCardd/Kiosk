using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.AuthCode;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface IAuthCodeService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> GetByEmail(string email, CancellationToken cancellationToken);

    
    bool TryGet(Expression<Func<AuthCodeModel, bool>> predicate, [NotNullWhen(true)]  out GetPayload? getPayload);
}