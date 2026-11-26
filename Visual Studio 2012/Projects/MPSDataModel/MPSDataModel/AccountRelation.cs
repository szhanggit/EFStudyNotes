namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountRelation")]
    public partial class AccountRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountId { get; set; }

        public int MerchantRelationId { get; set; }

        public int RoleValue { get; set; }

        [Required]
        [StringLength(200)]
        public string Creator { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
