using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventsCalendar.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Campaign Name")]
        public string CampaignName { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public int SnapshotID { get; set; }
        [ForeignKey("SnapshotID")]
        public Snapshot Snapshot { get; set; }
    }
}