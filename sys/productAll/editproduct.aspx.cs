using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.productAll
{
    public partial class editproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //偷放個隱藏欄位並賦值控制左側表單亮亮的
                HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
                hiddenyo.Value = "002";

                string EdiAcount = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection editConnection = new SqlConnection(EdiAcount);
                SqlCommand editCommand =
                    new SqlCommand($" Select * from products where id=@Eid", editConnection);
                editCommand.Parameters.Add("@Eid", SqlDbType.NVarChar);
                editCommand.Parameters["@Eid"].Value = Request.QueryString["id"];

                editConnection.Open();
                SqlDataReader ereader = editCommand.ExecuteReader();
                ereader.Read();
                series.Value = ereader["series"].ToString();
                number.Value = ereader["number"].ToString();
                overview.Value = ereader["overview"].ToString();
                layout.Value = ereader["layout"].ToString();
                specification.Value = ereader["specification"].ToString();
                editConnection.Close();
            }
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            check.Text = "";
            if (string.IsNullOrEmpty(series.Value))
            {
                check.Text += "*系列不可以為空";
            }
            if (string.IsNullOrEmpty(number.Value))
            {
                check.Text += "*型號不可以為空";
            }

            if (string.IsNullOrEmpty(check.Text))
            {
                string ConnectionString = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection Connection = new SqlConnection(ConnectionString);

                #region 寫入主表
                SqlCommand Command =
                    new SqlCommand(
                        $"UPDATE products SET series=@series,number=@number,overview=@overview,layout=@layout,specification=@specification where id=@Eid",
                        Connection);
                Command.Parameters.Add("@Eid", SqlDbType.NVarChar);
                Command.Parameters["@Eid"].Value = Request.QueryString["id"];
                Command.Parameters.Add("@series", SqlDbType.NVarChar);
                Command.Parameters["@series"].Value = series.Value;
                Command.Parameters.Add("@number", SqlDbType.NVarChar);
                Command.Parameters["@number"].Value = number.Value;
                Command.Parameters.Add("@overview", SqlDbType.NVarChar);
                Command.Parameters["@overview"].Value = overview.Value;
                Command.Parameters.Add("@layout", SqlDbType.NVarChar);
                Command.Parameters["@layout"].Value = layout.Value;
                Command.Parameters.Add("@specification", SqlDbType.NVarChar);
                Command.Parameters["@specification"].Value = specification.Value;

                Connection.Open();
                int nid = Convert.ToInt32(Command.ExecuteScalar());
                Connection.Close();

                #endregion

                string page = Request["page"] ?? "1";
                Response.Redirect($"~/sys/productAll/products.aspx?page={page}");

            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            string page = Request["page"] ?? "1";
            Response.Redirect($"~/sys/productAll/products.aspx?page={page}");
        }

    }
}