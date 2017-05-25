namespace EarlySummer.BusinessModules.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "MondayTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Works", "Content", c => c.String(unicode: false));
            DropColumn("dbo.Works", "Week");
            DropColumn("dbo.Works", "StartTime");
            DropColumn("dbo.Works", "StopTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "StopTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Works", "StartTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Works", "Week", c => c.String(unicode: false));
            DropColumn("dbo.Works", "Content");
            DropColumn("dbo.Works", "MondayTime");
        }
    }
}
