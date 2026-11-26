using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEFConnection.ViewModel
{
    public class MoveModel
    {
        public MoveModel() { }

        public string BatchName { get; set; }
        public DateTime? ExecuteStartTime { get; set; }
        public decimal? ExecutePeriod { get; set; }
        public int? Diff { get; set; }

    }
}
