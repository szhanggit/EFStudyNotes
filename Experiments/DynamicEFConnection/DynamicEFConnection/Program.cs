using DynamicEFConnection.HelpFunc;
using DynamicEFConnection.ViewModel;
using ProgramDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEFConnection
{
    class Program
    {
        //https://stackoverflow.com/questions/20216147/entity-framework-change-connection-at-runtime
        static void Main(string[] args)
        {
            ProgramEntity pe = new ProgramEntity();
            var list = pe.GetProgram();

            //MoveCheckingDataEntity mc = new MoveCheckingDataEntity();
            //var _moveList = mc.GetMoveCheckingData();

            //List<MoveModel> list = new List<MoveModel>();
            //_moveList.ConvertList<spMoveCheckingData_Result, MoveModel>(list);

            //AdoraEntity ae = new AdoraEntity();
            //ae.GetAdoraCheckingData();

            //DiveEntity de = new DiveEntity();
            //de.GetDiveEmailCheckingData();
            //de.GetDiveSlmsCheckingData();
        }
    }
}
