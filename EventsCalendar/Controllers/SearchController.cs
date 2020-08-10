using EventsCalendar.Models;
using EventsCalendar.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventsCalendar.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        public ActionResult Index()
        {

            var dataSets = db.Datasets.ToList();
            var listDataSet = new DataSetViewModel() { Options = dataSets };
            return View(listDataSet);
        }


        [HttpPost]
        public ActionResult Search(DataSetViewModel dataSet)
        {
            if (dataSet.StartDate == null || dataSet.EndDate == null || dataSet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            IEnumerable<CampaignViewModel> campaign = db.Campaigns.Include(s => s.Snapshot)
                                            .Where(i => i.StartDate >= dataSet.StartDate && i.EndDate <= dataSet.EndDate && i.Snapshot.DatasetID.Equals(dataSet.Id))
                                            .GroupBy(i => i.Snapshot.DatasetID).AsEnumerable()
                                                .SelectMany(i => i.OrderByDescending(o => o.Id)
                                                .DistinctBy(z => z.CampaignName).OrderBy(a => a.Id)
                                                .Select(x => new CampaignViewModel { Campaign = x, Dataset = i.Key }))
                                            .ToList();


            return View(campaign);
        }
    }
}