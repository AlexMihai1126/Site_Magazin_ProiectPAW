using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.ContextModels
{
    public class ProiectDBContext:DbContext
    {
        public DbSet<CategorieProdus> CategProdus { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<CosCumparaturi> CosCumparaturi { get;set; }
        public ProiectDBContext(DbContextOptions<ProiectDBContext> options) : base(options) { }
    }
}
