using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class BusTrip
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int VehicleId { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int EstimatedDuration { get; set; }
        public decimal TicketPrice { get; set; }

        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }
        public Vehicle Vehicle { get; set; }

        // Concrete => Katı, somut
        // List,Collection, HashSet

        // Abstract => Soyut
        // IEnumerable, ICollection, IList
        
        // interface bir Soyutlama (abstraction) yapısıdır
        // interface ile bir tipte bulunması gereken davranışlar bildirir
        // interface üzerineda hangi üyeler tanımlanabilir? => Property,Method
        // Ancak o davranışın nasıl yerine getirildiğini bildirmez
        // Diğer bir ifadeyle; interface bir davranışı (property, method) implement etmez

        // bu özelliğinde dolayı interface'lere SÖZLEŞME (kontrat) da denir

        // interface ne olması gerektiğini SÖYLEMEZ nasıl olması gerektiğini SÖYLEMEZ
    }
}
