using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.Models;
using proiect.Services;

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
        public void OnGet()
        {
            CartItems = _shoppingCartService.GetCartItems();
        }

        public IActionResult OnPostDelete(int id)
        {
            _shoppingCartService.RemoveFromCart(id);
            return RedirectToPage();
        }
    }
}