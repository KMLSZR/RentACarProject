using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.CarId).HasColumnName("CarId");
        builder.Property(p => p.CustomerId).HasColumnName("CustomerId");
        builder.Property(p => p.RentStartDate).HasColumnName("RentStartDate");
        builder.Property(p => p.RentEndDate).HasColumnName("RentEndDate");
        builder.Property(p => p.ReturnDate).HasColumnName("ReturnDate");
        builder.Property(p => p.RentStartKilometer).HasColumnName("RentStartKilometer");
        builder.Property(p => p.RentEndKilometer).HasColumnName("RentEndKilometer");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasOne(p => p.Car);
        builder.HasOne(p => p.Customer);


    }
}