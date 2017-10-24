namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? Pid { get; set; }

        public int? Oid { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        public DateTime? Time { get; set; }

        public virtual OAuthInfo OAuthInfo { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
