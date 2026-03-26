using Microsoft.EntityFrameworkCore;
using TetPee.Repository.Entity;

namespace TetPee.Repository;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Password)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasOne(u => u.Seller)
                .WithOne(s => s.User)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@gmail.com",
                    Password = "PiedTeam",
                    Role = "Admin"
                }
            };
            builder.HasData(users);
        });
    }
}