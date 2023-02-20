namespace HospitalConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Connection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appusers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 25),
                        password = c.String(nullable: false),
                        Isadmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 10),
                        HealthIssues = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 100),
                        CreatedOnDateTime = c.DateTime(nullable: false),
                        LastVisitDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        UpdatedByUserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Appusers", new[] { "Username" });
            DropTable("dbo.Patients");
            DropTable("dbo.Appusers");
        }
    }
}
