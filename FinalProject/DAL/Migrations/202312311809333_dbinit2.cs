namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyers", "PhoneNumber", c => c.String());
        }
    }
}
