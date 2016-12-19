namespace SampleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Implementations",
                c => new
                    {
                        ImplementationId = c.Int(nullable: false, identity: true),
                        ImplementationName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ImplementationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Implementations");
        }
    }
}
