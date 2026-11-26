namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageMapping")]
    public partial class MessageMapping
    {
        public int Id { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string Creator { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
