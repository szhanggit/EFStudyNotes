namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountRole")]
    public partial class AccountRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string RoleName { get; set; }

        public int RoleValue { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
