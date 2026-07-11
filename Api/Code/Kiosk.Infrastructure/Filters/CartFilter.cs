using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class CartFilter
{
    public static void ConfigureCartFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<CartModel>(builder =>
    {
        builder.HasQueryFilter(c =>
            context.IsSuperAdmin || c.OrganizationId == context.CurrentOrganizationId
        );
    });
}
