namespace Practical_13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees_Task2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Middle_name = c.String(maxLength: 50, unicode: false),
                        Last_name = c.String(nullable: false, maxLength: 50, unicode: false),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        MobileNumber = c.String(nullable: false, maxLength: 10, unicode: false),
                        Address = c.String(maxLength: 100, unicode: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DesignationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees_Task2", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees_Task2", new[] { "DesignationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Employees_Task2");
            DropTable("dbo.Designations");
        }
    }
}
