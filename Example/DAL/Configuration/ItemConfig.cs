using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            this.ToTable("tbl_items").HasKey(item => item.Id);
            this.Property(item => item.Id).HasColumnName("cln_id");
            this.Property(item => item.Description).HasColumnName("cln_description");
            this.Property(item => item.Price).HasColumnName("cln_price");
            this.HasMany<OrderItem>(s => s.OrderItems);
        }
    }
}