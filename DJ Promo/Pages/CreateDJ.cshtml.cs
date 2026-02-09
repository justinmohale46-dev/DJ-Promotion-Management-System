using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class CreateDJModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateDJModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DJ DJ { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.DJ.Add(DJ);
            await _context.SaveChangesAsync();
            return RedirectToPage("./DJs");
        }
    }
}