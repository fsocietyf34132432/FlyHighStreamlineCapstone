using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class FlightListViewModel
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
        public string AirlineName { get; set; }
        public string  AircraftRegistrationNumber { get; set; }
    }
}
