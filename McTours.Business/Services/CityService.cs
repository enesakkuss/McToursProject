using McTours.BusTrips;
using McTours.DataAccess;
using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class CityService
    {
        private McToursContext _context = new McToursContext();

        public IEnumerable<City> GetAll()
        {
            try
            {
                return _context.Cities.Select(city => new City
                {
                    Id=city.Id,
                    Name=city.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<City>();
            }
        }
    }
}
