using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The movie need a Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The movie need a Genre")]
        public string Genre { get; set; }

        public int Seats { get; set; } = 50;
        public string Day { get; set; }
        public string Time { get; set; }

    }
}
