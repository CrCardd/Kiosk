
using Kiosk.Application.Payloads.VariantIngredient;

namespace Kiosk.Application.Services;

public interface IVariantIngredientService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}