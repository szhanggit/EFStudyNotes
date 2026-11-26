namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MerchantShopWorkKey")]
    public partial class MerchantShopWorkKey
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ProgramCode { get; set; }

        [Required]
        [StringLength(20)]
        public string MerchantCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ShopCode { get; set; }

        [Required]
        [StringLength(100)]
        public string WorkKey { get; set; }

        public DateTime AvailableStartDate { get; set; }

        public DateTime AvailableEndDate { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
