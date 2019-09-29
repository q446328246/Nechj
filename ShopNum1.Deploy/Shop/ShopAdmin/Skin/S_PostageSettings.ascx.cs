using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System.Data;

namespace ShopNum1.Deploy.Shop.ShopAdmin.Skin
{
    public partial class S_PostageSettings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            if (!IsPostBack)
            {
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(MemberLoginID);
                if (table != null && table.Rows.Count > 0)
                {
                    Txt_FirstPrice.Text = table.Rows[0]["FirstHeavyPrice"].ToString();
                    Txt_AfterPrice.Text = table.Rows[0]["AfterHeavyPrice"].ToString();
                    Txt_FirstHeavy.Text = table.Rows[0]["FirstHeavy"].ToString();
                }
            }

        }

        protected void Btn_OK_Click(object sender, EventArgs e)
        {


            if (Txt_FirstPrice.Text != "" && Convert.ToDecimal(Txt_FirstPrice.Text) > -1)
            {
                if (Txt_AfterPrice.Text != "" && Convert.ToDecimal(Txt_AfterPrice.Text) > -1)
                {
                    if (Txt_FirstHeavy.Text != "" && Convert.ToDecimal(Txt_FirstHeavy.Text) > -1)
                    {
                        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
                        ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                        PostageAction.UpdatePostagePrice(MemberLoginID, Convert.ToDecimal(Txt_FirstPrice.Text), Convert.ToDecimal(Txt_AfterPrice.Text), Convert.ToDecimal(Txt_FirstHeavy.Text));

                        Response.Write("<script>alert('邮费设置成功！');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('请正确填写首重重量！');</script>");
                    }

                }
                else 
                {
                    Response.Write("<script>alert('请正确填写超重费用！');</script>");
                }

            }
            else 
            {
                Response.Write("<script>alert('请正确填写首重费用！');</script>");
            }


        }
    }
}