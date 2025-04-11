using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // DbSets for our entities
    //public DbSet<OrderInfo> OrderInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderInfo>(entity =>
        {
            entity.HasMany(o => o.Payments)
                .WithOne(t => t.OrderInfo)
                .HasForeignKey(t => t.OrderId)
                .IsRequired();
        });

        modelBuilder.Entity<OrderPayment>(entity =>
        {
            entity.Property(o => o.PaymentMethod).HasConversion<string>();
            entity.Property(o => o.Currency).HasConversion<string>();
            entity.Property(o => o.Status).HasConversion<string>();
        });
    }
}
