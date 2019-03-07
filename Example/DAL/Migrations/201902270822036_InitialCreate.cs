namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_items",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_description = c.String(),
                        cln_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_id);

            Sql(@"SET IDENTITY_INSERT dbo.tbl_items ON 
                 insert into tbl_items (cln_id, cln_description, cln_price) values 
                 (563, '56'' Blue Freen', 3.5),
                 (652, 'Spline End (Xtra Large)', 0.25),
                 (851, '3'' Red Freen', 12) 
                 SET IDENTITY_INSERT dbo.tbl_items OFF
                ");
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_items");
        }
    }
}
