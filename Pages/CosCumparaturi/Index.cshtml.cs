using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;
using proiect.Services;
using System.Collections.Generic;

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
    }
}