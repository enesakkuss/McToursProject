using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.EntityConfigration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Domain.Vehicle>
    {

        public void Configure(EntityTypeBuilder<Domain.Vehicle> builder)
        {
            builder.ToTable(nameof(Domain.Vehicle));
            builder.HasKey(vehicle => vehicle.Id);
            builder.Property(vehicle => vehicle.PlateNumber)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(vehicle => vehicle.RegistrationNumber)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .HasOne(vehicle => vehicle.VehicleDefinition)
                .WithMany(vehicleDefinition => vehicleDefinition.Vehicles)
                .HasForeignKey(vehicle => vehicle.VehicleDefinitionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(v => v.VehicleDefinition).AutoInclude();

        }
    }
}
