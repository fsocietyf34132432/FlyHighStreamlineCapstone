using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }


        public string SeatNumber { get; set; }

        public string Class { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }
    }
}
