using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Airline
    {
        [Key]
        public int AirlineId { get; set; }

        public string Name { get; set; } //AirlineName as if

        public string IATA_Code { get; set; } // IATA Code Three-letter code ex: (JFK for John F. Kennedy International Airport), Primarily used for airline ticketing, baggage handling, and passenger information.

        public string ICAO_Code { get; set; } // ICAO Code Four-letter code ex: (KJFK for John F. Kennedy International Airport), Used for air traffic control, flight planning, and other operational purposes.

        public string Country { get; set; } //Global or Local
    }
}
