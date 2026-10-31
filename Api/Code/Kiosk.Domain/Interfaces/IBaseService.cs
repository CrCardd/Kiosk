using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Domain.Models;

namespace Kiosk.Domain.Interfaces;

public interface IBaseService { }
public interface IBaseService<TEntity, TPayload> : IBaseService
    where TEntity : BaseModel
    where TPayload : IBaseGetPayload<TEntity, TPayload>
{
    // GET
    Task<TPayload> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    bool TryGet(Expression<Func<TEntity, bool>> predicate, [NotNullWhen(true)]  out TPayload? getPayload);

    // DELETE
    Task<TPayload> Delete(Guid Id, CancellationToken cancellationToken);
    Task<ICollection<TPayload>> Delete(IList<Guid> Ids, CancellationToken cancellationToken);
    Task<ICollection<TPayload>> Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TPayload> DeleteFirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}