using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public string AirlineName { get; set; }
        public string  AircraftRegistrationNumber { get; set; }
    }
}
