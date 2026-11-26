using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDataModel
{
    public class ProgramEntity
    {
        List<Program> _programList = null;
        public ProgramEntity()
        {
            _programList = new List<Program>();
        }

        public List<Program> GetProgram()
        {
            using (var dataModel = new GR_EV_UAT_MOVEEntities("SG_EV_UAT_MOVEEntities"))
            {
                //_programList = dataModel.Programs.ToList();
                _programList = dataModel.Set<Program>().ToList();
            }
                          
            return _programList;
        }
    }

    public partial class GR_EV_UAT_MOVEEntities
    {
        public GR_EV_UAT_MOVEEntities(string connString) : base($"name={connString}")
        {
        }
    }
}
