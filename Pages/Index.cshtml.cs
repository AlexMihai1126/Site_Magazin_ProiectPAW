using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public IndexModel(ProiectDBContext context)
        {
            _context = context;
        }

        public IList<Produs> TopTelefoane { get; set; }
        public IList<Produs> TopTelevizoare { get; set; }
        public IList<Produs> TopTablete { get; set; }
        public IList<Produs> TopLaptopuri { get; set; }

        public async Task OnGetAsync()
        {
            TopTelefoane = await GetTopProductsByCategoryAsync("telefoane");
            TopTelevizoare = await GetTopProductsByCategoryAsync("televizoare");
            TopTablete = await GetTopProductsByCategoryAsync("tablete");
            TopLaptopuri = await GetTopProductsByCategoryAsync("laptopuri");
        }

        private async Task<IList<Produs>> GetTopProductsByCategoryAsync(string category)
        {
            return await _context.Produs
                .Include(p => p.Categorie)
                .Where(p => p.Categorie.Nume.ToLower() == category.ToLower() && p.NrBucVandute > 0)
                .OrderByDescending(p => p.NrBucVandute)
                .Take(4)
                .ToListAsync();
        }
    }
}
