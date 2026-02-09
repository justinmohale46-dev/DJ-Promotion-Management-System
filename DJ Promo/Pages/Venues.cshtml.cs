using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class VenuesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VenuesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Venue> Venues { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Venues = await _context.Venue.ToListAsync();
        }
    }
}