namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "ImageName", c => c.String());
            AddColumn("dbo.Users", "ImageName", c => c.String());
            AddColumn("dbo.Employees", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImageName");
            DropColumn("dbo.Users", "ImageName");
            DropColumn("dbo.Coaches", "ImageName");
        }
    }
}
