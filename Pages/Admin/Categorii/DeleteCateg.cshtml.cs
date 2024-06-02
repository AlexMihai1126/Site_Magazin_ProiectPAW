using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Categorii
{
    public class DeleteCategModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public DeleteCategModel(ProiectDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategorieProdus CategorieProdus { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategorieProdus = _context.CategProdus.Find(id);

            if (CategorieProdus == null)
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

            CategorieProdus = _context.CategProdus.Find(id);

            if (CategorieProdus != null)
            {
                _context.CategProdus.Remove(CategorieProdus);
                _context.SaveChanges();
            }

            return RedirectToPage("/Admin/Categorii/ViewCateg");
        }
    }
}
