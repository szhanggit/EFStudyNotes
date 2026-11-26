using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDataModel
{
    public class DiveEntity
    {
        public DiveEntity() { }

        public void GetDiveEmailCheckingData()
        {
            using (var dataModel = new DIVEEntities("TW_EV_UAT_DIVEEntities"))
            {
                var a = dataModel.spFetchDiveEmailData().ToList();
            }
        }

        public void GetDiveSlmsCheckingData()
        {
            using (var dataModel = new DIVEEntities("IN_EV_PROD_DIVEEntities"))
            {
                var a = dataModel.spFetchDiveSLMSData().ToList();
            }
        }
    }

    public partial class DIVEEntities
    {
        public DIVEEntities(string connString) : base($"name={connString}")
        {
        }
    }
}
