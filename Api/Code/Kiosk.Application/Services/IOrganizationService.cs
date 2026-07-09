using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.Organization;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services;

public interface IOrganizationService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken);

    GetPayload Get(Expression<Func<OrganizationModel, bool>> predicate);
    bool TryGet(Expression<Func<OrganizationModel, bool>> predicate, [NotNullWhen(true)]  out GetPayload? getPayload);
}