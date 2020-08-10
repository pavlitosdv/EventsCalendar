using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsCalendar.ViewModels
{
    public class DataSetViewModel
    {
        public IEnumerable<Dataset> Options { get; set; }

        public string Id { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }


        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
    }
}