using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Search
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
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Produs = await _context.SearchProductsAsync(SearchTerm);
            }
            else
            {
                Produs = new List<Produs>();
            }
        }
    }
}