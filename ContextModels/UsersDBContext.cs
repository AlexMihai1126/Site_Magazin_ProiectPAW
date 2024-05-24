using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using proiect.Models;
using Microsoft.AspNetCore.Identity;

namespace proiect.ContextModels
{
    public class UsersDBContext:IdentityDbContext<DefaultUser>
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var moderator = new IdentityRole("moderator");
            moderator.NormalizedName = "moderator";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var vizitator = new IdentityRole("vizitator");
            vizitator.NormalizedName = "vizitator";

            builder.Entity<IdentityRole>().HasData(moderator,client,vizitator);
        }
    }
}
