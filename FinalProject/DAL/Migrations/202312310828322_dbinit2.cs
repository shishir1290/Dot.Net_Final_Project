namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Buyers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyers", "Password", c => c.String());
            AlterColumn("dbo.Buyers", "Gender", c => c.String());
            AlterColumn("dbo.Buyers", "Address", c => c.String());
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String());
        }
    }
}
