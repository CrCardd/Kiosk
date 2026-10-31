using Kiosk.Domain.Models;

namespace Kiosk.Domain.Interfaces;

public interface IBaseGetPayload<TEntity, TPayload>
    where TEntity : BaseModel
    where TPayload : IBaseGetPayload<TEntity, TPayload>
{
    Guid Id { get; init; }

    static abstract TPayload ToDto(TEntity entity);
}