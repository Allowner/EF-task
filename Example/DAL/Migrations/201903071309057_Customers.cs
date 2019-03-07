namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_customers",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_name = c.String(),
                        cln_address = c.String(),
                        cln_city = c.String(),
                        cln_state = c.String(),
                    })
                .PrimaryKey(t => t.cln_id);

            this.Sql(@"SET IDENTITY_INSERT dbo.tbl_customers ON 
                INSERT INTO dbo.tbl_customers (cln_id, cln_name, cln_address, cln_city, cln_state) VALUES
                (56, 'Foo, Inc', '23 Main St., Thorpleburg', 'Thorpleburg', 'TX'),
                (2, 'Freens R Us', '1600 Pennsylvania Avenue', 'Washington', 'DC')
                SET IDENTITY_INSERT dbo.tbl_customers OFF
            ");

            AddColumn("dbo.tbl_orders", "cln_customer_id", c => c.Int(nullable: false));

            this.Sql(@"UPDATE dbo.tbl_orders SET cln_customer_id = 56 WHERE cln_id = 125");
            this.Sql(@"UPDATE dbo.tbl_orders SET cln_customer_id = 2 WHERE cln_id = 126");
            CreateIndex("dbo.tbl_orders", "cln_customer_id");
            AddForeignKey("dbo.tbl_orders", "cln_customer_id", "dbo.tbl_customers", "cln_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_orders", "cln_customer_id", "dbo.tbl_customers");
            DropIndex("dbo.tbl_orders", new[] { "cln_customer_id" });
            DropColumn("dbo.tbl_orders", "cln_customer_id");
            DropTable("dbo.tbl_customers");
        }
    }
}
