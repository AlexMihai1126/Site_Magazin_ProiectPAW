using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using proiect.Models;
using Microsoft.AspNetCore.Identity;

namespace proiect.ContextModels
{
    public class ProiectDBContext : IdentityDbContext<DefaultUser>
    {
        public DbSet<CategorieProdus> CategProdus { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<CosCumparaturi> CosCumparaturi { get; set; }
        public DbSet<ElementCosCumparaturi> ElementCosCumparaturi { get; set; }

        public ProiectDBContext(DbContextOptions<ProiectDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure precision and scale for Pret property in Produs entity
            modelBuilder.Entity<Produs>()
                .Property(p => p.Pret)
                .HasPrecision(18, 2);

            // Configure relationships
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Produs)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProdusId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.RUser)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.RUserId);

            modelBuilder.Entity<Produs>()
                .HasOne(p => p.Categorie)
                .WithMany(c => c.Produse)
                .HasForeignKey(p => p.CategorieId);

            modelBuilder.Entity<CosCumparaturi>()
                .HasOne(c => c.User)
                .WithMany(u => u.CosCumparaturi)
                .HasForeignKey(c => c.CUserID);

            modelBuilder.Entity<CosCumparaturi>()
                .HasMany(c => c.Produse)
                .WithOne(e => e.CosCumparaturi)
                .HasForeignKey(e => e.CosCumparaturiId);

            modelBuilder.Entity<ElementCosCumparaturi>()
                .HasOne(e => e.Produs)
                .WithMany()
                .HasForeignKey(e => e.ProdusId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorite)
                .HasForeignKey(f => f.FUserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Produs)
                .WithMany()
                .HasForeignKey(f => f.ProdusId);

            // Seed roles data
            var moderator = new IdentityRole("moderator");
            moderator.NormalizedName = "MODERATOR";

            var client = new IdentityRole("client");
            client.NormalizedName = "CLIENT";

            var vizitator = new IdentityRole("vizitator");
            vizitator.NormalizedName = "VIZITATOR";

            modelBuilder.Entity<IdentityRole>().HasData(moderator, client, vizitator);
        }

        public async Task<List<Produs>> SearchProductsAsync(string searchTerm)
        {
            return await Produs
                .Include(p => p.Categorie)
                .Where(p => p.Model.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();
        }
    }
}
