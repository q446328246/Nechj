using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main
{
    public partial class MemberRegisterHtml5CG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mem = Page.Request.QueryString["member"].ToString();
            Label1.Text = "恭喜你注册成功,您的工号为" + mem;

        }
    }
}