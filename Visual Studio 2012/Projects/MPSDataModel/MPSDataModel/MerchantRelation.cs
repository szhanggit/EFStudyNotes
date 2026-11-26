namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MerchantRelation")]
    public partial class MerchantRelation
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int? MerchantAndShopId { get; set; }

        public int? DefineId { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
