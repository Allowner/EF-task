namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_order_items", "cln_quantity", c => c.Int(nullable: false));

            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_quantity = 4 WHERE cln_item_id = 563 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_quantity = 500 WHERE cln_item_id = 563 AND cln_order_id = 126");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_quantity = 32 WHERE cln_item_id = 851 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_quantity = 5 WHERE cln_item_id = 652 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_quantity = 750 WHERE cln_item_id = 652 AND cln_order_id = 126");
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_order_items", "cln_item_qty");
        }
    }
}
