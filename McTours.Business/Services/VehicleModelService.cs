using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleMakes;
using McTours.VehicleModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class VehicleModelService
    {
        private readonly McToursContext _context = new McToursContext();
        private readonly VehicleModelValidator _validator = new VehicleModelValidator();
        public IEnumerable<VehicleModelDto> GetAll()
            {
                try
                {
                return _context.VehicleModels.Select(MapToDto).ToList();
                }
                catch (Exception ex)
                {
                    return new List<VehicleModelDto>();
                }
            }

        public IEnumerable<VehicleModelSummary> GetSummaries()
        {
            try
            {
                return _context.VehicleModels
                    .Select(vehicleModel => new VehicleModelSummary()
                    {
                        Id = vehicleModel.Id,
                        Name = vehicleModel.Name,
                        VehicleMakeId = vehicleModel.VehicleMakeId,
                        VehicleMakeName= vehicleModel.VehicleMake.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelSummary>();
            }
        }
        public VehicleModelDto GetById(int id)
        {
            try
            {
                var entity = _context.VehicleModels.Find(id);
                return MapToDto(entity);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        public CommandResult Create(VehicleModelDto vehicleModelDto)
        {
            if (vehicleModelDto == null)
                throw new ArgumentNullException(nameof(vehicleModelDto));
            try
            {
                var entity = MapToEntity(vehicleModelDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.VehicleModels.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(VehicleModelDto vehicleModelDto)
        {
            var entity = MapToEntity(vehicleModelDto);
            try
            {
                _context.VehicleModels.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(VehicleModelDto vehicleModelDto)
        {

            if (vehicleModelDto == null)
                throw new ArgumentNullException(nameof(vehicleModelDto));
            try
            {
                var entity = MapToEntity(vehicleModelDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                
                _context.VehicleModels.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static VehicleModelDto MapToDto(VehicleModel vehicleModel)
        {
            VehicleModelDto dto = null;
            if (vehicleModel != null)
            {
                return new VehicleModelDto()
                {
                    Id = vehicleModel.Id,
                    Name = vehicleModel.Name,
                    VehicleMakeId=vehicleModel.VehicleMakeId,
                };

            }
            return dto;
        }

        internal static VehicleModel MapToEntity(VehicleModelDto vehicleModelDto)
        {
            VehicleModel model = null;
            if(vehicleModelDto != null)
            {

                return new VehicleModel()
                {
                    Id = vehicleModelDto.Id,
                    Name = vehicleModelDto.Name,
                    VehicleMakeId = vehicleModelDto.VehicleMakeId,
                };
            }
            return model;
        }
    }
}
