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


        //public int Duration { get; set; }

        [NotMapped]
        public string Duration
        {
            get
            {
                if (ArrivalTime > DepartureTime)
                {
                    TimeSpan duration = ArrivalTime - DepartureTime;

                    // Exclude days from the calculation and display
                    return $"{duration.Hours} hour{(duration.Hours == 1 ? "" : "s")} and {duration.Minutes} minute{(duration.Minutes == 1 ? "" : "s")}";
                }
                else
                {
                    return "Invalid: Arrival before Departure";
                }
            }
        }

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


        [ForeignKey("DepartureAirportId")]
        public Airport DepartureAirport { get; set; }

        [ForeignKey("ArrivalAirportId")]
        public Airport ArrivalAirport { get; set; }






    }
}
