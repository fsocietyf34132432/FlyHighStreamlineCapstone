using FlyHighStreamlineCapstone.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class SeatListViewModel
    {
        [Key]
        public int SeatId { get; set; }


        public string FlightNo { get; set; }
        public string SeatNumber { get; set; }

        public string Class { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }
    }
}
