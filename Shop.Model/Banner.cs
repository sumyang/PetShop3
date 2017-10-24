namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string imgages { get; set; }

        [StringLength(50)]
        public string describe { get; set; }

        public int? uid { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        public DateTime? time { get; set; }

        public virtual AdminUser AdminUser { get; set; }
    }
}
