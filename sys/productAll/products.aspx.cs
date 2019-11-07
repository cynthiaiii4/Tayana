using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.productAll
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //偷放個隱藏欄位並賦值
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "002";
            if (!IsPostBack)
            {

                if (Session["seriesList"] != null)
                {
                    seriesList.SelectedValue = Session["seriesList"].ToString();
                }
                if (Session["numberList"] != null)
                {
                    numberList.SelectedValue = Session["numberList"].ToString();
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

            //series下拉選單
            SqlCommand namecommand = new SqlCommand($"SELECT DISTINCT series FROM products", memberConnection);
            SqlDataAdapter dataAdapterN = new SqlDataAdapter(namecommand);
            DataTable dataTableN = new DataTable();
            dataAdapterN.Fill(dataTableN); //這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            seriesList.DataSource = dataTableN;
            seriesList.DataTextField = "series";
            seriesList.DataValueField = "series";
            seriesList.DataBind();
            seriesList.Items.Insert(0, new ListItem("請選擇系列", ""));


            //number下拉選單
            SqlCommand command = new SqlCommand($"SELECT DISTINCT number FROM products", memberConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable); //這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            numberList.DataSource = dataTable;
            numberList.DataTextField = "number";
            numberList.DataValueField = "number";
            numberList.DataBind();
            numberList.Items.Insert(0, new ListItem("請選擇型號", ""));
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from products where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            showData();
        }

        public void showData()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道

            string commandString =
                $"WITH ClassData AS\r\n(\r\n/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/\r\n\r\nselect\r\nROW_NUMBER() OVER(ORDER BY id desc) AS RowNumber\r\n,id,series,number,(SELECT top 1 img from images where productID=[dbo].[products].id)AS img from dbo.products \r\n\r\nwhere 1=1\r\n\r\n/*--where begin --*/\r\n\r\n/*--where End--*/\r\n)\r\nselect * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end";
            string searchString = "";
            if (seriesList.SelectedValue != "")
            {
                searchString += " and  series=@series ";
            }
            if (numberList.SelectedValue != "")
            {
                searchString += " and  number=@number ";
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
            showcommand.Parameters.Add("@series", SqlDbType.NVarChar);
            showcommand.Parameters["@series"].Value = seriesList.SelectedValue;
            showcommand.Parameters.Add("@number", SqlDbType.NVarChar);
            showcommand.Parameters["@number"].Value = numberList.SelectedValue;
            //show資料
            SqlDataAdapter dataAdapter = new SqlDataAdapter(showcommand);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView1.DataSource = datatable;
            GridView1.DataBind();
            //show總筆數

            string countString = $"Select count(*) from products WHERE 1=1\r\n/*--where begin --*/";
            countString = countString.Replace("/*--where begin --*/",
                String.Format("/*--where begin --*/{0}{1}", Environment.NewLine, searchString));
            SqlCommand count = new SqlCommand(countString, memberConnection);
            count.Parameters.Add("@series", SqlDbType.NVarChar);
            count.Parameters["@series"].Value = seriesList.SelectedValue;
            count.Parameters.Add("@number", SqlDbType.NVarChar);
            count.Parameters["@number"].Value = numberList.SelectedValue??"";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(count);
            DataTable datatable1 = new DataTable();
            dataAdapter1.Fill(datatable1);
            PageControl.totalitems = Convert.ToInt32(datatable1.Rows[0][0]);
            PageControl.limit = pageSize;
            PageControl.targetpage = "/sys/products/products.aspx";
            PageControl.showPageControls();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            string page = Request["page"] ?? "1";
            Response.Redirect($"editproduct.aspx?id={Rid}&page={page}");
        }
        protected void search_Click(object sender, EventArgs e)
        {
            Session.Remove("seriesList");
            Session.Remove("numberList");
          
           

            if (!string.IsNullOrEmpty(seriesList.SelectedValue))
            {
                Session["seriesList"] = seriesList.SelectedValue;
            }

            if (!string.IsNullOrEmpty(numberList.SelectedValue))
            {
                Session["numberList"] = numberList.SelectedValue;
            }

            
            Response.Redirect("products.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Session.Remove("seriesList");
            Session.Remove("numberList");
            

            Response.Redirect("products.aspx");
        }
    }
}