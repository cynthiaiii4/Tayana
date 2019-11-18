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
    public partial class editNEWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "004";
            if (!IsPostBack)
            {
                showData();
            }
        }

        public void showData()
        {
            #region 內容
            string EdiAcount = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection editConnection = new SqlConnection(EdiAcount);
            SqlCommand editCommand =
                new SqlCommand($" Select * from news where id=@Eid", editConnection);
            editCommand.Parameters.Add("@Eid", SqlDbType.NVarChar);
            editCommand.Parameters["@Eid"].Value = Request.QueryString["id"];

            editConnection.Open();
            SqlDataReader ereader = editCommand.ExecuteReader();
            ereader.Read();
            title.Value = ereader["title"].ToString();
            summary.Value = ereader["summary"].ToString();
            Image1.ImageUrl = @"/sys/uploadfile/images/" + ereader["img"].ToString();
            hiddenP.Value = ereader["img"].ToString();
            newsContent.Value = ereader["newsContent"].ToString();
            if (ereader["topNews"].ToString() == "True")
            {
                topNews.Checked = true;
            }

            editConnection.Close();
            #endregion

            #region 檔案
            SqlCommand Command =
                new SqlCommand($" Select id,showname, filename from newsDownloads where newsId=@Eid", editConnection);
            Command.Parameters.Add("@Eid", SqlDbType.NVarChar);
            Command.Parameters["@Eid"].Value = Request.QueryString["id"];
            SqlDataAdapter dataAdapter=new SqlDataAdapter(Command);
            DataTable dataTable=new DataTable();
            dataAdapter.Fill(dataTable);
            GridView2.DataSource = dataTable;
            GridView2.DataBind();

            #endregion
        }
        protected void uploadfile_Click(object sender, EventArgs e)
        {
            //清空提示語
            check.Text = "";
            string ConnectionString = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            if (FileUpload1.HasFile)
            {
                int i = 1;
                foreach (var item in FileUpload1.PostedFiles)
                {
                    //取得副檔名
                    string Extension = Path.GetExtension(item.FileName);
                    //取得原檔名
                    string itemname = Path.GetFileName(item.FileName);
                    //新檔案名稱
                    string ofileName = String.Format("N{0:yyyyMMddhhmmsss}-{1}{2}", DateTime.Now, i, Extension);
                    //上傳目錄為/upload/Images/
                    FileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/files/{0}", ofileName)));
                    i++;
                    SqlCommand oCommand =
                        new SqlCommand(
                            $"INSERT INTO newsDownloads(newsId,filename,showname) VALUES(@newsId,@filename,@showname) ",
                            Connection);
                    oCommand.Parameters.Add("@newsId", SqlDbType.NVarChar);
                    oCommand.Parameters["@newsId"].Value = Request.QueryString["id"];
                    oCommand.Parameters.Add("@filename", SqlDbType.NVarChar);
                    oCommand.Parameters["@filename"].Value = ofileName;
                    oCommand.Parameters.Add("@showname", SqlDbType.NVarChar);
                    oCommand.Parameters["@showname"].Value = itemname;
                    Connection.Open();
                    oCommand.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            showData();
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
                myFunction.GenerateThumbnailImage(ifileName, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"), "L", 161, 121);
                myFunction.GenerateThumbnailImage(ifileName, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"), "I", 95, 95);
            }
           
            #endregion
            #region 其他判斷式
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

                
                SqlCommand Command =
                    new SqlCommand(
                        $"UPDATE news SET title=@title,summary=@summary,img=@img,newsContent=@newsContent,topNews=@topNews WHERE id=@id",
                        Connection);
                Command.Parameters.Add("@id", SqlDbType.NVarChar);
                Command.Parameters["@id"].Value = Request.QueryString["id"];
                Command.Parameters.Add("@title", SqlDbType.NVarChar);
                Command.Parameters["@title"].Value = title.Value;
                Command.Parameters.Add("@summary", SqlDbType.NVarChar);
                Command.Parameters["@summary"].Value = summary.Value;
                Command.Parameters.Add("@img", SqlDbType.NVarChar);
                if (img.HasFile)
                {
                    Command.Parameters["@img"].Value = ifileName;
                }
                else
                {
                    Command.Parameters["@img"].Value = hiddenP.Value;
                }
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
                string page = Request["page"] ?? "1";
                Response.Redirect($"~/sys/NEWS/NEWS.aspx?page={page}");
            }

        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView2.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from newsDownloads where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            showData();
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            string page = Request["page"] ?? "1";
            Response.Redirect($"~/sys/NEWS/NEWS.aspx?page={page}");
        }
    }
}