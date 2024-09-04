using System.ComponentModel.DataAnnotations;

namespace FlyHighStreamlineCapstone.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        public string FirstName { get; set; }
   
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string PassportNumber { get; set; } // Can be null if not applicable

        public string Nationality { get; set; }
    }
}
