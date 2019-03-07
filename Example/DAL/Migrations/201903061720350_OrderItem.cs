namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_orders",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cln_id);
            
            CreateTable(
                "dbo.tbl_order_items",
                c => new
                    {
                        cln_item_id = c.Int(nullable: false),
                        cln_order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cln_item_id, t.cln_order_id })
                .ForeignKey("dbo.tbl_items", t => t.cln_item_id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_orders", t => t.cln_order_id, cascadeDelete: true)
                .Index(t => t.cln_item_id)
                .Index(t => t.cln_order_id);

            this.Sql(@"SET IDENTITY_INSERT dbo.tbl_orders ON 
                INSERT INTO dbo.tbl_orders (cln_id, cln_date) VALUES
                (125, '20020913'),
                (126, '20020914') 
                SET IDENTITY_INSERT dbo.tbl_orders OFF
                ");

            this.Sql(@"INSERT INTO dbo.tbl_order_items (cln_order_id, cln_item_id) VALUES
                (125, 563),
                (125, 851),
                (125, 652),
                (126, 563),
                (126, 652)
                ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_order_items", "cln_order_id", "dbo.tbl_orders");
            DropForeignKey("dbo.tbl_order_items", "cln_item_id", "dbo.tbl_items");
            DropIndex("dbo.tbl_order_items", new[] { "cln_order_id" });
            DropIndex("dbo.tbl_order_items", new[] { "cln_item_id" });
            DropTable("dbo.tbl_order_items");
            DropTable("dbo.tbl_orders");
            DropTable("dbo.tbl_items");
        }
    }
}
