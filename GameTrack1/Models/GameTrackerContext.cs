namespace GameTrack1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameTrackerContext : DbContext
    {
        public GameTrackerContext()
            : base("name=GameTrackerContext")
        {
        }

        public virtual DbSet<Basketball> Basketballs { get; set; }
        public virtual DbSet<Cricket> Crickets { get; set; }
        public virtual DbSet<Hockey> Hockeys { get; set; }
        public virtual DbSet<Tenni> Tennis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
