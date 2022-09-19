using Microsoft.EntityFrameworkCore;

namespace Games_Library.Models
{
    public class myDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
		public DbSet<UserGame> UserGames { get; set; }
		//public DbSet<SysReq> SysReqs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J6LT3E6;Initial Catalog=GameLibrary;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>()
            .HasKey(ug => new { ug.UserId, ug.GameId });
            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(b => b.UserGames)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(c => c.UserGames)
                .HasForeignKey(ug => ug.GameId);
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            //modelBuilder.Entity<SysReq>().HasNoKey();
            modelBuilder.Entity<Game>()
                        .HasOne(a => a.SysReq)
                        .WithOne(b => b.Game)
                        .HasForeignKey<SysReq>(b => b.GameId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
