using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class CreateGigModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateGigModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gig Gig { get; set; }

        public List<SelectListItem> DJs { get; set; }
        public List<SelectListItem> Venues { get; set; }

        public async Task OnGetAsync()
        {
            DJs = await _context.DJ
                .Select(d => new SelectListItem { Value = d.DJID.ToString(), Text = d.StageName })
                .ToListAsync();

            Venues = await _context.Venue
                .Select(v => new SelectListItem { Value = v.VenueID.ToString(), Text = v.Name })
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Gig.Add(Gig);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Gigs");
        }
    }
}