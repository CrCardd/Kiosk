
using System.Collections;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Filters;
using Kiosk.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiosk.Infrastructure.Context;

public class KioskContext(
    DbContextOptions<KioskContext> options,
    IApiContext apiContext
) : DbContext(options)
{
    public Guid? CurrentCartId {get;init;} = apiContext.CartId;
    public Guid? CurrentUserId {get;init;} = apiContext.UserId;
    public Guid? CurrentSegmentId {get;init;} = apiContext.SegmentId;
    public SegmentRole? CurrentSegmentRoles {get;init;} = apiContext.SegmentRoles;
    public Guid? CurrentOrganizationId {get;init;} = apiContext.OrganizationId;
    public OrganizationRole? CurrentOrganizationRoles {get;init;} = apiContext.OrganizationRoles;
    public DateTimeOffset? ExpiresAt {get;init;} = apiContext.ExpiresAt;
    public bool IsSuperAdmin {get;init;} = apiContext.TokenType == TokenType.Super;

    public DbSet<CartModel> Carts {get;set;}
    public DbSet<CartItemModel> CartItems {get;set;}
    public DbSet<IngredientModel> Ingredients {get;set;}
    public DbSet<OrderModel> Orders {get;set;}
    public DbSet<PriceHistoryIngredientModel> PriceHistoryIngredients {get;set;}
    public DbSet<PriceHistoryVariantModel> PriceHistoryVariants {get;set;}
    public DbSet<ServiceModel> Services {get;set;}
    public DbSet<VariantModel> Variants {get;set;}
    public DbSet<VariantIngredientModel> VariantIngredients {get;set;}
    public DbSet<CombinationModel> Combinations {get;set;}
    public DbSet<CodeModel> Codes {get;set;}
    public DbSet<SegmentModel> Segments {get;set;}
    public DbSet<OAuthProviderModel> Providers {get;set;}
    public DbSet<AuthCodeModel> AuthCodes {get;set;}
    public DbSet<OrganizationModel> Organizations {get;set;}
    public DbSet<UserModel> Users {get;set;}
    public DbSet<UserOrganizationModel> UserOrganizations {get;set;}
    public DbSet<UserSegmentModel> UserSegments {get;set;}
    //public DbSet<_> _s {get;set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureTables(modelBuilder);
        ConfigureFilters(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }



    public void ConfigureTables(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCartTable();
        modelBuilder.ConfigureCartItemTable();
        modelBuilder.ConfigureIngredientTable();
        modelBuilder.ConfigureOrderTable();
        modelBuilder.ConfigurePriceHistoryIngredientTable();
        modelBuilder.ConfigurePriceHistoryVariantTable();
        modelBuilder.ConfigureServiceTable();
        modelBuilder.ConfigureVariantTable();
        modelBuilder.ConfigureCombinationTable();
        modelBuilder.ConfigureVariantIngredientTable();
        modelBuilder.ConfigureCodeTable();
        modelBuilder.ConfigureSegmentTable();
        modelBuilder.ConfigureOAuthProviderTable();
        modelBuilder.ConfigureAuthCodeTable();
        modelBuilder.ConfigureOrganizationTable();
        modelBuilder.ConfigureUserTable();
        modelBuilder.ConfigureUserOrganizationTable();
        modelBuilder.ConfigureUserSegmentTable();
        // modelBuilder.Configur();
    }
    public void ConfigureFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureWithOrganizationFilter(this);
        modelBuilder.ConfigureWithSegmentFilter(this);
        // modelBuilder.ConfigureUserFilter(this);
    }




    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {   
        SetUpdatedAt();
        SetDisableAt();
        
        return base.SaveChangesAsync(cancellationToken);
    }

    public void SetUpdatedAt()
    {
        var updated = ChangeTracker
            .Entries<BaseModel>()
            .Where(e => e.State == EntityState.Modified)
            .ToList();
        foreach(var e in updated)
            e.Entity.UpdatedAt = DateTime.UtcNow;
    }

    public void SetDisableAt()
    {
        var deleted = ChangeTracker
            .Entries<BaseModel>()
            .Where(e => e.State == EntityState.Deleted)
            .ToList();
        foreach(var e in deleted)
        {
            e.Entity.DisabledAt = DateTime.UtcNow;
            e.State = EntityState.Modified;
            e.Property(x => x.DisabledAt).IsModified = true;
        }
    }
}
