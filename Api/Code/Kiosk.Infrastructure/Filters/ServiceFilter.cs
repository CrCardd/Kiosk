using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Filters;

public static class ServiceFilter
{
    public static void ConfigureServiceFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<ServiceModel>(builder =>
    {

        builder.HasQueryFilter(s =>
            context.IsSuperAdmin || s.OrganizationId == context.CurrentOrganizationId
        );
    });
}
