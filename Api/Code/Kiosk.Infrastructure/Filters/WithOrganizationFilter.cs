using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Filters;

public static class WithOrganizationFilter
{
    public static void ConfigureWithOrganizationFilter(this ModelBuilder modelBuilder, KioskContext context)
        => modelBuilder.Entity<BaseModelWithOrganization>(builder =>
    {
        builder.HasQueryFilter(s =>
            context.IsSuperAdmin 
            || s.Organization == null 
            || s.OrganizationId == context.CurrentOrganizationId
        );
    });
}
