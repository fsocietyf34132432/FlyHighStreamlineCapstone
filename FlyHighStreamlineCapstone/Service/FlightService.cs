using FlyHighStreamlineCapstone.Data;
using FlyHighStreamlineCapstone.Models;
using Microsoft.EntityFrameworkCore;

namespace FlyHighStreamlineCapstone.Service
{
    // In the "Services" folder
    public class FlightService
    {
        private readonly FlyHighStreamlineCapstoneContext _context; // Assuming you'll inject your DbContext

        // Constructor and dependencies (if any)
        public FlightService()
        {
            // You might inject dependencies here, like a database context or other services
        }

        public TimeSpan CalculateFlightDuration(DateTime departureTime, DateTime arrivalTime)
        {
            // Basic calculation, assuming arrivalTime is always later than departureTime
            TimeSpan duration = arrivalTime - departureTime;

            // Handle cases where arrivalTime is on the next day (e.g., overnight flights)
            if (duration.TotalHours < 0)
            {
                duration += TimeSpan.FromDays(1); // Add 24 hours
            }

            return duration;
        }

        public bool IsFlightDelayed(DateTime scheduledDepartureTime, DateTime actualDepartureTime)
        {
            // Consider a flight delayed if it departs 15 minutes or more after the scheduled time
            return actualDepartureTime > scheduledDepartureTime.AddMinutes(15);
        }

        //public decimal CalculateEstimatedArrivalTime(DateTime departureTime, TimeSpan flightDuration, TimeSpan timeZoneOffset)
        //{
        //    // Calculate estimated arrival time based on departure time, flight duration, and time zone offset
        //    DateTime estimatedArrivalTimeUTC = departureTime.Add(flightDuration);

        //    // Adjust for the time zone offset at the arrival airport
        //    DateTime estimatedArrivalTimeLocal = estimatedArrivalTimeUTC.Add(timeZoneOffset);

        //    return estimatedArrivalTimeLocal;
        //}

        // You can add more flight-related algorithms here as needed
    }

    //public List<Flight> SearchFlights(string departureAirportCode, string arrivalAirportCode, DateTime departureDate,
    //                             string? airlineCode = null, string? cabinClass = null, decimal? maxPrice = null)
    //{
    //    // Query your database (using _context) to filter flights based on the provided criteria
    //    var query = _context.Flight
    //        .Where(f => f.DepartureAirport.AirportCode == departureAirportCode &&
    //                    f.ArrivalAirport.AirportCode == arrivalAirportCode &&
    //                    f.DepartureTime.Date == departureDate);

    //    // Apply additional filters if provided
    //    if (!string.IsNullOrEmpty(airlineCode))
    //    {
    //        query = query.Where(f => f.Airline.IATA_Code == airlineCode);
    //    }
    //    if (!string.IsNullOrEmpty(cabinClass))
    //    {
    //        // You might need to join with Seat data to filter by cabin class
    //        // query = query.Where(f => ...); 
    //    }
    //    if (maxPrice.HasValue)
    //    {
    //        // Again, you might need to join with Seat data to filter by price
    //        // query = query.Where(f => ...); 
    //    }

    //    return query.ToList();
    //}

    //public double CalculateFlightDistance(Airport departureAirport, Airport arrivalAirport)
    //{
    //    // Implement the Haversine formula or another suitable distance calculation method
    //    // using departureAirport.Latitude, departureAirport.Longitude, 
    //    // arrivalAirport.Latitude, and arrivalAirport.Longitude

    //    // ... (calculation logic) ...

    //    return distanceInKilometers; // Or miles, depending on your preference
    //}

    //public string GetFlightStatus(Flight flight)
    //{
    //    DateTime currentTime = DateTime.Now;

