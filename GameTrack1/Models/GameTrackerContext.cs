namespace GameTrack1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameTrackerContext : DbContext
    {
        public GameTrackerContext()
            : base("name=GameTrackerConnection")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Month> Months { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.week)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.firstTeam)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.secondTeam)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.scoreFirst)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.scoreSecond)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.winner)
                .IsUnicode(false);

            modelBuilder.Entity<Month>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Month>()
                .HasOptional(e => e.Game)
                .WithRequired(e => e.Month);
        }
    }
}
