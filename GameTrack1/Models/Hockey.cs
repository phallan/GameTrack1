namespace GameTrack1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hockey")]
    public partial class Hockey
    {
        [Key]
        public int Week { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string TeamOne { get; set; }

        [Required]
        public string TeamTwo { get; set; }

        public int? ScoreOne { get; set; }

        public int? ScoreTwo { get; set; }

        public int? Winner { get; set; }
    }
}
