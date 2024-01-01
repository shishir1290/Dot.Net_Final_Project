﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductIds", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ProductIds");
        }
    }
}
