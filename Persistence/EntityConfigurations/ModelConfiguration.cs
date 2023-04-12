using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration:IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(p => p.FuelId).HasColumnName("FuelId");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasOne(p => p.Brand);
        builder.HasOne(p => p.Transmission);
        builder.HasOne(p => p.Fuel);

        builder.HasIndex(indexExpression: p => p.Name, name: "UK_Models_Name").IsUnique();

        Model[] modelsSeed = {
            new (id:1,brandId:1,transmissionId:1,fuelId:1,name:"CLA",dailyPrice:2000,imageUrl:"cdn.dsi.gov.tr/image1.jpg"),
            new (id:2,brandId:1,transmissionId:1,fuelId:1,name:"CLA2",dailyPrice:3000,imageUrl:"cdn.dsi.gov.tr/image2.jpg")
        };
        builder.HasData(modelsSeed);
    }

}
