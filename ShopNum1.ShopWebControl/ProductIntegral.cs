using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductIntegral : BaseWebControl
    {
        private HiddenField HiddenFieldGuid;
        private HiddenField HiddenFieldMaxCount;
        private HiddenField HiddenFieldMemloginID;
        private HiddenField HiddenFieldMyScore;
        private HiddenField HiddenFieldUrl;
        private Repeater RepeaterData;
        private string skinFilename = "ProductIntegral.ascx";

        public ProductIntegral()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetDataBind()
        {
            DataTable table =
                ((ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action())
                    .GetDataShopWeb(1, 0, 1, HiddenFieldGuid.Value);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
            else
            {
                MessageBox.Show("商品不存在！");
            }
        }

        public void GetMyScore()
        {
            DataTable scoreByMemLoginID =
                ((ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action())
                    .GetScoreByMemLoginID(HiddenFieldMemloginID.Value);
            if ((scoreByMemLoginID != null) && (scoreByMemLoginID.Rows.Count > 0))
            {
                HiddenFieldMyScore.Value = scoreByMemLoginID.Rows[0]["Score"].ToString();
            }
            else
            {
                HiddenFieldMyScore.Value = "0";
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenFieldMaxCount = (HiddenField) skin.FindControl("HiddenFieldMaxCount");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            HiddenFieldMemloginID = (HiddenField) skin.FindControl("HiddenFieldMemloginID");
            HiddenFieldMyScore = (HiddenField) skin.FindControl("HiddenFieldMyScore");
            HiddenFieldUrl = (HiddenField) skin.FindControl("HiddenFieldUrl");
            HiddenFieldUrl.Value = "http://" + ShopSettings.siteDomain +
                                   "/main/member/m_index.aspx?tomurl=M_OrderScoreList.aspx";
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                HiddenFieldMemloginID.Value = cookie2.Values["MemLoginID"];
                GetMyScore();
            }
            if (Page.Request.QueryString["guid"] != null)
            {
                HiddenFieldGuid.Value = Page.Request.QueryString["guid"];
                GetDataBind();
            }
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                string str = Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "<script>$(function(){$('#mylogingo').attr('src','http://" + ShopSettings.siteDomain + "/poplogin.aspx?vj=shopcar&backurl=" + str + "'); });</script>");
            }
            if (!string.IsNullOrEmpty(ShopSettings.GetValue("MaxScroeProductCount")))
            {
                HiddenFieldMaxCount.Value = ShopSettings.GetValue("MaxScroeProductCount");
            }
            if (!Page.IsPostBack && (Page.Request.UrlReferrer != null))
            {
                var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
                try
                {
                    action.ClickProduct(Page.Request.QueryString["guid"]);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}