using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tayan.sys.members
{
    /// <summary>
    /// checkID 的摘要描述
    /// </summary>
    public class checkID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string checkID = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection checkIDConnection=new SqlConnection(checkID);
            SqlCommand checkIDCommand=new SqlCommand("SELECT UID FROM account WHERE UID=@UID", checkIDConnection);
            checkIDCommand.Parameters.Add("@UID", SqlDbType.NVarChar);
            checkIDCommand.Parameters["@UID"].Value = context.Request["UID"];
            checkIDConnection.Open();
            SqlDataReader sqlDataReader = checkIDCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                context.Response.Write("NO");
            }
            else
            {
                context.Response.Write("OK");
            }
            checkIDConnection.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}