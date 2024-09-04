using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class AircraftListViewModel
    {
        [Key]
        public int AircraftId { get; set; }

        //[Required]
        public string AircraftType { get; set; } //"Boeing 737-800"

        public string RegistrationNumber { get; set; } //"RP-C3223"

        public int Capacity { get; set; } //189
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; } //2015-03-12
        public string AirlineName { get; set; }
    }
}
