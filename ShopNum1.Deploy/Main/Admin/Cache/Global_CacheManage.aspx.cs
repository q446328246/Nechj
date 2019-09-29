using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin.Cache
{
    public partial class Global_CacheManage : PageBase, IRequiresSessionState
    {
        private void ButtonArticleCategory_Click(object sender, EventArgs e)
        {
            ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
            method_6();
        }

        private void ButtonArticleShow_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonCategory_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonCategoryShow_Click(object sender, EventArgs e)
        {
            ShopNum1_CategoryChecked_Action.CategoryTable = null;
            method_6();
        }

        private void ButtonOnlineMember_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonOnlineShop_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonProductCategory_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonProductShow_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonShopBack_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonShopCatergory_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonShopFront_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonShopMeto_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonShopSetting_Click(object sender, EventArgs e)
        {
            ShopSettings.ResetShopSetting();
            method_6();
        }

        private void ButtonShopShow_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonSiteConfig_Click(object sender, EventArgs e)
        {
            method_6();
            Utils.RestartIISProcess();
        }

        private void ButtonSiteImg_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void ButtonSiteMeto_Click(object sender, EventArgs e)
        {
            ShopNum1_ExtendSiteMota_Action.ResetMeto();
            method_6();
        }

        private void ButtonSupplyDemand_Click(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
            method_6();
        }

        private void ButtonSupplyShow_Click(object sender, EventArgs e)
        {
            method_6();
        }

        private void method_5(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
        }

        private void method_6()
        {
            base.RegisterStartupScriptNew("PAGE", "window.location.href='global_cachemanage.aspx';");
        }

        protected override void OnInit(EventArgs eventArgs_0)
        {
            base.OnInit(eventArgs_0);
            ResetAllCache.Click += ResetAllCache_Click;
            ButtonShopSetting.Click += ButtonShopSetting_Click;
            ButtonShopCatergory.Click += ButtonShopCatergory_Click;
            ButtonShopShow.Click += ButtonShopShow_Click;
            ButtonProductCategory.Click += ButtonProductCategory_Click;
            ButtonProductShow.Click += ButtonProductShow_Click;
            ButtonSupplyDemand.Click += ButtonSupplyDemand_Click;
            ButtonSupplyShow.Click += ButtonSupplyShow_Click;
            ButtonCategory.Click += ButtonCategory_Click;
            ButtonCategoryShow.Click += ButtonCategoryShow_Click;
            ButtonArticleCategory.Click += ButtonArticleCategory_Click;
            ButtonArticleShow.Click += ButtonArticleShow_Click;
            ButtonShopFront.Click += ButtonShopFront_Click;
            ButtonShopBack.Click += ButtonShopBack_Click;
            ButtonShopMeto.Click += ButtonShopMeto_Click;
            ButtonSiteMeto.Click += ButtonSiteMeto_Click;
            ButtonOnlineMember.Click += ButtonOnlineMember_Click;
            ButtonOnlineShop.Click += ButtonOnlineShop_Click;
            ButtonSiteImg.Click += ButtonSiteImg_Click;
            ButtonSiteConfig.Click += ButtonSiteConfig_Click;
        }

        private void ResetAllCache_Click(object sender, EventArgs e)
        {
            method_6();
            Utils.RestartIISProcess();
        }
    }
}