using proiect.ContextModels;
using proiect.Models;
using System.Text.Json;
using System.Threading.Tasks;

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

        public async Task AddToCartAsync(int produsId)
        {
            var produs = await _context.Produs.FindAsync(produsId);
            if (produs == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetObjectFromJson<List<Produs>>("Cart") ?? new List<Produs>();
            if(produs.Stoc > 0)
            {
                cart.Add(produs);
            }

            session.SetObjectAsJson("Cart", cart);
        }

        public List<Produs> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available");
            }

            var cart = session.GetObjectFromJson<List<Produs>>("Cart") ?? new List<Produs>();
            return cart;
        }

        public void RemoveFromCart(int id)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available");
            }

            var cart = session.GetObjectFromJson<List<Produs>>("Cart") ?? new List<Produs>();
            var item = cart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                cart.Remove(item);
                session.SetObjectAsJson("Cart", cart);
            }
        }

        public async Task ClearCartAsync()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available");
            }

            session.Remove("Cart");
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (key == null) throw new ArgumentNullException(nameof(key));

            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (key == null) throw new ArgumentNullException(nameof(key));

            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
