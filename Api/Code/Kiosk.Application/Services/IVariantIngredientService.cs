
using Kiosk.Application.Payloads.VariantIngredient;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services;

public interface IVariantIngredientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}