using Infra.Data.Contract;
using Infra.School.Data.AdoCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Master
{
    public class MasterRepository : BaseConnectClass, IMasterRepository
    {
        public DataTable WardMaster()
        {
            DataTable dt = new DataTable();
            Open();
            objCommand.CommandText = "select * from [dbo].[tblwardmaster]";
            objCommand.CommandType = CommandType.Text;
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
            //using (SqlDataReader sqlDataReader = objCommand.ExecuteReader())
            //{

            dt.Load(sqlDataReader);
            Close();

            return dt;
        }
    }
}
