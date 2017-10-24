namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfoChi")]
    public partial class OrderInfoChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pid { get; set; }

        public int? num { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [Column(TypeName = "money")]
        public decimal? sumprice { get; set; }

        [StringLength(10)]
        public string isReview { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
