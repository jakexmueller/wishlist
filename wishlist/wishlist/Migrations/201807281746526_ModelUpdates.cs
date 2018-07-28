namespace wishlist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        WeeklyWage = c.Int(nullable: false),
                        Bills = c.Int(nullable: false),
                        Groceries = c.Int(nullable: false),
                        Transportation = c.Int(nullable: false),
                        GoingOutFund = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Budgets", new[] { "UserId" });
            DropTable("dbo.Budgets");
        }
    }
}
