using ShopNum1.Deploy.KCELogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gz_LogicApi api = new Gz_LogicApi();
            double p = api.SelectETHBili();
            Response.Write(p.ToString());
        }
    }
}