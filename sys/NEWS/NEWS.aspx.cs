using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.NEWS
{
    public partial class NEWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
                hiddenyo.Value = "004";
                if (!IsPostBack)
                {
                    if (Session["timeStart"] != null)
                    {
                        timeStart.Value = Session["timeStart"].ToString();
                    }

                    if (Session["timeEnd"] != null)
                    {
                        timeEnd.Value = Session["timeEnd"].ToString();
                    }

                    if (Session["keyword"] != null)
                    {
                        keyword.Value = Session["keyword"].ToString();
                    }
                    ShowData();
                }
        }

        public void ShowData()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道

            //分頁
            SqlCommand showcommand = new SqlCommand($"WITH ClassData AS\r\n(\r\n/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/\r\n\r\nselect\r\nROW_NUMBER() OVER(ORDER BY topNews,id desc) AS RowNumber\r\n,* from dbo.news \r\n\r\nwhere 1=1\r\n\r\n/*--where begin --*/\r\n\r\n/*--where End--*/\r\n)\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end", memberConnection);
            int currentPage = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            int pageSize = 10;
            showcommand.Parameters.Add("@start", SqlDbType.Int);
            showcommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            showcommand.Parameters.Add("@end", SqlDbType.Int);
            showcommand.Parameters["@end"].Value = currentPage * pageSize;
            //show總筆數
            SqlCommand count = new SqlCommand("Select count(*) from news", memberConnection);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(count);
            DataTable datatable1 = new DataTable();
            dataAdapter1.Fill(datatable1);
            PageControl.totalitems = Convert.ToInt32(datatable1.Rows[0][0]);
            PageControl.limit = pageSize;
            PageControl.targetpage = "/sys/NEWS/NEWS.aspx";
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
            SqlCommand deletecommand = new SqlCommand($" Delete from news where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            ShowData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            string page = Request["page"] ?? "1";
            Response.Redirect($"editNEWS.aspx?id={Rid}&page={page}");
        }
        protected void search_Click(object sender, EventArgs e)
        {
            Session.Remove("timeStart");
            Session.Remove("timeEnd");
            Session.Remove("keyword");
            if (!string.IsNullOrEmpty(timeStart.Value))
            {
                Session["timeStart"] = Convert.ToDateTime(timeStart.Value);
            }

            if (!string.IsNullOrEmpty(timeEnd.Value))
            {
                Session["timeEnd"] = ((Convert.ToDateTime(timeEnd.Value)).AddDays(1));
            }


            if (!string.IsNullOrEmpty(keyword.Value))
            {
                Session["keyword"] = keyword.Value;
            }

            Response.Redirect("NEWS.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Session.Remove("timeStart");
            Session.Remove("timeEnd");
            Session.Remove("keyword");
            Response.Redirect("NEWS.aspx");
        }
    }
}