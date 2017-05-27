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
                        WorkId = c.Guid(nullable: false),
                        WorkName = c.String(maxLength: 20, storeType: "nvarchar"),
                        Content = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.WorkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Works");
        }
    }
}
