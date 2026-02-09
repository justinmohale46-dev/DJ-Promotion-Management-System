using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class GigsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public GigsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Gig> Gigs { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Gigs = await _context.Gig
                .Include(g => g.DJ)
                .Include(g => g.Venue)
                .OrderByDescending(g => g.Date)
                .ThenBy(g => g.Time)
                .ToListAsync();
        }
    }
}