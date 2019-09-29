using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Shop.ShopAdmin
{
    public partial class S_SellGoods_Two1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
	{
        HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
        string MemberLoginID = cookie2.Values["MemLoginID"];
        if (MemberLoginID == TJShopInfo.shopId)
        {
            S_OpGoods1.Visible = true;
            S_OpGoods1C2C.Visible = false;
            S_OpGoods1CV.Visible = false;

        }
        else if (MemberLoginID != TJShopInfo.shopId && MemberLoginID !=TJShopInfo.shoCVid)
        {
            S_OpGoods1C2C.Visible = true;
            S_OpGoods1.Visible = false;
            S_OpGoods1CV.Visible = false;
        }
        else if (MemberLoginID == TJShopInfo.shoCVid)
        {
            S_OpGoods1C2C.Visible = false;
            S_OpGoods1.Visible = false;
            S_OpGoods1CV.Visible = true;
        }
	}       
           
           
        }
    }
}

    
    