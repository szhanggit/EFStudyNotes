using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEFConnection.ViewModel
{
    public class AdoraModel
    {
        public AdoraModel() { }
        public string BatchName { get; set; }
        public string ExecuteStartTime { get; set; }
        public string ExecutePeriod { get; set; }
        public string Diff { get; set; }
    }
}
