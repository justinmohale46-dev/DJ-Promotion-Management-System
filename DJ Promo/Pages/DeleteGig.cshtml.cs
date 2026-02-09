using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class DeleteGigModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteGigModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gig Gig { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gig = await _context.Gig
                .Include(g => g.DJ)
                .Include(g => g.Venue)
                .FirstOrDefaultAsync(m => m.GigID == id);

            if (Gig == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gig = await _context.Gig.FindAsync(id);
            if (gig != null)
            {
                Gig = gig;
                _context.Gig.Remove(Gig);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Gigs");
        }
    }
}