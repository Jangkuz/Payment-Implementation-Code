using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSets for our entities
        public DbSet<PaymentTransaction> Payments { get; set; }
        public DbSet<PaymentLog> PaymentLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure PaymentLog's relationship with Payment
            modelBuilder
                .Entity<PaymentLog>()
                .HasOne(pl => pl.Payment)
                .WithMany()
                .HasForeignKey(pl => pl.PaymentId)
                .OnDelete(DeleteBehavior.Cascade); // Delete logs if Payment is deleted

            // Index for faster querying on TransactionId
            modelBuilder
                .Entity<PaymentTransaction>()
                .HasIndex(p => p.TransactionId)
                .IsUnique(false); // Allow duplicates (some providers may reuse IDs)
        }
    }
}
