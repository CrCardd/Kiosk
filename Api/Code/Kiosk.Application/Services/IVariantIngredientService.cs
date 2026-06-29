
using Kiosk.Application.Payloads.VariantIngredient;

namespace Kiosk.Application.Services;

public interface IVariantIngredientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}