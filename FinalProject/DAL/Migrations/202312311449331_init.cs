namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Buyers", "Address", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Buyers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "Name", c => c.String(nullable: false));
        }
    }
}
