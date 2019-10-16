namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        FIO = c.String(),
                        Admin = c.Boolean(nullable: false),
                        Post = c.String(),
                        Age = c.Int(),
                        Weight = c.Int(),
                        Height = c.Int(),
                        SubscriptionFinish = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Visit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Visits", t => t.Visit_Id)
                .Index(t => t.Visit_Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitTime = c.DateTime(nullable: false),
                        VisitNotes = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Visit_Id", "dbo.Visits");
            DropIndex("dbo.Users", new[] { "Visit_Id" });
            DropTable("dbo.Visits");
            DropTable("dbo.Users");
        }
    }
}
