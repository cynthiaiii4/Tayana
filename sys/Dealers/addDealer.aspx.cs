using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.Dealers
{
    public partial class addDealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "005";
            if (!IsPostBack)
            {
                SearchList();
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
        protected void save_Click(object sender, EventArgs e)
        {
            #region 圖片判斷式
            string ifileName = "";
            if (photo.HasFile)
            {
                if (photo.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    check.Text = "圖片格式錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = Path.GetExtension(photo.FileName);
                //新檔案名稱
                ifileName = String.Format("{0:yyyyMMddhhmmsss}{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                photo.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/dealers/{0}", ifileName)));
                myFunction.GenerateThumbnailImage(ifileName, Server.MapPath("~/sys/uploadfile/dealers/"), Server.MapPath("~/sys/uploadfile/dealers/"), "S", 209, 148);
               
            }
            else
            {
                check.Text = "請上傳圖片";
            }
            #endregion

            check.Text = "";
            if (areaList.SelectedValue=="")
            {
                check.Text += "*請選擇地區";
            }
            if (string.IsNullOrEmpty(country.Value))
            {
                check.Text += "*國家名稱不可以為空";
            }
            if (string.IsNullOrEmpty(dealer.Value))
            {
                check.Text += "*經銷商名稱不可以為空";
            }
            if (string.IsNullOrEmpty(dealerInfo.Value))
            {
                check.Text += "*經銷商資訊不可以為空";
            }
            

            if (string.IsNullOrEmpty(check.Text))
            {
                string ConnectionString = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection Connection = new SqlConnection(ConnectionString);

                #region 寫入主表
                SqlCommand Command =
                    new SqlCommand(
                        $"INSERT INTO dealers(areaID,country,dealer,photo,dealerInfo) VALUES(@areaID,@country,@dealer,@photo,@dealerInfo)",
                        Connection);
                Command.Parameters.Add("@areaID", SqlDbType.NVarChar);
                Command.Parameters["@areaID"].Value = areaList.SelectedValue;
                Command.Parameters.Add("@country", SqlDbType.NVarChar);
                Command.Parameters["@country"].Value = country.Value;
                Command.Parameters.Add("@dealer", SqlDbType.NVarChar);
                Command.Parameters["@dealer"].Value = dealer.Value;
                Command.Parameters.Add("@photo", SqlDbType.NVarChar);
                Command.Parameters["@photo"].Value = ifileName;
                Command.Parameters.Add("@dealerInfo", SqlDbType.NVarChar);
                Command.Parameters["@dealerInfo"].Value = dealerInfo.Value;
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

                #endregion

                Response.Redirect("~/sys/Dealers/Dealers.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sys/Dealers/Dealers.aspx");
        }
    }
}