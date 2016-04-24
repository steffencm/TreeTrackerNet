using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TreeTrackerNet.Models
{
    public class Tree
    {

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
    }

    public class TreeDBContext : DbContext
    {
        public DbSet<Tree> Trees { get; set; }
    }
}