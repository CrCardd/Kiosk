using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services;

public class BaseService<TEntity, TPayload>(
    KioskContext context,
    string name
) 
    where TEntity : BaseModel
    where TPayload : IBaseGetPayload<TEntity, TPayload>
{
    // GET
    protected KioskContext ctx { get; } = context;
    public async Task<TPayload> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await ctx.Set<TEntity>()
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(predicate, cancellationToken);
        if(entity is null)
            throw new NotFoundEx($"{name} not found");
        return TPayload.ToDto(entity);
    }

    public bool TryGet(Expression<Func<TEntity, bool>> predicate, [NotNullWhen(true)] out TPayload? getPayload)
    {
        var entity = ctx.Set<TEntity>()
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(entity is null)
        {            
            getPayload = default;
            return false;
        }
        getPayload = TPayload.ToDto(entity);
        return true;
    }

    // DELETE
    public async Task<TPayload> Delete(Guid Id, CancellationToken cancellationToken)
    {
        var response = await Delete([Id], cancellationToken);
        return response.Single();
    }
    public async Task<ICollection<TPayload>> Delete(IList<Guid> Ids, CancellationToken cancellationToken)
    {
        var ids = Ids.Distinct().ToList();
        ICollection<TEntity> entities = await ctx.Set<TEntity>()
            .Where(o => o.DisabledAt == null)
            .Where(o => ids.Contains(o.Id))
            .ToListAsync(cancellationToken);
        if(entities.Count != ids.Count)
            throw new NotFoundEx($"{name} not found");
        
        foreach(var entity in entities)
            ctx.Set<TEntity>().Remove(entity);
        await ctx.SaveChangesAsync(cancellationToken);
        return entities.Select(TPayload.ToDto).ToList();
    }
    public async Task<ICollection<TPayload>> Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        ICollection<TEntity> entities = await ctx.Set<TEntity>()
            .Where(o => o.DisabledAt == null)
            .Where(predicate)
            .ToListAsync(cancellationToken);
        foreach(var entity in entities)
            ctx.Set<TEntity>().Remove(entity);
        await ctx.SaveChangesAsync(cancellationToken);
        return entities.Select(TPayload.ToDto).ToList();
    }
    public async Task<TPayload> DeleteFirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        TEntity? entity = await ctx.Set<TEntity>()
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(predicate, cancellationToken);
        if(entity == null)
            throw new NotFoundEx($"{name} not found");
        
        ctx.Set<TEntity>().Remove(entity);
        await ctx.SaveChangesAsync(cancellationToken);
        return TPayload.ToDto(entity);
    }
}