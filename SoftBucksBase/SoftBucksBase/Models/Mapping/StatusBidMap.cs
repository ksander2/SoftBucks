using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SoftBucksBase.Models.Mapping
{
    public class StatusBidMap : EntityTypeConfiguration<StatusBid>
    {
        public StatusBidMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BidStatus)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StatusBid");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BidStatus).HasColumnName("BidStatus");
        }
    }
}
