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
    internal class VehicleModelConfigration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable(nameof(VehicleModel));
            builder.HasKey(VehicleModel => VehicleModel.Id);
            builder.Property(VehicleModel => VehicleModel.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.HasData(
                new VehicleModel() { Id=1, Name="Fortuna",VehicleMakeId = 2},
                new VehicleModel() { Id=2, Name="Lions", VehicleMakeId = 2},
                new VehicleModel() { Id=3, Name="Cityliner", VehicleMakeId = 1},
                new VehicleModel() { Id=4, Name="Tourismo", VehicleMakeId = 3},
                new VehicleModel() { Id=5, Name="Travego", VehicleMakeId = 3}
                );

            builder
                .HasOne(vModel => vModel.VehicleMake)
                .WithMany(vma => vma.VehicleModels)
                .HasForeignKey(vmo=>vmo.VehicleMakeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(vm => vm.VehicleMake).AutoInclude();

        }
    }
}
