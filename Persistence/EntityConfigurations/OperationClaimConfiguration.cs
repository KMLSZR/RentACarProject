using Core.Security.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnName("Id");
        builder.Property(o => o.Name).HasColumnName("Name");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasIndex(indexExpression: o => o.Name, name: "UK_OperationClaims_Name").IsUnique();

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds = new();

        seeds.Add(new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin });

        
        #region Cars
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cars.Delete" });
        
        #endregion
        
        
        #region Rentals
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Rentals.Delete" });
        
        #endregion
        
        
        #region Customers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        
        #endregion
        
        
        #region Maintances
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Maintances.Delete" });
        
        #endregion
        
        return seeds;
    }
}
