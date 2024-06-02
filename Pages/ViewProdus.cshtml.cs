using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using proiect.Services;
using static proiect.Pages.ViewProduse;

namespace proiect.Pages
{
    public class ViewProdusModel : PageModel
    {
        private readonly ProiectDBContext _context;
        private readonly ShoppingCartService _shoppingCartService;

        public ViewProdusModel(ProiectDBContext context, ShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
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
        public async Task<IActionResult> OnPostAddToCart([FromBody] AddToCartRequest request)
        {
            try
            {
                await _shoppingCartService.AddToCartAsync(request.Id);
                return new JsonResult(new { success = true });
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }

    
}
