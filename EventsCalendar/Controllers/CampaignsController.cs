using EventsCalendar.Models;
using EventsCalendar.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsCalendar.Controllers
{
    public class CampaignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campaigns
        public ActionResult Index()
        {
            var campaigns = db.Campaigns.Include(c => c.Snapshot).OrderByDescending(i => i.Id).Take(3).OrderBy(i => i.Id);
            return View(campaigns.ToList());
        }

        public ActionResult GetAll()
        {
            //var campaigns = db.Campaigns.Include(c => c.Snapshot);
            var campaigns = db.Campaigns.Include(c => c.Snapshot)
                                        .GroupBy(i => i.Snapshot.DatasetID).AsEnumerable()
                                                .SelectMany(i => i.OrderByDescending(o => o.Id)
                                                .DistinctBy(z => z.CampaignName).OrderBy(a => a.Id)
                                                .Select(x => new CampaignViewModel { Campaign = x, Dataset = i.Key }))
                                         .ToList(); ;

            return View(campaigns.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}