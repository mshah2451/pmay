
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.School.Data.AdoCore
{
 public  abstract class BaseConnectClass
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
      //  IUow uowobj = null;
        protected void Open()
        {
            if ((objConn == null) || (objConn.State == ConnectionState.Closed))
            {
                objConn = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["ConString"].ConnectionString);
                objConn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = objConn;
            }
         
        }
        protected void Close()
        {
            //if (uowobj == null)
            //{
               objConn.Close();
            //}
        }
    }
}
