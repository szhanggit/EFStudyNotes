using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDataModel
{
    public class AdoraEntity
    {
        public AdoraEntity() { }

        public void GetAdoraCheckingData()
        {
            using (var dataModel = new ADORAEntities("SG_EV_UAT_ADORAEntities"))
            {
                var a = dataModel.spAdoraCheckingData().ToList();
            }
        }
    }

    public partial class ADORAEntities
    {
        public ADORAEntities(string connString) : base($"name={connString}")
        {
        }
    }
}
