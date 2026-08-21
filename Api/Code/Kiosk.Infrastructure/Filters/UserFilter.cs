using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Filters;

public static class UserFilter
{
    public static void ConfigureUserFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<UserModel>(builder =>
    {

        builder.HasQueryFilter(u =>
            context.IsSuperAdmin || u.Id == context.CurrentUserId
        );
    });
}
