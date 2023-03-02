using McTours.Domain;
using McTours.VehicleDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.EntityConfigration
{
    internal class VehicleDefinitionConfigration : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.ToTable(nameof(VehicleDefinition));
            builder.HasKey(VehicleDefinition => VehicleDefinition.Id);

            builder.HasData(
                new VehicleDefinition() { Id = 1, FuelType=FuelType.Diesel, LineCount=20, SeatingType=SeatingType.Standart,Year=2016,VehicleModelId=2,Utilities=Utility.Wifi},
                new VehicleDefinition() { Id = 2, FuelType=FuelType.Diesel, LineCount=16, SeatingType=SeatingType.Vip,Year=2018,VehicleModelId=2,Utilities=Utility.Wifi|Utility.Hanger|Utility.Plug|Utility.Toilet|Utility.SmartScreen},
                new VehicleDefinition() { Id = 3, FuelType=FuelType.Diesel, LineCount=20, SeatingType=SeatingType.Standart, Year = 2017, VehicleModelId = 3, Utilities = Utility.Wifi | Utility.Hanger | Utility.Plug },
                new VehicleDefinition() { Id = 4, FuelType=FuelType.Diesel, LineCount=16, SeatingType=SeatingType.Vip,Year=2018,VehicleModelId=4,Utilities=Utility.Wifi|Utility.Hanger|Utility.Plug|Utility.SmartScreen}
                );

            builder
                .HasOne(vDef=>vDef.VehicleModel)
                .WithMany(vDef => vDef.VehicleDefinitions)
                .HasForeignKey(vd=>vd.VehicleModelId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Navigation(v=>v.VehicleModel).AutoInclude();
        }
    }
}
