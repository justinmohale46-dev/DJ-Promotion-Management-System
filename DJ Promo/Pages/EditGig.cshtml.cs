using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class EditGigModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditGigModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gig Gig { get; set; }

        public List<SelectListItem> DJs { get; set; }
        public List<SelectListItem> Venues { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Gig = await _context.Gig.FindAsync(id);

            if (Gig == null)
            {
                return RedirectToPage("./Gigs");
            }

            // Load dropdown data
            DJs = await _context.DJ
                .Select(d => new SelectListItem { Value = d.DJID.ToString(), Text = d.StageName })
                .ToListAsync();

            Venues = await _context.Venue
                .Select(v => new SelectListItem { Value = v.VenueID.ToString(), Text = v.Name })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Gig).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Gigs");
        }
    }
}