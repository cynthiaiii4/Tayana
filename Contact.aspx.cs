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
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "005";
            if (!IsPostBack)
            {
                AreaList();
                YachtList();
            }
        }

        protected void AreaList()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);
            SqlCommand command = new SqlCommand($"SELECT * FROM area", memberConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            areaList.DataSource = dataTable;
            areaList.DataTextField = "area";
            areaList.DataValueField = "area";
            areaList.DataBind();
            
        }

        protected void YachtList()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);
            SqlCommand command = new SqlCommand($"SELECT id,(series+'-'+number)as yacht FROM products", memberConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            yachtList.DataSource = dataTable;
            yachtList.DataTextField = "yacht";
            yachtList.DataValueField = "yacht";
            yachtList.DataBind();
        }

        protected void submitBTN_Click(object sender, EventArgs e)
        {
            string fromAddress = "chunchun1913@gmail.com";
            string pwd = "longtime30@";
            string subject = "顧客來信-"+Name.Value;
            string toAddress = "cynthiaiii4@hotmail.com";
            string message =
                $"<div class=\"from01\">\r\n<p>\r\n</p>\r\n<br/>\r\n<table>\r\n<tr>\r\n<td class=\"from01td01\">Name :</td>\r\n<td>{Name.Value}\r\n</td>\r\n</tr>\r\n<tr>\r\n<td class=\"from01td01\">Email :</td>\r\n<td>{Email.Value}</td>\r\n</tr>\r\n<tr>\r\n<td class=\"from01td01\">Phone :</td>\r\n<td>{Phone.Value}</td>\r\n</tr>\r\n<tr>\r\n<td class=\"from01td01\">Country :</td>\r\n<td>\r\n{areaList.Text}\r\n\r\n</tr>\r\n<tr>\r\n</tr>\r\n<tr>\r\n<td class=\"from01td01\"> Yacht:</td>\r\n <td>\r\n{yachtList.SelectedValue}\r\n</td>\r\n</tr>\r\n<tr>\r\n<td class=\"from01td01\">Comments:</td>\r\n<td>\r\n{Comments.Value}</td>";
            
            myFunction.SendGmailMail(fromAddress,toAddress,subject,message,pwd);
            Response.Redirect("Contact.aspx");
        }
    }
}