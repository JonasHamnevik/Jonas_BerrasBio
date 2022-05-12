using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 50)]
        public int NumberOfSeats { get; set; }

        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
