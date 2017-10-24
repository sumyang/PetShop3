namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfoFat")]
    public partial class OrderInfoFat
    {
        [Key]
        [StringLength(50)]
        public string OrderId { get; set; }

        public int Oid { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string remark { get; set; }

        [StringLength(50)]
        public string PayMethod { get; set; }

        public DateTime? PayTime { get; set; }

        public DateTime? CreatOrderTime { get; set; }

        public DateTime? PostTime { get; set; }

        public DateTime? RevTime { get; set; }

        [Column(TypeName = "money")]
        public decimal? carriage { get; set; }

        [Column(TypeName = "money")]
        public decimal? SumPrice { get; set; }

        public int? CheckUserid { get; set; }

        public virtual OAuthInfo OAuthInfo { get; set; }
    }
}
