namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Reviews", "Reply", c => c.String());
            AlterColumn("dbo.Brands", "BrandName", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "BrandDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "StoreName", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Sellers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sellers", "Password", c => c.String());
            AlterColumn("dbo.Sellers", "Address", c => c.String());
            AlterColumn("dbo.Sellers", "Email", c => c.String());
            AlterColumn("dbo.Sellers", "StoreName", c => c.String());
            AlterColumn("dbo.Sellers", "Name", c => c.String());
            AlterColumn("dbo.Brands", "BrandDescription", c => c.String());
            AlterColumn("dbo.Brands", "BrandName", c => c.String());
            DropColumn("dbo.Reviews", "Reply");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
