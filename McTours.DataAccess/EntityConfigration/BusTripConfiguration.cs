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
    public class BusTripConfiguration : IEntityTypeConfiguration<BusTrip>
    {
        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.ToTable(nameof(BusTrip));
            builder.HasKey(t => t.Id);

            builder.Property(b => b.Date)
                .IsRequired()
                .HasColumnType("datetime2(0)");

            builder.Property(b => b.TicketPrice)
                .IsRequired()
                .HasColumnType("money");

            builder
                .HasOne(v => v.Vehicle)
                .WithMany(v => v.BusTrips)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(b => b.ArrivalCity)
                .WithMany()
                .HasForeignKey(builder => builder.ArrivalCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(b => b.DepartureCity)
                .WithMany()
                .HasForeignKey(builder => builder.DepartureCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(trip => trip.Vehicle).AutoInclude();
            builder.Navigation(trip => trip.DepartureCity).AutoInclude();
            builder.Navigation(trip => trip.ArrivalCity).AutoInclude();
        }
    }
}