    //    if (flight.Status == "Cancelled")
    //    {
    //        return "Cancelled";
    //    }
    //    else if (currentTime < flight.DepartureTime)
    //    {
    //        return "Scheduled";
    //    }
    //    else if (currentTime >= flight.DepartureTime && currentTime < flight.DepartureTime.AddMinutes(30)) // Boarding time window
    //    {
    //        return "Boarding";
    //    }
    //    else if (currentTime >= flight.DepartureTime.AddMinutes(30) && currentTime < flight.ArrivalTime)
    //    {
    //        return "Departed";
    //    }
    //    else if (currentTime >= flight.ArrivalTime)
    //    {
    //        return "Arrived";
    //    }
    //    else
    //    {
    //        // Handle any other unexpected scenarios
    //        return "Unknown";
    //    }
    //}


    //--------------------------Checking if a student has already booked a seat on a flight.-----------\\
    //--------------------------Canceling a booking.-----------\\
    //--------------------------Managing waiting lists if a flight is full..-----------\\

    /*
    public bool IsSeatAvailable(int flightId, string seatClass)
    {
        // Use your _context (database context) to check if there are any available seats 
        // for the given flightId and seatClass

        return _context.Seat
            .Any(s => s.FlightId == flightId &&
                      s.Class == seatClass &&
                      s.IsAvailable);
    }
    //--------------------------Get Available Seats for a Flight-----------\\
    public List<Seat> GetAvailableSeats(int flightId, string seatClass)
    {
        // Use your _context to retrieve available seats
        return _context.Seat
            .Where(s => s.FlightId == flightId &&
                        s.Class == seatClass &&
                        s.IsAvailable)
            .ToList();
    }
     //--------------------------Book a Seat for a Student-----------\\
    public bool BookSeat(int seatId, int studentId)
    {
        // 1. Check if the seat is still available
        var seat = _context.Seat.Find(seatId);
        if (seat == null || !seat.IsAvailable)
        {
            return false; // Seat not available
        }

        // 2. Mark the seat as unavailable
        seat.IsAvailable = false;

        // 3. Create a Booking record (assuming you have a Booking model)
        var booking = new Booking
        {
            SeatId = seatId,
            PassengerId = studentId, // Assuming you have a PassengerId for students
            BookingDate = DateTime.Now,
            // ... other booking details as needed
        };
        _context.Booking.Add(booking);

        // 4. Save changes to the database
        _context.SaveChanges();

        return true; // Booking successful
    }

      //--------------------------Calculate Discounted Price for Students-----------\\
    public decimal CalculateStudentPrice(decimal originalPrice, decimal discountPercentage)
    {
        decimal discountAmount = originalPrice * (discountPercentage / 100);
        return originalPrice - discountAmount;
    }

     //--------------------------Generate Booking Confirmation-----------\\
    public string GenerateBookingConfirmation(Booking booking)
    {
        // Use the booking details to generate a confirmation message or email
        // Include flight details, passenger details, seat number, price, etc.

        // ... (confirmation generation logic) ...

        return confirmationMessage;
    }*/


    //--------------------------Checking if a student has already booked a seat on a flight.-----------\\
    /*
    public bool HasStudentBookedFlight(int flightId, int studentId)
    {
        // Check if there is any booking for the given flight and student
        return _context.Booking.Any(b => b.FlightId == flightId && b.PassengerId == studentId);
    }

    //--------------------------Canceling a booking.-----------\\
    public bool CancelBooking(int bookingId)
    {
        var booking = _context.Booking.Find(bookingId);
        if (booking == null)
        {
            return false; // Booking not found
        }

        // Mark the associated seat as available again
        var seat = _context.Seat.Find(booking.SeatId);
        if (seat != null)
        {
            seat.IsAvailable = true;
        }

        _context.Booking.Remove(booking);
        _context.SaveChanges();
        return true; // Cancellation successful
    }

    //--------------------------Managing waiting lists if a flight is full..-----------\\
    // This would likely involve more complex logic, potentially using a separate WaitingList entity
    // and handling waitlist confirmations when seats become available
    */
}
