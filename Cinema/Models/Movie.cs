using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;
        public int Seats { get; set; } = 50;
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public List<Booking>? Bookings { get; set; }
    }
}
