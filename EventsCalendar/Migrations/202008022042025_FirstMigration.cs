namespace EventsCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SnapshotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Snapshots", t => t.SnapshotID, cascadeDelete: true)
                .Index(t => t.SnapshotID);
            
            CreateTable(
                "dbo.Snapshots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        DatasetID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Datasets", t => t.DatasetID)
                .Index(t => t.DatasetID);
            
            CreateTable(
                "dbo.Datasets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Snapshots", "DatasetID", "dbo.Datasets");
            DropForeignKey("dbo.Campaigns", "SnapshotID", "dbo.Snapshots");
            DropIndex("dbo.Snapshots", new[] { "DatasetID" });
            DropIndex("dbo.Campaigns", new[] { "SnapshotID" });
            DropTable("dbo.Datasets");
            DropTable("dbo.Snapshots");
            DropTable("dbo.Campaigns");
        }
    }
}
