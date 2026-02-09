using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DJ_Promo.Data;
using DJ_Promo.Models;

namespace DJ_Promo.Pages
{
    public class DeleteDJModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteDJModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DJ DJ { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DJ = await _context.DJ.FirstOrDefaultAsync(m => m.DJID == id);

            if (DJ == null)
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

            var dj = await _context.DJ.FindAsync(id);
            if (dj != null)
            {
                DJ = dj;
                _context.DJ.Remove(DJ);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./DJs");
        }
    }
}
