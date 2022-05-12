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
        public IList<Movie> Movies { get; set; } = new List<Movie>();
        public IList<Booking> Bookings { get; set; } = new List<Booking>();
        public async Task OnGetAsync()
        {
            Movies = await _context.Movies
                .Include(x => x.Bookings)
                .ToListAsync();
        }

    }
}