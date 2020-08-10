using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventsCalendar.Models
{
    public class Dataset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }
        [Required]
        [DisplayName("Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public ICollection<Snapshot> Snapshots { get; set; }
    }
}