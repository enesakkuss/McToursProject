using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.Tickets;
using McTours.VehicleDefinitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class TicketService
    {
        private McToursContext _context = new McToursContext();
        private readonly TicketValidator _validator = new TicketValidator();
        public IEnumerable<TicketDto> GetAll()
        {
            try
            {
                return _context.Tickets.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<TicketDto>();
            }
        }
        public IEnumerable<TicketSummary> GetSummaries()
        {
            try
            {
                return _context.Tickets
                    .Select(ticket => new TicketSummary()
                    {
                        Id = ticket.Id,
                        BusTripId=ticket.BusTripId,
                        Gender=ticket.Passenger.Gender,
                        IdentityNumber=ticket.Passenger.IdentityNumber,
                        PassengerId=ticket.PassengerId,
                        Price=ticket.Price,
                        SeatNumber=ticket.SeatNumber,
                        PassengerName=string.Concat(ticket.Passenger.FirstName," ",ticket.Passenger.LastName),
                        VehicleName=string.Concat(ticket.BusTrip.Vehicle.PlateNumber)
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TicketSummary>();
            }
        }
        public TicketDto GetById(int id)
        {
            try
            {
                var entity = _context.Tickets.Find(id);
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
        public CommandResult Create(TicketDto ticketDto)
        {
            if (ticketDto == null)
                throw new ArgumentNullException(nameof(ticketDto));
            try
            {
                var entity = MapToEntity(ticketDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Tickets.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(TicketDto ticketDto)
        {
            var entity = MapToEntity(ticketDto);
            try
            {
                _context.Tickets.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(TicketDto ticketDto)
        {

            if (ticketDto == null)
                throw new ArgumentNullException(nameof(ticketDto));
            try
            {
                var entity = MapToEntity(ticketDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Tickets.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static TicketDto? MapToDto(Ticket ticket)
        {
            TicketDto dto = null;
            if (ticket != null)
            {
                dto = new TicketDto()
                {
                   Id = ticket.Id,
                   BusTripId=ticket.BusTripId,
                   PassengerId=ticket.PassengerId,
                   Price=ticket.Price,
                   SeatNumber=ticket.SeatNumber
                };
            }
            return dto;
        }
        internal static Ticket? MapToEntity(TicketDto ticketDto)
        {
            Ticket entity = null;

            if (ticketDto != null)
            {
                entity = new Ticket()
                {
                    Id=ticketDto.Id,
                    PassengerId = ticketDto.PassengerId,
                    BusTripId=ticketDto.BusTripId,
                    Price=ticketDto.Price,
                    SeatNumber=ticketDto.SeatNumber
                };
            }
            return entity;
        }
    }
}
