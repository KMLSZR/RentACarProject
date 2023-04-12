using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaintanceConfiguration : IEntityTypeConfiguration<Maintance>
{
    public void Configure(EntityTypeBuilder<Maintance> builder)
    {
        builder.ToTable("Maintances");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.CarId).HasColumnName("CarId");
        builder.Property(p => p.Date).HasColumnName("Date");
        builder.Property(p => p.ReturnDate).HasColumnName("ReturnDate");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasOne(p => p.Car);
    }
}