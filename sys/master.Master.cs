using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Tayan.sys
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(hiddenyo.Value);測試有沒有抓到member的hiddenyo
            //先判斷帳號是否要踢出去
            #region Session寫法
            //if (Session["login"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            ////把帳號人名放在左上
            //username.Text = Session["login"].ToString();

            //profile.Src = "/uploadfile/" + Session["profile"].ToString();
            #endregion

            #region cookies寫法
            if (!HttpContext.Current.User.Identity.IsAuthenticated)//現在是否登入，如果沒有就跳回login page
            {
                Response.Redirect("/sys/login.aspx");
            }
            string strTicket = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            ticket UPerson = JsonConvert.DeserializeObject<ticket>(strTicket);
            //把帳號人名放在左上
            username.Text = UPerson.UID;
            profile.Src = "/sys/uploadfile/members/" + UPerson.profile;
            #endregion
            //讀取權限決定要show出那些表單

            string[] permission = UPerson.permission.Split(',');
            StringBuilder menu = new StringBuilder();
            string add = @"class=""javascript:;""";
            foreach (string per in permission)
            {
                switch (per)
                {
                    case "001":
                        if (hiddenyo.Value == per)//hiddenyo是隱藏欄位的值
                        {
                            add = @"class=""active""";
                        }
                        menu.Append(@"<li class=""mt"">" + @"<a " + add + @"href=""/sys/members/members.aspx"">" + @"<i class=""fa fa-users""></i><span>帳號管理</span></a></li>");
                        add = @"class=""javascript:;""";
                        break;
                    case "002":
                        if (hiddenyo.Value == per)
                        {
                            add = @"class=""active""";
                        }
                        menu.Append(@"<li class=""mt"">" + @"<a " + add + @"href=""/sys/productAll/productsF.aspx"">" + @"<i class=""fa fa-book""></i><span>產品資訊</span></a></li>");
                        add = @"class=""javascript:;""";
                        break;
                    case "003":
                        if (hiddenyo.Value == per)
                        {
                            add = @"class=""active""";
                        }
                        menu.Append(@"<li class=""mt"">" + @"<a " + add + @"href=""/sys/indexImg.aspx"">" + @"<i class=""fa fa-photo""></i><span>首頁照片管理</span></a></li>");
                        add = @"class=""javascript:;""";
                        break;
                    case "004":
                        if (hiddenyo.Value == per)
                        {
                            add = @"class=""active""";
                        }
                        menu.Append(@"<li class=""mt"">" + @"<a " + add + @"href=""/sys/NEWS/NEWS.aspx"">" + @"<i class=""fa fa-desktop""></i><span>NEWS</span></a></li>");
                        add = @"class=""javascript:;""";
                        break;
                    case "005":
                        if (hiddenyo.Value == per)
                        {
                            add = @"class=""active""";
                        }
                        menu.Append(@"<li class=""mt"">" + @"<a " + add + @"href=""/sys/Dealers/Dealers.aspx"">" + @"<i class=""fa fa-dashboard""></i><span>Dealers</span></a></li>");
                        add = @"class=""javascript:;""";
                        break;

                }

                Literal1.Text = menu.ToString();
            }

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            #region session寫法
            //Session.Clear();
            //Response.Redirect("~/login.aspx");
            #endregion

            #region cookie寫法
            //把ticket刪掉並導向login頁面
            FormsAuthentication.SignOut();
            Response.Redirect("~/sys/login.aspx");
            #endregion

        }
    }
}