using Microsoft.AspNetCore.Http;
using proiect.ContextModels;
using proiect.Models;
using System.Text.Json;

namespace proiect.Services
{
    public class ShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProiectDBContext _context;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, ProiectDBContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task AddToCartAsync(Produs produs)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetObjectFromJson<List<Produs>>("Cart") ?? new List<Produs>();

            cart.Add(produs);

            session.SetObjectAsJson("Cart", cart);

            // Salvăm modificările în sesiune
            await session.CommitAsync();
        }


        public List<Produs> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetObjectFromJson<List<Produs>>("Cart") ?? new List<Produs>();
            return cart;
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}