
using Kiosk.Application.Payloads.Ingredient;

namespace Kiosk.Application.Services;

public interface IIngredientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}