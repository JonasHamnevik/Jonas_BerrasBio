#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Pages.Bookings;

public class TicketsModel : PageModel
{
    private readonly CinemaContext _context;
    [BindProperty]
    public Booking Bookings { get; set; }
    public IList<Movie> Movies { get; set; }
    public int SelectedMovieId { get; set; }
    public int freeSeats { get; set; }

    public TicketsModel(CinemaContext context)
    {
        _context = context;
    }

    public IActionResult OnGet([FromRoute] int id)
    {
        SelectedMovieId = id;
        Movies = _context.Movies.ToList();
        return Page();
    }



    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _context.Bookings.Add(Bookings);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}
