using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TreeTrackerNet.Models
{
    public class TreeObservation
    {

        public int ID { get; set; }

        public int TreeID { get; set; }

        [ForeignKey("TreeID")]
        public Tree Tree { get; set; }

        [Required]
        [Display(Name = "Date Observered")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateObserver { get; set;}

        public Boolean Watered { get; set; }
        public Boolean Fertalized { get; set; }

        [Display(Name ="Trunk Measurement")]
        public int TrunkMeasurement { get; set; }
        public String Notes { get; set; }
    }

    public class TreeObservationDBContext : DbContext
    {
        public DbSet<TreeObservation> TreeObservations { get; set; }
    }
}