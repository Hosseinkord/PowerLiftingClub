namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 150),
                        ManagerName = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 300),
                        Phone = c.String(nullable: false, maxLength: 150),
                        Time = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ClubToolsLists",
                c => new
                    {
                        ToolsID = c.Int(nullable: false, identity: true),
                        ToolsName = c.String(nullable: false, maxLength: 300),
                        CountTools = c.Int(nullable: false),
                        Spoiled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToolsID);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Familly = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 300),
                        Phone = c.String(nullable: false, maxLength: 150),
                        Preambles = c.String(maxLength: 500),
                        Terms = c.String(maxLength: 500),
                        Age = c.Int(nullable: false),
                        Grade = c.String(maxLength: 300),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CoachID);
            
            CreateTable(
                "dbo.CoachPays",
                c => new
                    {
                        PayID = c.Int(nullable: false, identity: true),
                        CoachID = c.Int(nullable: false),
                        Pay = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.PayID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Familly = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 300),
                        Phone = c.String(nullable: false, maxLength: 150),
                        Preambles = c.String(maxLength: 500),
                        Terms = c.String(maxLength: 500),
                        Age = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserSalaries",
                c => new
                    {
                        PayID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Pay = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.PayID);
            
            CreateTable(
                "dbo.EmployeePays",
                c => new
                    {
                        PayID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        Pay = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.PayID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Familly = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 300),
                        Phone = c.String(nullable: false, maxLength: 150),
                        Preambles = c.String(maxLength: 500),
                        Terms = c.String(maxLength: 500),
                        Age = c.Int(nullable: false),
                        Grade = c.String(maxLength: 300),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.CoachPayCoaches",
                c => new
                    {
                        CoachPay_PayID = c.Int(nullable: false),
                        Coach_CoachID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CoachPay_PayID, t.Coach_CoachID })
                .ForeignKey("dbo.CoachPays", t => t.CoachPay_PayID, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_CoachID, cascadeDelete: true)
                .Index(t => t.CoachPay_PayID)
                .Index(t => t.Coach_CoachID);
            
            CreateTable(
                "dbo.UserCoaches",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Coach_CoachID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Coach_CoachID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_CoachID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Coach_CoachID);
            
            CreateTable(
                "dbo.UserSalaryUsers",
                c => new
                    {
                        UserSalary_PayID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserSalary_PayID, t.User_UserID })
                .ForeignKey("dbo.UserSalaries", t => t.UserSalary_PayID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.UserSalary_PayID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.EmployeeEmployeePays",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        EmployeePay_PayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.EmployeePay_PayID })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeePays", t => t.EmployeePay_PayID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.EmployeePay_PayID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeEmployeePays", "EmployeePay_PayID", "dbo.EmployeePays");
            DropForeignKey("dbo.EmployeeEmployeePays", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.UserSalaryUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserSalaryUsers", "UserSalary_PayID", "dbo.UserSalaries");
            DropForeignKey("dbo.UserCoaches", "Coach_CoachID", "dbo.Coaches");
            DropForeignKey("dbo.UserCoaches", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.CoachPayCoaches", "Coach_CoachID", "dbo.Coaches");
            DropForeignKey("dbo.CoachPayCoaches", "CoachPay_PayID", "dbo.CoachPays");
            DropIndex("dbo.EmployeeEmployeePays", new[] { "EmployeePay_PayID" });
            DropIndex("dbo.EmployeeEmployeePays", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.UserSalaryUsers", new[] { "User_UserID" });
            DropIndex("dbo.UserSalaryUsers", new[] { "UserSalary_PayID" });
            DropIndex("dbo.UserCoaches", new[] { "Coach_CoachID" });
            DropIndex("dbo.UserCoaches", new[] { "User_UserID" });
            DropIndex("dbo.CoachPayCoaches", new[] { "Coach_CoachID" });
            DropIndex("dbo.CoachPayCoaches", new[] { "CoachPay_PayID" });
            DropTable("dbo.EmployeeEmployeePays");
            DropTable("dbo.UserSalaryUsers");
            DropTable("dbo.UserCoaches");
            DropTable("dbo.CoachPayCoaches");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeePays");
            DropTable("dbo.UserSalaries");
            DropTable("dbo.Users");
            DropTable("dbo.CoachPays");
            DropTable("dbo.Coaches");
            DropTable("dbo.ClubToolsLists");
            DropTable("dbo.Clubs");
        }
    }
}
