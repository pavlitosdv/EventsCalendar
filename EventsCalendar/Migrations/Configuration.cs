namespace EventsCalendar.Migrations
{
    using EventsCalendar.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventsCalendar.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventsCalendar.Models.ApplicationDbContext context)
        {
            if (context.Datasets.Count() == 0)
            {
                context.Datasets.AddOrUpdate(i => i.Id,
                    new Dataset() { Id = "Planning", CreationDate = new DateTime(2020, 07, 1, 8, 0, 0) },
                    new Dataset() { Id = "Production", CreationDate = new DateTime(2020, 07, 15, 1, 0, 0) });
            }

            if (context.Snapshots.Count() == 0)
            {
                context.Snapshots.AddOrUpdate(i => i.Id,
                   new Snapshot() { Id = 1, DatasetID = "Planning", CreationDate = new DateTime(2020, 07, 1, 8, 0, 0) },
                   new Snapshot() { Id = 2, DatasetID = "Planning", CreationDate = new DateTime(2020, 07, 2, 8, 0, 0) },
                   new Snapshot() { Id = 3, DatasetID = "Production", CreationDate = new DateTime(2020, 07, 15, 13, 0, 0) },
                   new Snapshot() { Id = 4, DatasetID = "Production", CreationDate = new DateTime(2020, 07, 16, 14, 0, 0) },
                   new Snapshot() { Id = 5, DatasetID = "Production", CreationDate = new DateTime(2020, 07, 16, 17, 0, 0) });
            }

            if (context.Campaigns.Count() == 0)
            {
                context.Campaigns.AddOrUpdate(i => i.Id,
                   new Campaign() { SnapshotID = 1, CampaignName = "Upstream", StartDate   = new DateTime(2020, 08, 1, 8, 0, 0), EndDate = new DateTime(2020, 08, 2, 17, 0, 0) },
                   new Campaign() { SnapshotID = 2, CampaignName = "Downstream", StartDate = new DateTime(2020, 08, 3, 8, 0, 0), EndDate = new DateTime(2020, 08, 6, 15, 0, 0) },
                   new Campaign() { SnapshotID = 2, CampaignName = "Upstream", StartDate   = new DateTime(2020, 08, 1, 10, 0, 0), EndDate = new DateTime(2020, 08, 2, 18, 0, 0) },
                   new Campaign() { SnapshotID = 3, CampaignName = "BufferPrep", StartDate = new DateTime(2020, 09, 1, 6, 0, 0), EndDate = new DateTime(2020, 09, 5, 15, 0, 0) },
                   new Campaign() { SnapshotID = 4, CampaignName = "Product1", StartDate   = new DateTime(2020, 09, 6, 8, 0, 0), EndDate = new DateTime(2020, 09, 7, 19, 0, 0) },
                   new Campaign() { SnapshotID = 5, CampaignName = "Product2", StartDate   = new DateTime(2020, 09, 8, 8, 0, 0), EndDate = new DateTime(2020, 09, 9, 20, 0, 0) },
                   new Campaign() { SnapshotID = 5, CampaignName = "BufferPrep", StartDate = new DateTime(2020, 09, 1, 12, 0, 0), EndDate = new DateTime(2020, 09, 6, 10, 0, 0) });
            }
        }
    }
}
