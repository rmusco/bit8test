namespace JsonDataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Picture = c.String(),
                        Age = c.Int(nullable: false),
                        EyeColor = c.String(),
                        Gender = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        About = c.String(),
                        Registered = c.DateTime(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tags = c.String(),
                        Greeting = c.String(),
                        FavoriteFruit = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "PersonId", "dbo.Person");
            DropIndex("dbo.Person", new[] { "Id" });
            DropIndex("dbo.Friend", new[] { "PersonId" });
            DropIndex("dbo.Friend", new[] { "Id" });
            DropTable("dbo.Person");
            DropTable("dbo.Friend");
        }
    }
}
