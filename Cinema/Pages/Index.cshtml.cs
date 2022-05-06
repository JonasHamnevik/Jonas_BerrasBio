using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CinemaContext context;
        public IndexModel (CinemaContext context) => this.context = context;
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public async Task OnGetAsync()
        {
            Movies = await context.Movies.ToListAsync();
        }
    }
}