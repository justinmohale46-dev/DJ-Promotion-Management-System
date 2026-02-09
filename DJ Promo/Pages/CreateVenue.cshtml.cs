using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class CreateVenueModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateVenueModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venue Venue { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Venue.Add(Venue);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Venues");
        }
    }
}