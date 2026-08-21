using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Features.Auth_;
using Kiosk.Application.Payloads.Segment;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;

namespace Kiosk.Application.Services.Client;

public interface ISegmentClientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
    Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken);

    GetPayload Get(Expression<Func<SegmentModel, bool>> predicate);
    bool TryGet(Expression<Func<SegmentModel, bool>> predicate, [NotNullWhen(true)]  out GetPayload? getPayload);
}