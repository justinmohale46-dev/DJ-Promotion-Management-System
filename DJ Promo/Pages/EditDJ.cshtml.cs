using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class EditDJModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditDJModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DJ DJ { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DJ = await _context.DJ.FindAsync(id);

            if (DJ == null)
            {
                return RedirectToPage("./DJs");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(DJ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./DJs");
        }
    }
}