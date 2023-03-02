using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.Passengers;
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
    public class PassengerService
    {
        private McToursContext _context = new McToursContext();
        private readonly PassengerValidator _validator = new PassengerValidator();
        public IEnumerable<PassengerDto> GetAll()
        {
            try
            {
                return _context.Passengers.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<PassengerDto>();
            }
        }

        public IEnumerable<SearchPassengerResult> SearchPassengers(SearchPassengerModel searchPassengerModel)
        {
            var query = _context.Passengers.AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(searchPassengerModel.IdentityNumber))
            {
                query = query.Where(pass => pass.IdentityNumber.Contains(searchPassengerModel.IdentityNumber));
            }
            if(!string.IsNullOrWhiteSpace(searchPassengerModel.FirstName))
            {
                query = query.Where(pass => pass.FirstName.Contains(searchPassengerModel.FirstName));
            }
            if(!string.IsNullOrWhiteSpace(searchPassengerModel.LastName))
            {
                query = query.Where(pass => pass.LastName.Contains(searchPassengerModel.LastName));
            }

            return query.Select(pass => new SearchPassengerResult()
            {
                Id=pass.Id,
                FirstName=pass.FirstName,
                Gender=pass.Gender,
                LastName=pass.LastName,
                IdentityNumber=pass.IdentityNumber
            }).ToList();
        }

        public PassengerDto GetById(int id)
        {
            try
            {
                var entity = _context.Passengers.Find(id);
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
        public CommandResult Create(PassengerDto passengerDto)
        {
            if (passengerDto == null)
                throw new ArgumentNullException(nameof(passengerDto));
            try
            {
                var entity = MapToEntity(passengerDto);

                var validationResult=_validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Passengers.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(PassengerDto passengerDto)
        {
            var entity = MapToEntity(passengerDto);
            try
            {
                _context.Passengers.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update(PassengerDto passengerDto)
        {

            if (passengerDto == null)
                throw new ArgumentNullException(nameof(passengerDto));
            try
            {
                var entity = MapToEntity(passengerDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Passengers.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static PassengerDto? MapToDto(Passenger passenger)
        {
            PassengerDto dto = null;
            if (passenger != null)
            {
                dto = new PassengerDto()
                {
                    Id=passenger.Id,
                    FirstName=passenger.FirstName,
                    LastName=passenger.LastName,
                    IdentityNumber=passenger.IdentityNumber,
                    Gender=passenger.Gender,
                    DateOfBirth = passenger.DateOfBirth
                };
            }
            return dto;
        }

        internal static Passenger? MapToEntity(PassengerDto passengerDto)
        {
            Passenger entity = null;

            if (passengerDto != null)
            {
                entity = new Passenger()
                {
                    Id=passengerDto.Id,
                    DateOfBirth=passengerDto.DateOfBirth,
                    FirstName=passengerDto.FirstName,
                    LastName=passengerDto.LastName,
                    IdentityNumber=passengerDto.IdentityNumber,
                    Gender=passengerDto.Gender
                };
            }
            return entity;
        }
    }
}
