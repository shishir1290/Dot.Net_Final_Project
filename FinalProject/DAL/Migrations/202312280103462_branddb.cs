namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branddb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Brands", "BrandDescription", c => c.String());
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Brands", "Products");
            DropColumn("dbo.Categories", "Products");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Products", c => c.String());
            AddColumn("dbo.Brands", "Products", c => c.String());
            DropColumn("dbo.Categories", "CreatedAt");
            DropColumn("dbo.Categories", "CategoryDescription");
            DropColumn("dbo.Brands", "BrandDescription");
            DropColumn("dbo.Brands", "CreatedAt");
        }
    }
}
