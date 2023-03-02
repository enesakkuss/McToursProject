using McTours.BusTrips;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleDefinitions;
using McTours.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class BusTripService
    {
        private McToursContext _context = new McToursContext();

        public IEnumerable<BusTripDto> GetAll()
        {
            try
            {
                return _context.BusTrips.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<BusTripDto>();
            }
        }
        public BusTripDto GetById(int id)
        {
            try
            {
                var entity = _context.BusTrips
                    .Include(def => def.Vehicle)
                    .SingleOrDefault(def => def.Id == id);
                if (entity != null)
                {
                    var dto = MapToDto(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        public CommandResult Create(BusTripDto busTripDto)
        {
            if (busTripDto == null)
                throw new ArgumentNullException(nameof(busTripDto));
            try
            {
                var entity = MapToEntity(busTripDto);

                _context.BusTrips.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(BusTripDto model)
        {
            try
            {
                var entity = MapToEntity(model);

                _context.BusTrips.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(BusTripDto busTripDto)
        {
            var entity = MapToEntity(busTripDto);
            try
            {
                _context.BusTrips.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public IEnumerable<BusTripSummary> GetSummaries()
        {
            try
            {
                return _context.BusTrips
                    .Select(trip => new BusTripSummary()
                    {
                        Id = trip.Id,
                        Date = trip.Date,
                        EstimatedDuration = trip.EstimatedDuration,
                        TicketPrice = trip.TicketPrice,
                        VehicleId = trip.VehicleId,
                        ArrivalCityName = trip.ArrivalCity.Name,
                        DepartureCityName = trip.DepartureCity.Name,
                        VehicleName = string.Concat(trip.Vehicle.PlateNumber, " - ", trip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name, "/", 
                        trip.Vehicle.VehicleDefinition.VehicleModel.Name)
                    }).ToList();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripSummary>();
            }
        }
        public BusTripDetails? GetDetail(int id)
        {
            try
            {
                return _context.BusTrips
                    .Select( trip => new BusTripDetails()
                    {
                        Id = trip.Id,
                        LineCount=trip.Vehicle.VehicleDefinition.LineCount,
                        FuelType=trip.Vehicle.VehicleDefinition.FuelType,
                        SeatingType=trip.Vehicle.VehicleDefinition.SeatingType,
                        VehicleName=string.Concat(trip.Vehicle.PlateNumber.ToUpper()," - ",trip.Vehicle.VehicleDefinition.VehicleModel.Name,"/",trip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name),
                        Route=string.Concat(trip.DepartureCity.Name, "->", trip.ArrivalCity.Name, "/", trip.Date)
                    }).FirstOrDefault(trip => trip.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        public BusTripSeatsModel? GetBusTripSeats(int id)
        {
            try
            {
                var busTripSeats= _context.BusTrips.Select(busTrip => new BusTripSeatsModel()
                {
                    Id=busTrip.Id,
                    LineCount = busTrip.Vehicle.VehicleDefinition.LineCount,
                    SeatingType = busTrip.Vehicle.VehicleDefinition.SeatingType
                    // SoldSeatNumbers=busTrip.Tickets.Select(tic=>tic.SeatNumber).ToList()
                })
                .FirstOrDefault(seats => seats.Id == id);

                var soldTickets = _context.Tickets.Where(tic => tic.BusTripId == id).ToList();
                foreach (var soldTicket in soldTickets)
                {
                    busTripSeats.SoldSeatNumbers.Add(soldTicket.SeatNumber);
                }
                return busTripSeats;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        internal static BusTripDto? MapToDto (BusTrip busTrip)
        {
            BusTripDto dto = null;
            if (busTrip != null)
            {
                dto = new BusTripDto()
                {
                    Id = busTrip.Id,
                    ArrivalCityId = busTrip.ArrivalCityId,
                    Date = busTrip.Date,
                    DepartureCityId = busTrip.DepartureCityId,
                    EstimatedDuration = busTrip.EstimatedDuration,
                    TicketPrice = busTrip.TicketPrice,
                    VehicleId = busTrip.VehicleId,
                };
            }
            return dto;
        }
        internal static BusTrip? MapToEntity(BusTripDto? busTripDto)
        {
            BusTrip entity = null;

            if (busTripDto != null)
            {
                entity = new BusTrip()
                {
                    Id = busTripDto.Id,
                    ArrivalCityId = busTripDto.ArrivalCityId,
                    DepartureCityId = busTripDto.DepartureCityId,
                    Date = busTripDto.Date,
                    EstimatedDuration = busTripDto.EstimatedDuration,
                    TicketPrice = busTripDto.TicketPrice,
                    VehicleId = busTripDto.VehicleId
                };
            }
            return entity;
        }
    }
}
