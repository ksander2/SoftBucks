using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SoftBucksBase.Models.Mapping;

namespace SoftBucksBase.Models
{
    public partial class SoftBucksContext : DbContext
    {
        static SoftBucksContext()
        {
            Database.SetInitializer<SoftBucksContext>(new SbDbInitializer());
        }

        public SoftBucksContext()
            : base("Name=SoftBucksContext")
        {
        }


        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Condiment> Condiments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StatusBid> StatusBids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new BeverageMap());
            modelBuilder.Configurations.Add(new BidMap());
            modelBuilder.Configurations.Add(new CheckoutMap());
            modelBuilder.Configurations.Add(new CondimentMap());
            modelBuilder.Configurations.Add(new PaymentMap());
            modelBuilder.Configurations.Add(new StatusBidMap());
        }
    }
}
