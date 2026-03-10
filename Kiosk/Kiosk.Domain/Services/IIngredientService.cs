
using Kiosk.Domain.Payloads.Ingredient;

namespace Kiosk.Domain.Services;

public interface IIngredientService : IBaseService
{
    public Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}