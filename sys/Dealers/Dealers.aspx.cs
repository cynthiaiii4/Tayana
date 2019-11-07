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
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //偷放個隱藏欄位並賦值
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "005";
            if (!IsPostBack)
            {

                if (Session["areaList"] != null)
                {
                    areaList.SelectedValue = Session["areaList"].ToString();
                }
                if (Session["keyword"] != null)
                {
                    keyword.Value = Session["keyword"].ToString();
                }
                SearchList();
                showData();
            }
        }
        public void SearchList()
        {
            string sqlN = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sqlN); //建立連線通道

            //area下拉選單
            SqlCommand namecommand = new SqlCommand($"SELECT * FROM area", memberConnection);
            SqlDataAdapter dataAdapterN = new SqlDataAdapter(namecommand);
            DataTable dataTableN = new DataTable();
            dataAdapterN.Fill(dataTableN); //這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            areaList.DataSource = dataTableN;
            areaList.DataTextField = "area";
            areaList.DataValueField = "id";
            areaList.DataBind();
            areaList.Items.Insert(0, new ListItem("請選擇地區", ""));

        }
        public void showData()
        {
            
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            string commandString =
                $"WITH ClassData AS\r\n(select ROW_NUMBER() OVER(ORDER BY [dbo].[Dealers].id desc) AS RowNumber,* ,(SELECT area from [dbo].[area] where [dbo].[area].id=[dbo].[Dealers].areaID)as area from [dbo].[Dealers] where 1=1\r\n/*--where begin --*/)\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end";
            string searchString = "";

            if (areaList.SelectedValue != "")
            {
                searchString += " and  areaID=@areaID ";
            }


            if (!string.IsNullOrEmpty(keyword.Value))
            {
                searchString += " and ((country LIKE '%' + @keyword + '%') OR (dealer LIKE '%' + @keyword + '%'))  ";
            }

            commandString = commandString.Replace("/*--where begin --*/",
                string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));
            SqlCommand sqlCommand = new SqlCommand(commandString, memberConnection);
            //處理參數
            //分頁
            int currentPage = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            int pageSize = 10;
            sqlCommand.Parameters.Add("@start", SqlDbType.Int);
            sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            sqlCommand.Parameters.Add("@end", SqlDbType.Int);
            sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
            if (areaList.SelectedValue!="")
            {
                sqlCommand.Parameters.Add("@areaID", SqlDbType.Int);
                sqlCommand.Parameters["@areaID"].Value = Convert.ToInt32(areaList.SelectedValue);
            }

            sqlCommand.Parameters.Add("@keyword", SqlDbType.NVarChar);
            sqlCommand.Parameters["@keyword"].Value = keyword.Value ?? "";
            

            //show資料
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView1.DataSource = datatable;
            GridView1.DataBind();

            #region 總筆數

            string countString = "SELECT count(*)from dealers where 1=1";
            countString = countString.Replace($"where 1=1 {0}", searchString);
            SqlCommand count = new SqlCommand(countString, memberConnection);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(count);
            DataTable datatable1 = new DataTable();
            dataAdapter1.Fill(datatable1);
            PageControl.totalitems = Convert.ToInt32(datatable1.Rows[0][0]);
            PageControl.limit = pageSize;
            PageControl.targetpage = "/sys/Dealers/Dealers.aspx";
            PageControl.showPageControls();
            #endregion
            
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            string page = Request["page"] ?? "1";
            Response.Redirect($"editDealer.aspx?id={Rid}&page={page}");
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from dealers where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            showData();
        }
        protected void search_Click(object sender, EventArgs e)
        {
            Session.Remove("area");
            Session.Remove("keyword");



            if (!string.IsNullOrEmpty(areaList.SelectedValue))
            {
                Session["areaList"] = areaList.SelectedValue;
            }

            if (!string.IsNullOrEmpty(keyword.Value))
            {
                Session["keyword"] = keyword.Value;
            }


            Response.Redirect("Dealers.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Session.Remove("areaList");
            Session.Remove("keyword");
            Response.Redirect("Dealers.aspx");
        }
    }
}