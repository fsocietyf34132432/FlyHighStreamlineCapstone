using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; } 
        public string FlightNo { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Status { get; set; }
    

        public int Duration { get; set; }

        // Foreign keys to establish relationships with other entities
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

       //fk
        [ForeignKey("Airline")] 
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
        
        [ForeignKey("Aircraft")] 
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }




    }
}
