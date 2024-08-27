using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Aircraft
    {

        [Key]
        public int AircraftID { get; set; }   

        public string AircraftType { get; set; } //"Boeing 737-800"

        public string RegistrationNumber { get; set; } //"RP-C3223"

        public int Capacity { get; set; } //189
         [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; } //2015-03-12

        [ForeignKey("Airline")] //FK
        public int AirlineID { get; set; } 
        public Airline Airline { get; set; } 
    }
}
