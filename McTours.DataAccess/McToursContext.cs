using McTours.DataAccess.EntityConfigration;
using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess
{
    public class McToursContext:DbContext
    {
        private const string ConnectionString =
            "Server=.;Database=McTours;Integrated Security=true";

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleDefinition> VehicleDefinitions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet <BusTrip> BusTrips { get; set; }
        public DbSet <Passenger> Passengers { get; set; }
        public DbSet <Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMakeConfigration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfigration());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfigration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfigration());
            modelBuilder.ApplyConfiguration(new BusTripConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }

        
    }
}
