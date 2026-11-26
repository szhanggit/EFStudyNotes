namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MerchantAndShop")]
    public partial class MerchantAndShop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ProgramCode { get; set; }

        [Required]
        [StringLength(20)]
        public string MerchantCode { get; set; }

        [StringLength(100)]
        public string MerchantName { get; set; }

        [Required]
        [StringLength(48)]
        public string MerchantSecurityKey { get; set; }

        public byte MerchantStatus { get; set; }

        [StringLength(50)]
        public string ShopCode { get; set; }

        [StringLength(50)]
        public string ShopExternalCode { get; set; }

        [StringLength(100)]
        public string ShopName { get; set; }

        [StringLength(48)]
        public string ShopSecurityKey { get; set; }

        public byte? ShopStatus { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
