using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;

namespace Kiosk.Domain.Services;

public interface IVariantIngredientService : IBaseService
{
    public Task<Result<VariantIngredientGetPayload>> Create(VariantIngredientCreatePayload payload, CancellationToken cancellationToken);
}