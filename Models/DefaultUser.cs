using Microsoft.AspNetCore.Identity;

namespace proiect.Models
{
    public class DefaultUser : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Favorite> Favorite { get; set; }
        public DefaultUser()
        {
            Reviews = new List<Review>();
            Favorite = new List<Favorite>();
        }
    }
}
