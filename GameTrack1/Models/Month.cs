namespace GameTrack1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Month")]
    public partial class Month
    {
        [Key]
        [StringLength(1)]
        public string name { get; set; }

        public virtual Game Game { get; set; }
    }
}
