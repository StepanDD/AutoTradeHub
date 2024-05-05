using AutoTradeHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AutoTradeHub.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> cars { get; set; }
        public DbSet<Marka> marks { get; set; }
        public DbSet<Model> models { get; set; }
        public DbSet<Generation> generations { get; set; }
        public DbSet<Color> colors { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Car>()
		//			.HasMany(c => c.FavoriteUsers)
		//			.WithMany(s => s.FavoriteCars)
		//			.UsingEntity(j => j.ToTable("Favorites"));
		//	base.OnModelCreating(modelBuilder);
		//}
	}
}
