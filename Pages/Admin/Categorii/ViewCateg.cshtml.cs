using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Categorii
{
    public class ViewCategModel : PageModel
    {
        private readonly ProiectDBContext context;
        public List<CategorieProdus> Categorii { get; set; } = new List<CategorieProdus>();
        public ViewCategModel(ProiectDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Categorii = context.CategProdus
                               .OrderByDescending(p => p.Id)
                               .ToList();
        }
    }
}
