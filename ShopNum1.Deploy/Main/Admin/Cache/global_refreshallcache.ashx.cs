using System;
using System.Web;
using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin.Cache
{
    /// <summary>
    ///     global_refreshallcache 的摘要说明
    /// </summary>
    public class global_refreshallcache : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Cookies["AdminLoginCookie"] == null)
            {
                //无权限访问
                //  this.Response.Write("<script type=\"text/javascript\">window.top.location.href='Login.aspx';</script>");
                context.Response.Redirect("../Login.aspx");
                return;
            }

            int opnumber = 0;
            if (context.Request.QueryString["opnumber"] != null)
            {
                try
                {
                    opnumber = Convert.ToInt32(context.Request.QueryString["opnumber"]);
                }
                catch
                {
                }
            }

            int result = -1;

            #region 根据缓存更新选项更新相应的缓存数据

            switch (opnumber)
            {
                case 1:
                    {
                        //重设Shopsetting
                        ShopSettings.ResetShopSetting();
                        result = 2;
                        break;
                    }
                case 2:
                    {
                        //更新店铺分类缓存
                        ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
                        result = 3;
                        break;
                    }
                case 3:
                    {
                        //更新店铺展现缓存
                        result = 4;
                        break;
                    }
                case 4:
                    {
                        //更新商品分类缓存
                        ShopNum1_ProductCategory_Action.ProductCategoryTable = null;
                        result = 5;
                        break;
                    }
                case 5:
                    {
                        //更新商品展现缓存

                        result = 6;
                        break;
                    }
                case 6:
                    {
                        //更新供求分类缓存
                        ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
                        result = 7;
                        break;
                    }
                case 7:
                    {
                        //更新供求展现缓存

                        result = 8;
                        break;
                    }
                case 8:
                    {
                        //更新分类缓存
                        ShopNum1_CategoryChecked_Action.CategoryTable = null;
                        result = 9;
                        break;
                    }
                case 9:
                    {
                        //更新分类展现缓存  

                        result = 10;
                        break;
                    }
                case 10:
                    {
                        //更新资讯分类缓存
                        ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                        result = 11;
                        break;
                    }
                case 11:
                    {
                        //更新资讯展现缓存
                        //ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                        result = 12;
                        break;
                    }
                case 12:
                    {
                        //更新店铺前台缓存

                        result = 13;
                        break;
                    }
                case 13:
                    {
                        //更新店铺后台缓存

                        result = 14;
                        break;
                    }
                case 14:
                    {
                        //更新店铺前台Meto缓存
                        //ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                        result = 15;
                        break;
                    }
                case 15:
                    {
                        //更新平台前台Meto缓存
                        ShopNum1_ExtendSiteMota_Action.ResetMeto();
                        result = 16;
                        break;
                    }
                case 16:
                    {
                        //更新在线会员缓存
                        //ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                        result = 17;
                        break;
                    }
                case 17:
                    {
                        //更新在线店铺缓存
                        //ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
                        result = 18;
                        break;
                    }
                case 18:
                    {
                        //更新平台前台广告缓存
                        DefaultAdvertismentOperate.ResetDe();
                        result = 19;
                        break;
                    }
            }

            #endregion

            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}