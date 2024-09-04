using FlyHighStreamlineCapstone.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class SeatViewModel
    {
        [Key]
        public int SeatId { get; set; }

        [DisplayName("AircraftType")]
        public int AircraftId { get; set; }
        public string SeatNumber { get; set; }

        public string Class { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }
    }
}
