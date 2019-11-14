using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.productAll
{
    public partial class editPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //偷放個隱藏欄位並賦值
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "002";

            if (!IsPostBack)
            {
                showData();
            }
        }
        public void showData()
        {
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道

            //show照片
            SqlCommand showcommand = new SqlCommand($"select * from images WHERE productID=@productID", memberConnection);
            showcommand.Parameters.Add("@productID", SqlDbType.Int);
            showcommand.Parameters["@productID"].Value = Convert.ToInt32(Context.Request["id"]);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(showcommand);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView1.DataSource = datatable;
            GridView1.DataBind();

            //show檔案
            SqlCommand showcommand2 = new SqlCommand($"select * from downloads WHERE productID=@productID", memberConnection);
            showcommand2.Parameters.Add("@productID", SqlDbType.Int);
            showcommand2.Parameters["@productID"].Value = Convert.ToInt32(Context.Request["id"]);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(showcommand2);
            DataTable datatable2 = new DataTable();
            dataAdapter2.Fill(datatable2);//這一行做很多事，代表，把通道打開，把資料放進dataset裡，再把通道關起來
            GridView2.DataSource = datatable2;
            GridView2.DataBind();
          


        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from images where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            showData();
        }


        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Rid = GridView2.DataKeys[e.RowIndex].Value.ToString();
            string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString;
            SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
            SqlCommand deletecommand = new SqlCommand($" Delete from downloads where id={Rid}", memberConnection);

            memberConnection.Open();
            deletecommand.ExecuteNonQuery();
            memberConnection.Close();
            showData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                
                case "changNew":
                    //抓到這個button
                    Button BTN = (Button)e.CommandSource;
                    // 用NamingContainer抓到你按下的按鈕在GridView「哪一列」
                    GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                    //抓到是資料表的哪個ID
                    string Rid = GridView1.DataKeys[myRow.RowIndex].Value.ToString();
                    string sql1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                        .ConnectionString;
                    SqlConnection memberConnection = new SqlConnection(sql1);//建立連線通道
                    SqlCommand command = new SqlCommand($" UPDATE images SET new=@new where id=@id", memberConnection);
                    command.Parameters.Add("@id", SqlDbType.NVarChar);
                    command.Parameters["@id"].Value = Rid;
                    command.Parameters.Add("@new", SqlDbType.NVarChar);
                    if (myRow.Cells[3].Text == "✔")
                    {
                        command.Parameters["@new"].Value = false;
                    }
                    else
                    {
                        command.Parameters["@new"].Value = true;
                    }
                    memberConnection.Open();
                    command.ExecuteNonQuery();
                    memberConnection.Close();
                    showData();
                    return;
                case "changeIndex":
                    //抓到這個button
                    Button BTN2 = (Button)e.CommandSource;
                    // 用NamingContainer抓到你按下的按鈕在GridView「哪一列」
                    GridViewRow myRow2 = (GridViewRow)BTN2.NamingContainer;
                    //抓到是資料表的哪個ID
                    string Rid2 = GridView1.DataKeys[myRow2.RowIndex].Value.ToString();
                    string sql2 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                        .ConnectionString;
                    SqlConnection memberConnection2 = new SqlConnection(sql2);//建立連線通道
                    SqlCommand command3 = new SqlCommand(@"UPDATE images SET indexPage=null where id=@id", memberConnection2);
                    SqlCommand command2 = new SqlCommand($" UPDATE images SET indexPage=@indexPage where id=@id" , memberConnection2);
                    command3.Parameters.Add("@id", SqlDbType.NVarChar);
                    command3.Parameters["@id"].Value = Rid2;
                    command2.Parameters.Add("@id", SqlDbType.NVarChar);
                    command2.Parameters["@id"].Value = Rid2;
                    command2.Parameters.Add("@indexPage", SqlDbType.NVarChar);
                    if (myRow2.Cells[2].Text== "✔")
                    {
                        command2.Parameters["@indexPage"].Value = "";
                    }
                    else
                    {
                        command2.Parameters["@indexPage"].Value = true;
                    }
                    memberConnection2.Open();
                    command3.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    memberConnection2.Close();
                    showData();
                    return;

            }

        }

        protected void uploadPhoto_Click(object sender, EventArgs e)
        {
            //清空提示語
            check.Text = "";
            string ConnectionString = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            #region 其他照片判斷式
            List<string> fileName = new List<string>();
            string singlefile = "";
            String[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            if (images.HasFile)
            {
                int i = 1;
                foreach (var item in images.PostedFiles)
                {
                    if (item.ContentType.IndexOf("image") == -1)
                    {
                        check.Text = "首頁照片格式錯誤!";
                        return;
                    }

                    //取得副檔名
                    string Extension = Path.GetExtension(item.FileName);
                    //新檔案名稱
                    singlefile = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}",DateTime.Now,i, Extension);
                    //存進陣列
                    fileName.Add(singlefile);
                    //上傳目錄為/Images/
                    images.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/images/{0}", singlefile)));
                    myFunction.GenerateThumbnailImage(singlefile, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"), "S", 200, 63);
                    myFunction.GenerateThumbnailImage(singlefile, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"), "B", 967, 449);
                    i++;
                }

            }
            #endregion
            #region 寫入其他照片
            foreach (var item in fileName)
            {
                SqlCommand oCommand =
                    new SqlCommand(
                        $"INSERT INTO images(productID,img) VALUES(@productID,@img)",
                        Connection);
                oCommand.Parameters.Add("@productID", SqlDbType.NVarChar);
                oCommand.Parameters["@productID"].Value = Request.QueryString["id"];
                oCommand.Parameters.Add("@img", SqlDbType.NVarChar);
                oCommand.Parameters["@img"].Value = item;
                Connection.Open();
                oCommand.ExecuteNonQuery();
                Connection.Close();
            }
            #endregion
            showData();
        }

        protected void uploadfile_Click(object sender, EventArgs e)
        {
            //清空提示語
            check.Text = "";
            string ConnectionString = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectionString);

            if(files.HasFile)
            {
                int i = 1;
                foreach (var item in files.PostedFiles)
                {
                    //取得副檔名
                    string Extension = Path.GetExtension(item.FileName);
                    //取得原檔名
                    string itemname = Path.GetFileName(item.FileName);
                    //新檔案名稱
                    string ofileName = String.Format("{0:yyyyMMddhhmmsss}-{1}.{2}", DateTime.Now, i, Extension);
                    //上傳目錄為/upload/Images/
                    files.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/files/{0}", ofileName)));
                    i++;
                    SqlCommand oCommand =
                        new SqlCommand(
                            $"INSERT INTO downloads(productID,filename,showname) VALUES(@productID,@filename,@showname)",
                            Connection);
                    oCommand.Parameters.Add("@productID", SqlDbType.NVarChar);
                    oCommand.Parameters["@productID"].Value = Context.Request.QueryString["id"];
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


        //protected void GridView2_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow) // 只處理資料欄位，不增加此判斷會連 header 文字都被修改
        //    {
                
        //        string[] filename = ((HyperLink)e.Row.Cells[1].FindControl("HyperLink2")).Text.Split('-');
        //        ((HyperLink)e.Row.Cells[1].FindControl("HyperLink1")).Text = filename[0];
        //    }
        //}

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "True")
                {
                    e.Row.Cells[3].Text = "✔";
                }
                else
                {
                    e.Row.Cells[3].Text = "";
                }

                if (e.Row.Cells[2].Text == "True")
                {
                    e.Row.Cells[2].Text = "✔";
                }
                else
                {
                    e.Row.Cells[2].Text = "";
                }
            }
        }
    }
}