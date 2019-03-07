using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("tbl_orders").HasKey(order => order.Id);
            this.Property(order => order.Id).HasColumnName("cln_id");
            this.Property(order => order.Date).HasColumnName("cln_date");
            this.Property(order => order.CustomerId).HasColumnName("cln_customer_id");
            this.HasMany<OrderItem>(s => s.OrderItems);
        }
    }
}
