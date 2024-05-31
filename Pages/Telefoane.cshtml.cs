using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public IndexModel(ProiectDBContext context)
        {
            _context = context;
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
                query = query.Where(p => p.Nume.Contains(Nume));
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
    }
}
