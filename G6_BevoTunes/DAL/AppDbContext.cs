using Microsoft.EntityFrameworkCore;

using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace G6_BevoTunes.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.HasPerformanceLevel("Basic");
             builder.HasServiceTier("Basic");
             base.OnModelCreating(builder);

             builder.Entity<Order>()
                 .HasOne(o => o.Customer)
                 .WithMany(u => u.Orders)
                 .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Order>()
                 .HasOne(o => o.Recipient)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<CustCreditCard>()
                 .HasOne(c => c.User)
                 .WithMany(u => u.CreditCards)
                 .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Review>()
                 .HasOne(r => r.Reviewer)
                 .WithMany(u => u.Reviews)
                 .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Review>()
                 .HasOne(r => r.Approver)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);
         }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CustCreditCard> CustCreditCards { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
