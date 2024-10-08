﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FlyHighStreamlineCapstone.ViewModel
{
    public class FlightViewModel
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
        [Display(Name = "Departure Airport Name")]
        public int DepartureAirportId { get; set; }
        [Display(Name = "Arrival Airport Name")]
        public int ArrivalAirportId { get; set; }

        [Display(Name = "Arline Name")]
        public int AirlineId { get; set; }
        [Display(Name = "Aircraft")]
        public int AircraftId { get; set; }
        public int AirportId { get; set; }
    }
}
