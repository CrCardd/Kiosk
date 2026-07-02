
using Kiosk.Application.Payloads.Ingredient;
using Kiosk.Domain.Interfaces;

namespace Kiosk.Application.Services;

public interface IIngredientService : IBaseService
{
    Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken);
}