using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using System.Collections.Generic;
using System.Linq;

namespace proiect.Pages
{
    public class ViewProdusModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public ViewProdusModel(ProiectDBContext context)
        {
            _context = context;
        }

        public Produs Produs { get; set; }
        public List<SelectListItem> Categorii { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = _context.Produs
                    .Include(p => p.Categorie)
                    .FirstOrDefault(p => p.Id == id);

            if (Produs == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
