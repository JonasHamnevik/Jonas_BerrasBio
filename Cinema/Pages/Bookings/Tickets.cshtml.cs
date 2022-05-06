#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Pages.Bookings
{
    public class TicketsModel : PageModel
    {
        private readonly CinemaContext _context;

        public TicketsModel(CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Booking Bookings { get; set; }
        public IList<Movie> Movies { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Bookings);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
