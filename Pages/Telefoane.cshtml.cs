using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using proiect.Services;

namespace proiect.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext _context;
        private readonly ShoppingCartService _shoppingCartService;

        public IndexModel(ProiectDBContext context, ShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }


        public IList<Produs> Produs { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Nume { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal? PretMin { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal? PretMax { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? MemorieMin { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? MemorieMax { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Dimensiune { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Produs> query = _context.Produs.Include(p => p.Categorie).Where(p => p.Categorie.Nume == "Telefoane");

            if (!string.IsNullOrEmpty(Nume))
            {
                query = query.Where(p => p.Model.Contains(Nume) || p.Brand.Contains(Nume));
            }
            if (PretMin.HasValue)
            {
                query = query.Where(p => p.Pret >= PretMin);
            }
            if (PretMax.HasValue)
            {
                query = query.Where(p => p.Pret <= PretMax);
            }
            if (MemorieMin.HasValue)
            {
                query = query.Where(p => p.Memorie >= MemorieMin);
            }
            if (MemorieMax.HasValue)
            {
                query = query.Where(p => p.Memorie <= MemorieMax);
            }
            if (!string.IsNullOrEmpty(Dimensiune))
            {
                query = query.Where(p => p.Dimensiune == Dimensiune);
            }

            Produs = await query.ToListAsync();
        }


        public async Task<IActionResult> OnPostAddToCartAsync([FromBody] AddToCartRequest request)
        {
            var produs = await _context.Produs.FindAsync(request.Id);
            if (produs == null)
            {
                return NotFound();
            }

            await _shoppingCartService.AddToCartAsync(produs);

            // Reîncarcăm pagina coșului de cumpărături
            return RedirectToPage("/CosCumparaturi/Index");
        }

        public class AddToCartRequest
        {
            public int Id { get; set; }
        }
    }
}