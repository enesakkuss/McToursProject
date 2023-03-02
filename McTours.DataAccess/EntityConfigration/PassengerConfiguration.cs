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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime2(0)");
            builder.Property(pass => pass.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(pass => pass.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasIndex(pass => pass.IdentityNumber).IsUnique();
            builder.Property(pass => pass.IdentityNumber)
                .HasColumnType("varchar(20)");
        }
    }
}
