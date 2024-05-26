using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace proiect.Models
{
    public class DefaultUser : IdentityUser
    {
        // Navigation property for the shopping cart
        public ICollection<CosCumparaturi> CosCumparaturi { get; set; }

        // Navigation property for reviews
        public ICollection<Review> Reviews { get; set; }

        // Navigation property for favorites
        public ICollection<Favorite> Favorite { get; set; }

        public DefaultUser()
        {
            CosCumparaturi = new List<CosCumparaturi>();
            Reviews = new List<Review>();
            Favorite = new List<Favorite>();
        }
    }
}
