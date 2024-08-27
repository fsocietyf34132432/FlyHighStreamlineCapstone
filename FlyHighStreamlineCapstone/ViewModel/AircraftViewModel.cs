using FlyHighStreamlineCapstone.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class AircraftViewModel
    {
        [Key]
        public int AircraftID { get; set; }

        //[Required]
        public string AircraftType { get; set; } //"Boeing 737-800"

        public string RegistrationNumber { get; set; } //"RP-C3223"

        public int Capacity { get; set; } //189
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; } //2015-03-12

        public int AirlineID { get; set; }

    }
}
