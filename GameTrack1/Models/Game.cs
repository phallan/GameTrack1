namespace GameTrack1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public class Game
    {
        [Key]
        [StringLength(1)]
        public string name { get; set; }

        [Required]
        [StringLength(1)]
        public string week { get; set; }

        [Required]
        [StringLength(1)]
        public string firstTeam { get; set; }

        [Required]
        [StringLength(1)]
        public string secondTeam { get; set; }

        [Required]
        [StringLength(1)]
        public string scoreFirst { get; set; }

        [Required]
        [StringLength(1)]
        public string scoreSecond { get; set; }

        [Required]
        [StringLength(1)]
        public string winner { get; set; }

        public virtual Month Month { get; set; }
    }
}
