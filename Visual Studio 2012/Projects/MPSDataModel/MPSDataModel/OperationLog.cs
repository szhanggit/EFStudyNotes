namespace MPSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OperationLog")]
    public partial class OperationLog
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string APIName { get; set; }

        [StringLength(10)]
        public string MethodType { get; set; }

        public string RequestHeader { get; set; }

        public string Request { get; set; }

        public DateTime? RequestDateTime { get; set; }

        [StringLength(10)]
        public string ResponseCode { get; set; }

        public string ResponseHeader { get; set; }

        public string Response { get; set; }

        public DateTime? ResponseDateTime { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
