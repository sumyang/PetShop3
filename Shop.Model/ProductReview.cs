namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductReview")]
    public partial class ProductReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int Oid { get; set; }

        [StringLength(50)]
        public string POcontent { get; set; }

        public int Pid { get; set; }

        public DateTime? time { get; set; }

        [StringLength(50)]
        public string start { get; set; }

        public virtual OAuthInfo OAuthInfo { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
