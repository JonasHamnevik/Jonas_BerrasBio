using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CinemaContext _context;
        public IndexModel (CinemaContext context) => this._context = context;
        public List<Movie> AllMovies { get; set; } = new List<Movie>();
        public List<Booking> AllBookings { get; set; } = new List<Booking>();
        public int BookedSeats { get; set; }
        public async Task OnGetAsync()
        {
            AllMovies = await _context.Movies
                .Include(x => x.Bookings)
                .ToListAsync();
            BookedSeats = _context.Bookings
                .Sum(s => s.NumberOfSeats);
        }
    }
}