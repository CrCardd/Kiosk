using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Kiosk.Application.Payloads.User;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Kiosk.Application.Services.Client;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Kiosk.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Services.Client;

public class UserService
(
    KioskContext ctx
) : IUserService
{
    public async Task<Result<GetPayload>> Create(CreatePayload payload, CancellationToken cancellationToken)
    {
        var exists = ctx.Users.Any(o => o.Email == payload.Email);
        if(exists)
            throw new ConflictEx("email already in use");

        var user = new UserModel
        {
            Name = payload.Name,
            Email = payload.Email,
            Password = payload.Password
        };

        ctx.Users.Add(user);
        await ctx.SaveChangesAsync(cancellationToken);
        return Result.Created(GetPayload.ToDto(user));
    }
    public async Task<Result<GetPayload>> Update(UpdatePayload payload, CancellationToken cancellationToken)
    {
        var user = await ctx.Users
            .Where(o => o.DisabledAt == null)
            .FirstOrDefaultAsync(
                cancellationToken
            );
            
        if(user is null)
            throw new NotFoundEx("organization not found");
        
        if(payload.Name.HasChanged)
            user.Name = payload.Name.Value;
        if(payload.Email.HasChanged)
            user.Email = payload.Email.Value;
        if(payload.Password.HasChanged)
            user.Password = payload.Password.Value; 
            
        await ctx.SaveChangesAsync(cancellationToken);
        return GetPayload.ToDto(user);
    }


    public GetPayload Get(Expression<Func<UserModel, bool>> predicate)
    {
        var user = ctx.Users
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(user is null)
            throw new NotFoundEx("organization not found");
        return GetPayload.ToDto(user);
    }

    public bool TryGet(Expression<Func<UserModel, bool>> predicate, [NotNullWhen(true)] out GetPayload? getPayload)
    {
        var user = ctx.Users
            .Where(o => o.DisabledAt == null)
            .FirstOrDefault(predicate);
        if(user is null)
        {            
            getPayload = null;
            return false;
        }
        getPayload = GetPayload.ToDto(user);
        return true;
    }
}