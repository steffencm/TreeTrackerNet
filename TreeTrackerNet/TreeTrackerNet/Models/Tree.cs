using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TreeTrackerNet.Models
{
    public class Tree
    {

        private TreeDBContext db = new TreeDBContext();

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Species")]
        public string Species { get; set; }

        [Required]
        [Display(Name = "Date Bought")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateBought { get; set; }
        
        [Display(Name="Aquired From")]
        public string AquiredFrom { get; set; }
        
        public virtual ICollection<TreeObservation> observations { get; set; } 
        }

        public class TreeDBContext : DbContext
        {
            public DbSet<Tree> Trees { get; set; }

            public System.Data.Entity.DbSet<TreeTrackerNet.Models.TreeObservation> TreeObservations { get; set; }
        }
}