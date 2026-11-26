namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Creator { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
