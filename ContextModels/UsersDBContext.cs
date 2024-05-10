using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using proiect.Models;

namespace proiect.ContextModels
{
    public class UsersDBContext:IdentityDbContext<DefaultUser>
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) { }
    }
}
