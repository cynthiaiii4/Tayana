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
            string searchString = "";
            string commandString =
                $"WITH ClassData AS\r\n(\r\nselect\r\nROW_NUMBER() OVER(ORDER BY topNews desc,id desc) AS RowNumber\r\n,* from dbo.news \r\n\r\nwhere 1=1\r\n\r\n/*--where begin --*/\r\n\r\n/*--where End--*/\r\n)\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end";
            if (!string.IsNullOrEmpty(timeStart.Value))
            {
                searchString += "and initDate>@timeStart ";
            }
            if (!string.IsNullOrEmpty(timeEnd.Value))
            {
                searchString += "and initDate<@timeEnd ";
            }
            if (!string.IsNullOrEmpty(keyword.Value))
            {
                searchString += " and ((title LIKE '%'+ @keyword +'%') OR (summary LIKE '%'+ @keyword + '%') OR (newsContent LIKE '%' + @keyword +'%'))";
            }

            commandString = commandString.Replace("/*--where begin --*/",
                String.Format("/*--where begin --*/{0}{1}", Environment.NewLine, searchString));
            //分頁
            SqlCommand showcommand = new SqlCommand(commandString, memberConnection);
            int currentPage = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            int pageSize = 10;
            showcommand.Parameters.Add("@start", SqlDbType.Int);
            showcommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            showcommand.Parameters.Add("@end", SqlDbType.Int);
            showcommand.Parameters["@end"].Value = currentPage * pageSize;
            showcommand.Parameters.Add("@keyword", SqlDbType.NVarChar);
            showcommand.Parameters["@keyword"].Value = keyword.Value;
            if (!string.IsNullOrEmpty(timeStart.Value))
            {
                showcommand.Parameters.Add("@timeStart", SqlDbType.DateTime);
                showcommand.Parameters["@timeStart"].Value = DateTime.Parse(timeStart.Value).ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(timeEnd.Value))
            {
                showcommand.Parameters.Add("@timeEnd", SqlDbType.DateTime);
                showcommand.Parameters["@timeEnd"].Value = DateTime.Parse(timeEnd.Value).AddDays(1).ToString("yyyy-MM-dd");
            }
            //show總筆數
            string countString = "Select count(*) from news WHERE 1=1 /*--where begin --*/";
            countString = countString.Replace("/*--where begin --*/",
                String.Format("/*--where begin --*/{0}{1}", Environment.NewLine, searchString));
            SqlCommand count = new SqlCommand(countString, memberConnection);
            count.Parameters.Add("@keyword", SqlDbType.NVarChar);
            count.Parameters["@keyword"].Value = keyword.Value;
            if (!string.IsNullOrEmpty(timeStart.Value))
            {
                count.Parameters.Add("@timeStart", SqlDbType.DateTime);
                count.Parameters["@timeStart"].Value = DateTime.Parse(timeStart.Value).ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(timeEnd.Value))
            {
                count.Parameters.Add("@timeEnd", SqlDbType.DateTime);
                count.Parameters["@timeEnd"].Value = DateTime.Parse(timeEnd.Value).AddDays(1).ToString("yyyy-MM-dd");
            }
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
            string page = Request["page"] ?? "1";
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

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "True")
                {
                    e.Row.Cells[4].Text = "✔";
                }
                else
                {
                    e.Row.Cells[4].Text = "";
                }

            }
        }
    }
}