using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using proiect.Services;

namespace proiect.Pages
{
    public class ViewProduse : PageModel
    {
        private readonly ProiectDBContext _context;
        private readonly ShoppingCartService _shoppingCartService;

        [BindProperty(SupportsGet = true)]
        public string Categorie { get; set; }

        public ViewProduse(ProiectDBContext context, ShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public IList<Produs> Produs { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Brand { get; set; }


        [BindProperty(SupportsGet = true)]
        public string Culoare { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Model { get; set; }


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
            IQueryable<Produs> query = _context.Produs.Include(p => p.Categorie);

            if (!string.IsNullOrEmpty(Categorie))
            {
                string categorieLower = Categorie.ToLower();
                query = query.Where(p => p.Categorie.Nume.ToLower() == categorieLower);
            }

            if (!string.IsNullOrEmpty(Brand))
            {
                string brandLower = Brand.ToLower();
                query = query.Where(p => p.Brand.ToLower().Contains(brandLower));
            }

            if (!string.IsNullOrEmpty(Culoare))
            {
                string culoareLower = Culoare.ToLower();
                query = query.Where(p => p.Culoare.ToLower().Contains(culoareLower));
            }

            if (!string.IsNullOrEmpty(Model))
            {
                string modelLower = Model.ToLower();
                query = query.Where(p => p.Model.ToLower().Contains(modelLower));
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



        public class AddToCartRequest
        {
            public int Id { get; set; }
        }
    }
}