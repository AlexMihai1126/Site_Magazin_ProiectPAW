using Microsoft.AspNetCore.Identity;

namespace proiect.Models
{
    public class DefaultUser : IdentityUser
    {
        public ICollection<CosCumparaturi> CosCumparaturi { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Favorite> Favorite { get; set; }
        public DefaultUser()
        {
            CosCumparaturi = new List<CosCumparaturi>();
            Reviews = new List<Review>();
            Favorite = new List<Favorite>();
        }
    }
}
