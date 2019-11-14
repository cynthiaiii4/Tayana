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
    public partial class NEWS_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "002";
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            #region 文章內容
            string ConnectionStrings = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand("SELECT * from news where id =@id", connection);
            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = Request.QueryString["id"];
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //dataAdapter.Fill(dataTable);
            //title.Text = dataTable.Rows[0][2].ToString();
            //content.Text= dataTable.Rows[0][5].ToString();
            connection.Open();
            SqlDataReader ereader = command.ExecuteReader();
            ereader.Read();
            title.Text= ereader["title"].ToString();
            content.Text = ereader["newsContent"].ToString();
            connection.Close();
            #endregion

            #region 下載內容
            string ConnectionStrings1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection connection1 = new SqlConnection(ConnectionStrings1);
            SqlCommand command1 = new SqlCommand("SELECT * from newsDownloads WHERE newsId=@newsId", connection1);
            command1.Parameters.Add("@newsId", SqlDbType.NVarChar);
            command1.Parameters["@newsId"].Value = Request.QueryString["id"];
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1);
            DataTable dataTable1 = new DataTable();
            dataAdapter1.Fill(dataTable1);
            Repeater1.DataSource = dataTable1;
            Repeater1.DataBind();


            #endregion
        }
    }
}