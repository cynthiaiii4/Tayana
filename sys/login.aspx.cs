using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Tayan.sys
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果用asp的textbox，要達到有預設文字，且點了之後要清空，要加這兩行
            username.Attributes.Add("Value", "User name...");
            username.Attributes.Add("onFocus", "this.value=''");
            //用input就不用加
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            alert.Text = "";
            string userid = username.Text;
           
            string pw = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Value,"MD5");
            string login = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection loginConnection = new SqlConnection(login);
            SqlCommand loginCommand =new SqlCommand($"SELECT * FROM account WHERE UID=@userid and PW=@pw",loginConnection);
            loginCommand.Parameters.Add("@userid", SqlDbType.NVarChar);
            loginCommand.Parameters["@userid"].Value = userid;
            loginCommand.Parameters.Add("@pw", SqlDbType.NVarChar);
            loginCommand.Parameters["@pw"].Value = pw;
            SqlDataAdapter loginAdapter=new SqlDataAdapter(loginCommand);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            if (user.Rows.Count > 0)
            {
                //session的寫法
                Session["login"] = userid;
                Session["profile"] = user.Rows[0]["profile"];
                Session["permission"] = user.Rows[0]["permission"];
                Session.Timeout = 60;
                //****
                //ticket的寫法
                ticket ticket = new ticket();
                ticket.UID = user.Rows[0]["UID"].ToString();
                ticket.PW = user.Rows[0]["PW"].ToString();
                ticket.Name = user.Rows[0]["Name"].ToString();
                ticket.profile = user.Rows[0]["profile"].ToString();
                ticket.permission = user.Rows[0]["permission"].ToString();
                ticket.email = user.Rows[0]["email"].ToString();
                ticket.dept = user.Rows[0]["dept"].ToString();
                ticket.tel = user.Rows[0]["tel"].ToString();

                string userData = JsonConvert.SerializeObject(ticket);//將物件序列化

                SetAuthenTicket(userData, username.Text);
                Response.Redirect("index.aspx");

            }
            else
            {
                alert.Text = "登入失敗";
            }
        }

        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票,到期時間要注意跟cookie到期時間有沒有衝突
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie，把票放進去
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationcookie.Expires = DateTime.Now.AddHours(3);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);
        }
    }
}