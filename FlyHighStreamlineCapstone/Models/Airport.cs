using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Airport
    {
        [Key] // Assuming AirportId is the primary key
        public int AirportId { get; set; }
      
        public string AirportCode { get; set; } // IATA or ICAO code

        public string AirportName { get; set; }

    
        public string City { get; set; }

        public string GeographicArea { get; set; } // Region or area

    
        public string Country { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
