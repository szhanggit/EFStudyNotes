using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEFConnection.ViewModel
{
    public class DiveModel
    {
        public DiveModel() { }
        public int TaskId { get; set; }
        public int MessageStatus { get; set; }
        public int MessageLocalId { get; set; }
        public string CreatedOn { get; set; }
        public string SentOn { get; set; }
        public string Comment { get; set; }
    }
}
