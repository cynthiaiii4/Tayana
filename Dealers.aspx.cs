using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "004";
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            string ConnectionStrings = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand("SELECT id, areaID, country, photo, dealer, dealerInfo,(SELECT area from area WHERE [dbo].[area].id=[dbo].[dealers].areaID)as area \r\nFROM dealers WHERE areaID=@areaID", connection);
            command.Parameters.Add("@areaID", SqlDbType.Int);
            command.Parameters["@areaID"].Value = Request.QueryString["id"]??"1";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Repeater1.DataSource = dataTable;
            Repeater1.DataBind();
        }

    }
}