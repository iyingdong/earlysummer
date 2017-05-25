namespace EarlySummer.BusinessModules.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Week = c.String(unicode: false),
                        StartTime = c.DateTime(nullable: false, precision: 0),
                        StopTime = c.DateTime(nullable: false, precision: 0),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Works");
        }
    }
}
