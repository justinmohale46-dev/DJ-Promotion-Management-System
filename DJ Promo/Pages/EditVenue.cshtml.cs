using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class EditVenueModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditVenueModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venue Venue { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Venue = await _context.Venue.FindAsync(id);

            if (Venue == null)
            {
                return RedirectToPage("./Venues");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Venue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Venues");
        }
    }
}