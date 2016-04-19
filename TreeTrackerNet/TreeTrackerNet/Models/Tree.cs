using System;
using System.Data.Entity;

namespace TreeTrackerNet.Models
{
    public class Tree
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime DateBought { get; set; } 
    }

    public class TreeDBContext : DbContext
    {
        public DbSet<Tree> Trees { get; set; }
    }
}