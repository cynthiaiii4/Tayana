using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.Dealers
{
    public partial class addArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField) Master.FindControl("hiddenyo");
            hiddenyo.Value = "005";
            if (!IsPostBack)
            {
                ShowData();
            }
        }
    

    public void ShowData()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道

            //分頁
            SqlCommand showcommand = new SqlCommand($"WITH ClassData AS\r\n(\r\n/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/\r\n\r\nselect\r\nROW_NUMBER() OVER(ORDER BY id desc) AS RowNumber\r\n,* from dbo.area \r\n\r\nwhere 1=1\r\n\r\n/*--where begin --*/\r\n\r\n/*--where End--*/\r\n)\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end", memberConnection);
            int currentPage = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            int pageSize = 10;
            showcommand.Parameters.Add("@start", SqlDbType.Int);
            showcommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            showcommand.Parameters.Add("@end", SqlDbType.Int);
            showcommand.Parameters["@end"].Value = currentPage * pageSize;
            //show總筆數
            SqlCommand count = new SqlCommand("Select count(*) from area", memberConnection);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(count);
            DataTable datatable1 = new DataTable();
            dataAdapter1.Fill(datatable1);
            PageControl.totalitems = Convert.ToInt32(datatable1.Rows[0][0]);
            PageControl.limit = pageSize;
            PageControl.targetpage = "/sys/Dealers/Area.aspx";
            PageControl.showPageControls();

            //show資料
            SqlDataAdapter dataAdapter = new SqlDataAdapter(showcommand);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView1.DataSource = datatable;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from area where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            ShowData();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string ConnectionString = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand searchCommand =new SqlCommand("Select * from area where area=@search", Connection);
            searchCommand.Parameters.Add("search", area.Value);
            Connection.Open();
            SqlDataReader checkarea = searchCommand.ExecuteReader();
            if (checkarea.Read())
            {
                check.Text = "此區域已存在";
            }
            else
            {
                SqlCommand Command = new SqlCommand($"INSERT INTO area(area) VALUES(@area)", Connection);
                Command.Parameters.Add("@area", SqlDbType.NVarChar);
                Command.Parameters["@area"].Value = area.Value;
                checkarea.Close();
                Command.ExecuteNonQuery();
            }
            Connection.Close();
            ShowData();
        }
    }
}