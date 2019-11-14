using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan
{
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "001";
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            string commansString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection Connection = new SqlConnection(commansString);
            //抓最新一筆
            SqlCommand command2 = new SqlCommand($"SELECT TOP 1 id FROM products ORDER BY id desc SELECT SCOPE_IDENTITY()", Connection);
            Connection.Open();
            string nid = command2.ExecuteScalar().ToString();
            Connection.Close();

            //SHOW資料
            SqlCommand command1 = new SqlCommand($"SELECT * FROM products WHERE id=@id ", Connection);
            command1.Parameters.Add("@id", SqlDbType.NVarChar);
            command1.Parameters["@id"].Value = Request.QueryString["id"]??nid;
            StringBuilder subMenuString=new StringBuilder();
            string id = Request.QueryString["id"] ?? nid;
            Connection.Open();
            SqlDataReader ereader = command1.ExecuteReader();
            ereader.Read();
            if (!string.IsNullOrEmpty(ereader["overview"].ToString()))
            {
                subMenuString.Append(@"<li><a class=""menu_yli01"" href=""YachtOverview.aspx?id="+id+@""">Overview</a></li>");
                content.Text = ereader["overview"].ToString();
            }
            if (!string.IsNullOrEmpty(ereader["layout"].ToString()))
            {
                subMenuString.Append(@"<li><a class=""menu_yli02"" href=""YachtLayout.aspx?id=" + id + @""">Layout & deck plan</a></li>");
            }
            if (!string.IsNullOrEmpty(ereader["specification"].ToString()))
            {
                subMenuString.Append(@"<li><a class=""menu_yli03"" href=""YachtSpecification.aspx?id=" + id + @""">Specification</a></li>");
            }

            subMenu.Text = subMenuString.ToString();
            Connection.Close();

            #region 檔案
            SqlCommand command = new SqlCommand($"SELECT * FROM downloads WHERE productID=@id", Connection);
            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = Request.QueryString["id"] ?? nid;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Repeater1.DataSource = dataTable;
            Repeater1.DataBind();
            #endregion
        }
    }
}