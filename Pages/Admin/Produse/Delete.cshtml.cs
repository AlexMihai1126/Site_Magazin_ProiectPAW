using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Produse
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public DeleteModel(ProiectDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = _context.Produs.Find(id);

            if (Produs == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = _context.Produs.Find(id);

            if (Produs != null)
            {
                _context.Produs.Remove(Produs);
                _context.SaveChanges();
            }

            return RedirectToPage("/Admin/Produse/Index");
        }
    }
}
