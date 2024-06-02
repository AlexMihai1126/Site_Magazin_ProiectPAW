using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.Models;
using proiect.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect.Pages.CosCumparaturi
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingCartService _shoppingCartService;

        public IndexModel(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public List<Produs> CartItems { get; set; }
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            CartItems = _shoppingCartService.GetCartItems();
            TotalPrice = CartItems.Sum(p => p.Pret);
        }

        public IActionResult OnPostDelete(int id)
        {
            _shoppingCartService.RemoveFromCart(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostClearAsync()
        {
            await _shoppingCartService.ClearCartAsync();
            return RedirectToPage();
        }
    }
}
