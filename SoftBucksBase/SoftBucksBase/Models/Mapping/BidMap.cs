using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SoftBucksBase.Models.Mapping
{
    public class BidMap : EntityTypeConfiguration<Bid>
    {
        public BidMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Comment)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Bid");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.StatusId).HasColumnName("StatusId");

            // Relationships
            this.HasRequired(t => t.StatusBid)
                .WithMany(t => t.Bids)
                .HasForeignKey(d => d.StatusId);

        }
    }
}
