using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class OrderItemConfig : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfig()
        {
            this.ToTable("tbl_order_items").HasKey(i => new { i.OrderId, i.ItemId });
            this.Property(item => item.OrderId).HasColumnName("cln_order_id");
            this.Property(item => item.ItemId).HasColumnName("cln_item_id");
            this.Property(item => item.Quantity).HasColumnName("cln_quantity");
        }
    }
}
