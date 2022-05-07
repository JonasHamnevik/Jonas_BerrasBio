using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CinemaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CinemaContext>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null CinemaContext");
                }

                if (context.Bookings.Any() || context.Movies.Any())
                {
                    return;
                }

                DateTime date = DateTime.Now;

                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title = "Gummy Bears",
                        Genre = "Cartoon",
                        Day = DateTime.Today.ToShortDateString(),
                        Time = "12:00"
                    },
                    new Movie
                    {
                        Title = "James Bond",
                        Genre = "Action",
                        Day = DateTime.Today.ToShortDateString(),
                        Time = "20:00"
                    }
                };
                context.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}
