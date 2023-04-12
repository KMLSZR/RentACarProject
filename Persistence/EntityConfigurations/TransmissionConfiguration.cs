using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class TransmissionConfiguration: IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.ToTable("Transmissions").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Transmissions_Name").IsUnique();
            builder.HasMany(p => p.Models);

            Transmission[] transmissionsSeed = {
            new Transmission {Id=1, Name="Düz Vites"},
            new Transmission {Id=2, Name = "Otomatik" },
        };
            builder.HasData(transmissionsSeed);
        }
    }
}
