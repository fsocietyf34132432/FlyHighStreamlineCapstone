using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public string SeatNumber { get; set; }

        public string Class { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }
    }
}
