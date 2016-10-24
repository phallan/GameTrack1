namespace GameTrack1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basketball")]
    public partial class Basketball
    {
        [Key]
        public int Week { get; set; }

        [Required]
        [StringLength(50)]
        public string GameName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamOne { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamTwo { get; set; }

        public int? ScoreOne { get; set; }

        public int? ScoreTwo { get; set; }

        [StringLength(50)]
        public string Winner { get; set; }
    }
}
