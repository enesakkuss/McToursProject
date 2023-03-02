using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleMakes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class VehicleMakeService
    {
        /*
         Update
         Delete
         GetById
         GetAll
         */
        private McToursContext _context = new McToursContext();

      
        public VehicleMakeDto GetById (int id)
        {
            
            try
            {
                var entity = _context.VehicleMakes.Find(id);
                return MapToDto(entity);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
           
        }

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            try
            {
                return _context.VehicleMakes.Select(MapToDto).ToList();
            }
            catch (Exception ex)
            {
                return new List<VehicleMakeDto>();
            }
        }

        public CommandResult Create(VehicleMakeDto vehicleMakeDto)
        {
                if (vehicleMakeDto == null)
                    throw new ArgumentNullException(nameof(vehicleMakeDto));
            try
            {
                var entity = MapToEntity(vehicleMakeDto);
                
                // VALİDASYON KONTROLÜ - Geçerlilik Kontrolü
                if(string.IsNullOrWhiteSpace(entity.Name))
                {
                    return CommandResult.Failure("Marka Adı Boş Geçilemez");
                }
                _context.VehicleMakes.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update (VehicleMakeDto vehicleMakeDto)
        {

            if (vehicleMakeDto == null)
                throw new ArgumentNullException(nameof(vehicleMakeDto));
            try
            {
                var entity = MapToEntity(vehicleMakeDto);
                if (string.IsNullOrWhiteSpace(entity.Name))
                {
                    return CommandResult.Failure("Marka Adı Boş Geçilemez");
                }
                _context.VehicleMakes.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete (VehicleMakeDto vehicleMakeDto)
        {
            try
            {
                var entity = MapToEntity(vehicleMakeDto);
                if(_context.VehicleModels.Any(vehicleModel => vehicleModel.VehicleMakeId == entity.Id))
                {
                    return CommandResult.Failure("Bu markaya kayıtlı araç modelleri olduğu için silinemez");
                }

                _context.VehicleMakes.Remove(entity);
                _context.SaveChanges ();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        internal static VehicleMakeDto MapToDto(VehicleMake? vehicleMake)
        {
            VehicleMakeDto dto = null;
            if(vehicleMake != null)
            {
                return new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name,
                };
            }
            return dto;
        }

        internal static VehicleMake MapToEntity(VehicleMakeDto vehicleMakeDto)
        {
            VehicleMake entity = null;

            if(vehicleMakeDto != null)
            {
                return new VehicleMake()
                {
                    Id = vehicleMakeDto.Id,
                    Name = vehicleMakeDto.Name,
                };
            }
            return entity;
        }
    }
}
