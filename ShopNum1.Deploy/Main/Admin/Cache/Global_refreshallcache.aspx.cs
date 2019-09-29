using System;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin.Cache
{
    public partial class Global_refreshallcache : Page, IRequiresSessionState
    {
        private void method_0(object sender, EventArgs e)
        {
            if (base.Request.Cookies["AdminLoginCookie"] == null)
            {
                base.Response.Redirect("../Login.aspx");
            }
            else
            {
                int num;
                int num2 = 0;
                if (Page.Request.QueryString["opnumber"] != null)
                {
                    num2 = 0;
                    num2 = 0;
                    try
                    {
                        num2 = Convert.ToInt32(Page.Request.QueryString["opnumber"]);
                    }
                    catch
                    {
                    }
                    num = -1;
                    switch (num2)
                    {
                        case 1:
                            ShopSettings.ResetShopSetting();
                            num = 2;
                            break;

                        case 2:
                            ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
                            num = 3;
                            break;

                        case 3:
                            num = 4;
                            break;

                        case 4:
                            ShopNum1_ProductCategory_Action.ProductCategoryTable = null;
                            num = 5;
                            break;

                        case 5:
                            num = 6;
                            break;

                        case 6:
                            ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
                            num = 7;
                            break;

                        case 7:
                            num = 8;
                            break;

                        case 8:
                            ShopNum1_CategoryChecked_Action.CategoryTable = null;
                            num = 9;
                            break;

                        case 9:
                            num = 10;
                            break;

                        case 10:
                            ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                            num = 11;
                            break;

                        case 11:
                            num = 12;
                            break;

                        case 12:
                            num = 13;
                            break;

                        case 13:
                            num = 14;
                            break;

                        case 14:
                            num = 15;
                            break;

                        case 15:
                            ShopNum1_ExtendSiteMota_Action.ResetMeto();
                            num = 0x10;
                            break;

                        case 0x10:
                            num = 0x11;
                            break;

                        case 0x11:
                            num = 0x12;
                            break;

                        case 0x12:
                            DefaultAdvertismentOperate.ResetDe();
                            num = 0x13;
                            break;
                    }
                }
                else
                {
                    num2 = 0;
                    num2 = 0;
                    num = -1;
                }
                base.Response.Write(num);
            }
        }
    }
}