namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ProductIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductIds", c => c.Int(nullable: false));
        }
    }
}
