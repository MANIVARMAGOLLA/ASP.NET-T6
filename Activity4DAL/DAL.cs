using Activity6DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity6DAL
{
    public class DAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public DAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }


        public int InsertIntoDept(DTO newdto )
        {
         
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["AdvWorksDBConnStr"].ConnectionString;
                sqlCmdObj.CommandText = @"[dbo].[usp_Department]";
                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Connection = sqlConObj;
                sqlCmdObj.Parameters.AddWithValue("@IP1", newdto.DepartmentId);
                sqlCmdObj.Parameters.AddWithValue("@IP2", newdto.Name);
                

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                sqlCmdObj.Parameters.Add(prmReturn);
                sqlConObj.Open();
                sqlCmdObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
