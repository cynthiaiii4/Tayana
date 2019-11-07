using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.NEWS
{
    public partial class addNEWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "004";
        }
        protected void save_Click(object sender, EventArgs e)
        {
            #region 圖片判斷式
            string ifileName = "";
            if (img.HasFile)
            {
                if (img.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    check.Text = "圖片格式錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = Path.GetExtension(img.FileName);
                //新檔案名稱
                ifileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                img.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/images/{0}", ifileName)));
            }
            else
            {
                check.Text = "請上傳圖片";
            }
            #endregion

            

            check.Text = "";
            if (string.IsNullOrEmpty(title.Value))
            {
                check.Text += "*標題不可以為空";
            }
            if (string.IsNullOrEmpty(summary.Value))
            {
                check.Text += "*摘要不可以為空";
            }
            if (string.IsNullOrEmpty(newsContent.Value))
            {
                check.Text += "*內容不可以為空";
            }

            if (string.IsNullOrEmpty(check.Text))
            {
                string ConnectionString = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection Connection = new SqlConnection(ConnectionString);

                #region 寫入主表
                SqlCommand Command =
                    new SqlCommand(
                        $"INSERT INTO news(title,summary,img,newsContent,topNews) VALUES(@title,@summary,@img,@newsContent,@topNews)",
                        Connection);
                Command.Parameters.Add("@title", SqlDbType.NVarChar);
                Command.Parameters["@title"].Value = title.Value;
                Command.Parameters.Add("@summary", SqlDbType.NVarChar);
                Command.Parameters["@summary"].Value = summary.Value;
                Command.Parameters.Add("@img", SqlDbType.NVarChar);
                Command.Parameters["@img"].Value = ifileName;
                Command.Parameters.Add("@newsContent", SqlDbType.NVarChar);
                Command.Parameters["@newsContent"].Value = newsContent.Value;
                Command.Parameters.Add("@topNews", SqlDbType.NVarChar);
                if (topNews.Checked)
                {
                    Command.Parameters["@topNews"].Value = true;
                }
                else
                {
                    Command.Parameters["@topNews"].Value = false;
                }
                

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

                #endregion

                Response.Redirect("~/sys/NEWS/NEWS.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sys/NEWS/NEWS.aspx");
        }
    }
}