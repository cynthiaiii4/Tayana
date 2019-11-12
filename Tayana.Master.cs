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
    public partial class Tayana : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (hiddenyo.Value)
            {
                case "001":
                    return;
                case "002":
                    return;
                case "003":
                    return;
                case "004":
                    return;
                case "005":
                    topImg.Src = "images/contact.jpg";
                    
                    return;
            }

        }
    }
}