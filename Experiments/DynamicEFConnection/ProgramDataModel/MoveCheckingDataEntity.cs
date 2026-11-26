using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDataModel
{
    public class MoveCheckingDataEntity
    {
        List<spMoveCheckingData_Result> _list = new List<spMoveCheckingData_Result>();

        public MoveCheckingDataEntity()
        {

        }

        public List<spMoveCheckingData_Result> GetMoveCheckingData()
        {
            using (var dataModel = new GR_EV_UAT_MOVEEntities("SG_EV_UAT_MOVEEntities"))
            {
                _list = dataModel.spMoveCheckingData().ToList();
            }

            return _list;
        }
    }
}
