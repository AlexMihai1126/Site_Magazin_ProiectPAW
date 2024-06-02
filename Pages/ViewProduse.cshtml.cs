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

        
        public IList<Produs> Produse { get; set; }
        public int PageSize { get; } = 8; // Numărul de produse pe pagină
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        // Proprietate pentru a calcula numărul total de pagini
        public int TotalPages { get; set; }


        [BindProperty(SupportsGet = true)]
        public string Categorie { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Brand { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Culoare { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Model { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PretMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PretMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MemorieMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MemorieMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Dimensiune { get; set; }

        public ViewProduse(ProiectDBContext context, ShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public IList<Produs> Produs { get; set; }

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

            // Numărul total de produse după filtrare
            int totalItems = await query.CountAsync();

            // Calcularea numărului total de pagini
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Obținerea paginii curente și a listei de produse
            Produs = await query.Skip((PageIndex - 1) * PageSize)
                               .Take(PageSize)
                               .ToListAsync();
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

        public async Task<IActionResult> OnPostResetFilters()
        {
            Brand = null;
            Model = null;
            Culoare = null;
            PretMin = null;
            PretMax = null;
            MemorieMin = null;
            MemorieMax = null;
            Dimensiune = null;

            return RedirectToPage(new { Categorie });
        }


        public class AddToCartRequest
        {
            public int Id { get; set; }
        }
    }
}
