namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notice")]
    public partial class Notice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

      
        public string NContent { get; set; }

        public DateTime? pTime { get; set; }

        public int? uid { get; set; }

        public virtual AdminUser AdminUser { get; set; }
    }
}
