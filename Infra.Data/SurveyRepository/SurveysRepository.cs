using Infra.Data.Contract;
using Infra.School.Data.AdoCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.SurveyRepository
{
    public class SurveysRepository : BaseConnectClass, ISurveyReposirory
    {
        public DataTable GetBeneficiaryList()
        {
            DataTable dt = new DataTable();
            Open();
            objCommand.CommandText = "dbo.Pro_GetBeneficiary";
            objCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
            dt.Load(sqlDataReader);
            Close();
            return dt;
        }

        public DataTable BeneficiaryDetail(int Id)
        {
            DataTable dt = new DataTable();
            Open();
            objCommand.CommandText = "select * from [dbo].[tblbeneficiary] where id=" + Id;
            objCommand.CommandType = CommandType.Text;
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
            dt.Load(sqlDataReader);
            Close();
            return dt;
        }
    }
}
