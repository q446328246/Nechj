using System;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbLinq;
using ShopNum1.TbTopCommon;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbStep_Set : Page
    {
        private readonly ShopNum1_TbSystem_Action tbSystemOperate =
            (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();

        private string ShopName; //��������

        /// <summary>
        ///     ��Ա��
        /// </summary>
        private string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //��֤��Ա���ĵ�cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //�˳�
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }

            bool isExisit = CheckMemberID(MemLoginID);
            if (!isExisit)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    tbSetBind();
                }
            }
            if (!TopClient.IsAgentLogin)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!TopClient.isSessionTimeOut(Page, "agent"))
            {
                Response.Redirect("TbAuthorization.aspx");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            var tbSystem = new ShopNum1_TbSystem();
            tbSystem.isOpen = radStepOpen.Checked ? true : false;
            tbSystem.hasTbOrder = radOrderOpen.Checked ? true : false;
            tbSystem.hasTbRate = RadioButtonPlOpen.Checked ? true : false;
            tbSystem.tbItemName = tTitleTtS.Checked ? true : false;
            //tbSystem.siteItemName = tTileStT.Checked ? true : false;
            tbSystem.tbItemPrice = tPriceTtS.Checked ? true : false;
            //tbSystem.siteItemPrice = tPriceStT.Checked ? true : false;
            tbSystem.tbSellCat = tTypeTtS.Checked ? true : false;
            //tbSystem.siteSellCat = tTypeStT.Checked ? true : false;
            tbSystem.tbCount = tCountTtS.Checked ? true : false;
            //tbSystem.siteCount = tCountStT.Checked ? true : false;

            //tbSystem.tbImg = RadioButtonTimg.Checked ? true : false;
            //��������ͼ��Ҫ�ڱ��ض�ȡʹ�ã�����ͼƬĬ�����ص�����
            tbSystem.tbImg = true;
            // tbSystem.siteImg = true;
            tbSystem.tbDesc = tDescTtS.Checked ? true : false;
            // tbSystem.siteDesc = tDescStT.Checked ? true : false;
            tbSystem.tbShopName = TopClient.AgentUserNick;
            tbSystem.Memlogid = MemLoginID;

            if (tbSystemOperate.UpdateTbSystem(tbSystem))
            {
                ClientScript.RegisterClientScriptBlock(typeof (Page), "msg", "alert('�޸ĳɹ�')", true);
                tbSetBind();
                return;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof (Page), "msg", "alert('�޸�ʧ��')", true);
                tbSetBind();
                return;
            }
        }

        /// <summary>
        ///     ��ʼȨ��
        /// </summary>
        private void tbSetBind()
        {
            if (TopClient.AgentUserNick != "")
            {
                spanShopName.InnerText = TopClient.AgentUserNick;

                ShopNum1_TbSystem tbSystem = tbSystemOperate.GetTbSysem(MemLoginID, TopClient.AgentUserNick);

                if (tbSystem.isOpen == null)
                {
                    tbSystem.isOpen = false;
                }
                if ((bool) tbSystem.isOpen)
                {
                    radStepOpen.Checked = true;
                }
                else
                {
                    radStepClose.Checked = true;
                }
                RadioButtonPlOpen.Checked = (bool) tbSystem.hasTbRate;
                radOrderOpen.Checked = (bool) tbSystem.hasTbOrder;
                tTitleTtS.Checked = (bool) tbSystem.tbItemName;
                //tTileStT.Checked = (bool)tbSystem.siteItemName;
                tPriceTtS.Checked = (bool) tbSystem.tbItemPrice;
                // tPriceStT.Checked = (bool)tbSystem.siteItemPrice;
                tTypeTtS.Checked = (bool) tbSystem.tbSellCat;
                //tTypeStT.Checked = (bool)tbSystem.siteSellCat;
                tCountTtS.Checked = (bool) tbSystem.tbCount;
                //tCountStT.Checked = (bool)tbSystem.siteCount;
                if ((bool) tbSystem.tbImg)
                {
                    RadioButtonTimg.Checked = true;
                    RadioButtonTimgNo.Checked = false;
                }
                else
                {
                    RadioButtonTimg.Checked = false;
                    RadioButtonTimgNo.Checked = true;
                }

                tDescTtS.Checked = (bool) tbSystem.tbDesc;
                //tDescStT.Checked = (bool)tbSystem.siteDesc;
            }
        }

        private bool CheckMemberID(string MemLoginID)
        {
            try
            {
                ShopName =
                    HttpUtility.UrlDecode(
                        HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
            }
            catch
            {
                ShopName = "";
            }

            var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}