namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoreName = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        StoreDescription = c.String(),
                        StoreAddress = c.String(),
                        StorePhone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sellers");
        }
    }
}
