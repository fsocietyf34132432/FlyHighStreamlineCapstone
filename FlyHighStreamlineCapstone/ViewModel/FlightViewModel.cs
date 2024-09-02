using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class FlightViewModel
    {
        [Key]
        public int FlightId { get; set; }
        public string FlightNo { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Status { get; set; }

    
        public int Duration { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public int AirlineId { get; set; }
        public int AircraftId { get; set; }
        public int AirportId { get; set; }
    }
}
