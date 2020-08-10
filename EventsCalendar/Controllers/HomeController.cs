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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //var events = db.Campaigns.DistinctBy(d => d.CampaignName).ToList();
                var campaigns = db.Campaigns.Include(c => c.Snapshot)
                                            .GroupBy(i => i.Snapshot.DatasetID).AsEnumerable()
                                                .SelectMany(i => i.OrderByDescending(o => o.Id)
                                                .DistinctBy(z => z.CampaignName).OrderBy(a => a.Id)
                                                .Select(x => new CampaignViewModel { Campaign = x, Dataset = i.Key }))
                                            .ToList();
                return new JsonResult { Data = campaigns, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}