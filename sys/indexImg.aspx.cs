using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys
{
    public partial class indexImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //偷放個隱藏欄位並賦值
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "003";
            if (!IsPostBack)
            {
                showData();
            }
        }
        public void showData()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道

            //分頁
            SqlCommand showcommand = new SqlCommand($"WITH ClassData AS\r\n(select ROW_NUMBER() OVER(ORDER BY [dbo].[products].id desc) AS RowNumber,* ,(SELECT img from [dbo].[images] where productID=[dbo].[products].id and [dbo].[images].indexPage = 1)as img from [dbo].[products] )\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end", memberConnection);
            //select * ,(SELECT series from[dbo].[products] where[dbo].[products].id=productID)as serie,(SELECT number from[dbo].[products] where[dbo].[products].id=productID)as number
            //from[dbo].[images] where[dbo].[images].indexPage = 1
            int currentPage = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            int pageSize = 10;
            showcommand.Parameters.Add("@start", SqlDbType.Int);
            showcommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            showcommand.Parameters.Add("@end", SqlDbType.Int);
            showcommand.Parameters["@end"].Value = currentPage * pageSize;
            //show總筆數
            SqlCommand count = new SqlCommand("Select count(*) from images", memberConnection);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(count);
            DataTable datatable1 = new DataTable();
            dataAdapter1.Fill(datatable1);
            PageControl.totalitems = Convert.ToInt32(datatable1.Rows[0][0]);
            PageControl.limit = pageSize;
            PageControl.targetpage = "indexImg.aspx";
            PageControl.showPageControls();

            //show資料
            SqlDataAdapter dataAdapter = new SqlDataAdapter(showcommand);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView1.DataSource = datatable;
            GridView1.DataBind();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            string sql2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection2 = new SqlConnection(sql2);//建立連線通道
            SqlCommand command2 = new SqlCommand($" UPDATE images SET indexPage=@indexPage where id=@id", memberConnection2);
            command2.Parameters.Add("@id", SqlDbType.NVarChar);
            command2.Parameters["@id"].Value = Rid;
            command2.Parameters.Add("@indexPage", SqlDbType.NVarChar);
            command2.Parameters["@indexPage"].Value = 0;
            
            memberConnection2.Open();
            command2.ExecuteNonQuery();
            memberConnection2.Close();

            Response.Redirect("indexImg.aspx");
        }

    }
}