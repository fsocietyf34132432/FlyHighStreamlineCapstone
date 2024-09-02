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
        [Display(Name = "Departure Airport Name")]
        public int DepartureAirportId { get; set; }
        [Display(Name = "Arrival Airport Name")]
        public int ArrivalAirportId { get; set; }

        [Display(Name = "Arline Name")]
        public int AirlineId { get; set; }
        [Display(Name = "Aircraft")]
        public int AircraftId { get; set; }
        public int AirportId { get; set; }
    }
}
