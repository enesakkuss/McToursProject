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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("money");

            builder
                .HasOne(passenger => passenger.Passenger)
                .WithMany()
                .HasForeignKey(passenger => passenger.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(trip => trip.BusTrip)
                .WithMany()
                .HasForeignKey(trip => trip.BusTripId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(ticket => new
            {
                ticket.BusTripId,
                ticket.SeatNumber
            }).IsUnique();

        }
    }
}
