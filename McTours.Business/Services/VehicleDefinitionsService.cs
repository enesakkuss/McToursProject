using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleDefinitions;
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
    public class VehicleDefinitionsService
    {
        private McToursContext _context = new McToursContext();
        private readonly VehicleDefinitionValidator _validator = new VehicleDefinitionValidator();
        public IEnumerable<VehicleDefinitionDto> GetAll()
        {
            try
            {
                return _context.VehicleDefinitions.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<VehicleDefinitionDto>();
            }
        }

        public IEnumerable<VehicleDefinitionSummary> GetSummaries()
        {
            try
            {
                return _context.VehicleDefinitions
                    .Select(vehicle => new VehicleDefinitionSummary()
                    {
                        Id = vehicle.Id,
                        FuelType=vehicle.FuelType,
                        LineCount=vehicle.LineCount,
                        ModelName=vehicle.VehicleModel.Name,
                        MakeName=vehicle.VehicleModel.VehicleMake.Name,
                        SeatingType=vehicle.SeatingType,
                        Utilities=vehicle.Utilities,
                        VehicleModelId=vehicle.VehicleModelId,
                        Year=vehicle.Year
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitionSummary>();
            }
        }

        public VehicleDefinitionDto GetById(int id)
        {
            try
            {
                var entity = _context.VehicleDefinitions
                    .Include(def => def.VehicleModel)
                    .SingleOrDefault (def => def.Id == id);
                if(entity != null)
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

        public CommandResult Create(VehicleDefinitionDto vehicleDto)
        {
            if (vehicleDto == null)
                throw new ArgumentNullException(nameof(vehicleDto));
            try
            {
                var entity = MapToEntity(vehicleDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.VehicleDefinitions.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(VehicleDefinitionDto vehicleDto)
        {
            var entity = MapToEntity(vehicleDto);
            try
            {
                _context.VehicleDefinitions.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update(VehicleDefinitionDto vehicleDto)
        {

            if (vehicleDto == null)
                throw new ArgumentNullException(nameof(vehicleDto));
            try
            {
                var entity = MapToEntity(vehicleDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.VehicleDefinitions.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public IEnumerable<VehicleDefinitionWithName> GetIdAndName()
        {
            try
            {
                var allDefinitions = _context.VehicleDefinitions.Include("VehicleModel.VehicleMake").ToList();

                return allDefinitions.Select(x => new VehicleDefinitionWithName()
                {
                    VehicleDefinitionId = x.Id,
                    Description = string.Concat(x.VehicleModel.VehicleMake.Name, "-", x.VehicleModel.Name, "-", EnumHelper.FuelTypeNames[x.FuelType], "-", x.Year)
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitionWithName>();
            }
        }

        internal static VehicleDefinitionDto? MapToDto(VehicleDefinition vehicle)
        {
            VehicleDefinitionDto dto = null;
            if (vehicle != null)
            {
                dto = new VehicleDefinitionDto()
                {
                    Id = vehicle.Id,
                    FuelType = vehicle.FuelType,
                    Year=vehicle.Year,
                    LineCount = vehicle.LineCount,
                    SeatingType = vehicle.SeatingType,
                    VehicleModelId = vehicle.VehicleModelId,
                    VehicleMakeId = vehicle.VehicleModel != null ? vehicle.VehicleModel.VehicleMakeId :0,
                };

                var allUtilities = Enum.GetValues<Utility>();

                foreach (var utility in allUtilities)
                {
                    if(utility != Utility.None && vehicle.Utilities.HasFlag(utility))
                    {
                        dto.Utilities.Add(utility);
                    }
                }
            }
            return dto;
        }

        internal static VehicleDefinition? MapToEntity(VehicleDefinitionDto vehicleDto)
        {
            VehicleDefinition entity = null;

            if (vehicleDto != null)
            {
                entity= new VehicleDefinition()
                {
                    Id = vehicleDto.Id,
                    Year= vehicleDto.Year,
                    FuelType = vehicleDto.FuelType,
                    LineCount = vehicleDto.LineCount,
                    SeatingType = vehicleDto.SeatingType,
                    VehicleModelId = vehicleDto.VehicleModelId,
                };

                foreach (var utility in vehicleDto.Utilities)
                {
                    entity.Utilities = entity.Utilities | utility;
                }
            }
            return entity;
        }

    }
}

