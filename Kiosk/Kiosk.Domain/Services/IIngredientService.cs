
using Kiosk.Domain.Payloads.Create;
using Kiosk.Domain.Payloads.Get;

namespace Kiosk.Domain.Services;

public interface IIngredientService : IBaseService
{
    public Task<Result<IngredientGetPayload>> Create(IngredientCreatePayload payload, CancellationToken cancellationToken);
}