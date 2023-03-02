using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.EntityConfigration
{
    public class VehicleMakeConfigration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<VehicleMake>
    {
        public void Configure(EntityTypeBuilder<VehicleMake> builder)
        {
            builder.ToTable(nameof(VehicleMake));
            builder.HasKey(VehicleMake => VehicleMake.Id);
            builder.Property(VehicleMake => VehicleMake.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasData(
                new VehicleMake() { Id = 1 , Name="Neoplan"},
                new VehicleMake() { Id = 2 , Name="MAN"},
                new VehicleMake() { Id = 3 , Name="Mercedes"});

        }
    }
}
