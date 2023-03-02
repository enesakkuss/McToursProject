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
    public class VehicleService
    {
        private readonly McToursContext _context = new McToursContext();

        public IEnumerable<VehicleDto> GetAll()
        {
            try
            {
                return _context.Vehicles.Select(MapToDto).ToList();

            }
            catch (Exception ex)
            {
                return new List<VehicleDto>();
            }
        }

        public VehicleDto GetById(int id)
        {
            try
            {
                var entity = _context.Vehicles
                    .Include(veh => veh.VehicleDefinition)
                    .SingleOrDefault(veh => veh.Id == id);
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
        public CommandResult Create(VehicleDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                var entity = MapToEntity(model);


                _context.Vehicles.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(VehicleDto model)
        {
            try
            {
                var entity = MapToEntity(model);

                _context.Vehicles.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(VehicleDto vehicleDto)
        {
            var entity = MapToEntity(vehicleDto);
            try
            {
                _context.Vehicles.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(int id)
        {
            return Delete(new VehicleDto() { Id = id });
        }

        public IEnumerable<VehicleSummary> GetSummaries()
        {
            try
            {
                return _context.Vehicles
                    .Select(vehicle => new VehicleSummary()
                    {
                        Id = vehicle.Id,
                        PlateNumber = vehicle.PlateNumber,
                        RegistrationDate = vehicle.RegistrationDate,
                        RegistrationNumber = vehicle.RegistrationNumber,
                        VehicleDefinitionId = vehicle.VehicleDefinitionId,
                        VehicleModelName = vehicle.VehicleDefinition.VehicleModel.Name,
                        VehicleMakeName = vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return Enumerable.Empty<VehicleSummary>();
            }
        }

        

        internal static VehicleDto? MapToDto(Vehicle? vehicle)
        {
            return vehicle != null
                ? new VehicleDto()
                {
                    Id = vehicle.Id,
                    PlateNumber = vehicle.PlateNumber,
                    RegistrationDate = vehicle.RegistrationDate,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    VehicleDefinitionId = vehicle.VehicleDefinitionId,
                }
                : default;
        }
        internal static Vehicle? MapToEntity(VehicleDto? vehiclelDto)
        {
            return vehiclelDto != null
                ? new Vehicle()
                {
                    Id = vehiclelDto.Id,
                    PlateNumber = vehiclelDto.PlateNumber,
                    RegistrationDate = vehiclelDto.RegistrationDate,
                    RegistrationNumber = vehiclelDto.RegistrationNumber,
                    VehicleDefinitionId = vehiclelDto.VehicleDefinitionId,
                    
                }
                : default;
        }
    }
}
