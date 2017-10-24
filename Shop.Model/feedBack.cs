namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("feedBack")]
    public partial class feedBack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string fContent { get; set; }

        public DateTime? Time { get; set; }

        public int? Oid { get; set; }

        public virtual OAuthInfo OAuthInfo { get; set; }
    }
}
