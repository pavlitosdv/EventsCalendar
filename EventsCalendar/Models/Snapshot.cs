using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventsCalendar.Models
{
    public class Snapshot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }


        public string DatasetID { get; set; }
        [ForeignKey("DatasetID")]
        public Dataset Dataset { get; set; }


        public ICollection<Campaign> Campaigns { get; set; }
    }
}