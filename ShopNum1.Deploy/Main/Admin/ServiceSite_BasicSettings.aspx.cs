using System;
using System.Collections.Generic;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceSite_BasicSettings : PageBase, IRequiresSessionState
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                this.BindSetting();
            }
        }
        protected void BindSetting()
        {
            XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    string name = xmlNode2.Name;
                    switch (name)
                    {
                        case "OverrideUrl":
                            this.DropDownListSiteHtml.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "InitialShopID":
                            this.TextBoxShopID.Text = xmlNode2.InnerText;
                            break;
                        case "DefaultReceivedDays":
                            this.TextBoxDefaultReceivedDays.Text = xmlNode2.InnerText;
                            break;
                        case "DefaultCancelOrderDays":
                            this.TextBoxDefaultCancelOrderDays.Text = xmlNode2.InnerText;
                            break;
                        case "RefundIsAdmin":
                            this.TextBoxRefundIsAdmin.Text = xmlNode2.InnerText;
                            break;
                        case "MaxScroeProductCount":
                            this.TextBoxMaxScroeProductCount.Text = xmlNode2.InnerText;
                            break;
                        case "ZtcMoney":
                            this.TextBoxZtcGoodsMoney.Text = xmlNode2.InnerText;
                            break;
                        case "PayMentType":
                            this.RadioButtonListPayType.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ICPNum":
                            this.TextBoxICPNum.Text = xmlNode2.InnerText;
                            break;
                        case "IsMobileCheckPay":
                            this.DropDownListMobileCheck.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AddCouponIsAudit":
                            this.DropDownListAddCouponIsAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AddProductIsAudit":
                            this.DropDownListAddProductIsAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AddSpellBuyProductIsAudit":
                            this.DropDownListAddSpellBuyProductIsAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AddPanicBuyProductIsAudit":
                            this.DropDownListAddPanicBuyProductIsAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SupplyDemandCommentISAudit":
                            this.DropDownListSupplyDemandCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ProductCommentISAudit":
                            this.DropDownListProductCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ArticleCommentISAudit":
                            this.DropDownListArticleCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShopArticleCommentISAudit":
                            this.DropDownListShopArticleCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "MessageCommentISAudit":
                            this.DropDownListMessageCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShopMessageCommentISAudit":
                            this.DropDownListShopMessageCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "VideoCommentISAudit":
                            this.DropDownListVideoCommentISAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SupplyDemandIsAudit":
                            this.DropDownListSupplyDemandIsAudit.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RegPresentScore":
                            this.TextBoxRegPresentScore.Text = xmlNode2.InnerText;
                            break;
                        case "RegPresentRankScore":
                            this.TextBoxRegPresentRankScore.Text = xmlNode2.InnerText;
                            break;
                        case "ProductCommentVerifyCode":
                            this.DropDownListProductCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SupplyDemandCommentVerifyCode":
                            this.DropDownListSupplyDemandCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ProductBuyVerifyCode":
                            this.DropDownListProductBuyVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AriticleCommentVerifyCode":
                            this.DropDownListAriticleCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShopAriticleCommentVerifyCode":
                            this.DropDownListShopAriticleCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "VideoCommentVerifyCode":
                            this.DropDownListVideoCommentVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "MessageVerifyCode":
                            this.DropDownListMessageVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RegVerifyCode":
                            this.DropDownListRegVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "MemLoginVerifyCode":
                            this.DropDownListMemLoginVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ArticleCommentCondition":
                            this.DropDownListArticleCommentCondition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShopArticleCommentCondition":
                            this.DropDownListShopArticleCommentCondition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "MessageCondition":
                            this.DropDownListMessageCondition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShopMessageCondition":
                            this.DropDownListShopMessageCondition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SupplyDemandCommentCondition":
                            this.DropDownListSupplyDemandCommentCondition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "DecreaseRepertory":
                            this.DropDownListDecreaseRepertory.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "MyMessageRankSorce":
                            this.TextBoxMyMessageRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyMessageSorce":
                            this.TextBoxMyMessageSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyShopMessageRankSorce":
                            this.TextBoxMyShopMessageRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyShopMessageSorce":
                            this.TextBoxMyShopMessageSorce.Text = xmlNode2.InnerText;
                            break;
                        case "BuyProductRankScore":
                            this.TextBoxBuyProductRankScore.Text = xmlNode2.InnerText;
                            break;
                        case "BuyProductScore":
                            this.TextBoxBuyProductScore.Text = xmlNode2.InnerText;
                            break;
                        case "MyProductCommentRankSorce":
                            this.TextBoxMyCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyProductCommentSorce":
                            this.TextBoxMyCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "SellerCommentRankSorce":
                            this.TextBoxSellerCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "SellerCommentSorce":
                            this.TextBoxSellerCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MySupplyDemandCommentRankSorce":
                            this.TextBoxMySupplyDemandCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MySupplyDemandCommentSorce":
                            this.TextBoxMySupplyDemandCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyCategoryInfoCommentRankSorce":
                            this.TextBoxMyCategoryInfoCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "MyCategoryInfoCommentSorce":
                            this.TextBoxMyCategoryInfoCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "ArticleCommentRankSorce":
                            this.TextBoxArticleCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "ArticleCommentSorce":
                            this.TextBoxArticleCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "ShopArticleCommentRankSorce":
                            this.TextBoxShopArticleCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "ShopArticleCommentSorce":
                            this.TextBoxShopArticleCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "VideoCommentRankSorce":
                            this.TextBoxVideoCommentRankSorce.Text = xmlNode2.InnerText;
                            break;
                        case "VideoCommentSorce":
                            this.TextBoxVideoCommentSorce.Text = xmlNode2.InnerText;
                            break;
                        case "GoodAppraiseReputation":
                            this.TextBoxGoodAppraiseReputation.Text = xmlNode2.InnerText;
                            break;
                        case "StandardAppraiseReputation":
                            this.TextBoxStandardAppraiseReputation.Text = xmlNode2.InnerText;
                            break;
                        case "BadAppraiseReputation":
                            this.TextBoxBadAppraiseReputation.Text = xmlNode2.InnerText;
                            break;
                        case "SignOrSendScore":
                            this.DropDownListSignOrSendScore.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SignScore":
                            this.TextBoxSignScore.Text = xmlNode2.InnerText;
                            break;
                        case "SignRankScore":
                            this.TextBoxSignRankScore.Text = xmlNode2.InnerText;
                            break;
                        case "ShopMessageVerifyCode":
                            this.DropDownListShopMessageVerifyCode.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "IsShopProductFcRate":
                            this.DropDownListAdminProductFcRate.Text = xmlNode2.InnerText;
                            break;
                        case "AdminProductFcRate":
                            this.TextBoxAdminProductFcRate.Text = xmlNode2.InnerText;
                            break;
                        case "IsAdminProductFcCount":
                            this.DropDownListIsAdminProductFcCount.Text = xmlNode2.InnerText;
                            break;
                        case "AdminProductFcCount":
                            this.TextBoxAdminProductFcCount.Text = xmlNode2.InnerText;
                            break;
                        case "IsOrderCommission":
                            this.DropDownListIsOrderCommission.Text = xmlNode2.InnerText;
                            break;
                        case "OrderCommission":
                            this.TextBoxOrderCommission.Text = xmlNode2.InnerText;
                            break;
                        case "VideoCommentCondition":
                            this.DropDownListVideoCommentCondition.Text = xmlNode2.InnerText;
                            break;
                        case "IsRecommendCommisionOpen":
                            this.DropDownListIsRecommendCommision.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RecommendCommision":
                            this.TextBoxRecommendCommision.Text = xmlNode2.InnerText;
                            break;
                        case "KeyWordCheck":
                            this.DropDownListKewWordCheck.Text = xmlNode2.InnerText;
                            break;
                        case "WxPayMoney":
                            this.txtWxPay.Value = xmlNode2.InnerText;
                            break;
                    }
                }
            }
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            int num = 1;
            try
            {
                this.Updata();
            }
            catch (Exception)
            {
                num = 0;
            }
            if (num > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="基本设置信息修改成功";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="ServiceSite_BasicSettings.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
              
                base.OperateLog(shopNum1_OperateLog);
             
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                ShopSettings.ResetShopSetting();
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }
        protected void Updata()
        {
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OverrideUrl", this.DropDownListSiteHtml.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/KeyWordCheck", this.DropDownListKewWordCheck.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/InitialShopID", this.TextBoxShopID.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DefaultReceivedDays", this.TextBoxDefaultReceivedDays.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DefaultCancelOrderDays", this.TextBoxDefaultCancelOrderDays.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RefundIsAdmin", this.TextBoxRefundIsAdmin.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MaxScroeProductCount", this.TextBoxMaxScroeProductCount.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ZtcMoney", this.TextBoxZtcGoodsMoney.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayMentType", this.RadioButtonListPayType.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ICPNum", this.TextBoxICPNum.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddCouponIsAudit", this.DropDownListAddCouponIsAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddProductIsAudit", this.DropDownListAddProductIsAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddSpellBuyProductIsAudit", this.DropDownListAddSpellBuyProductIsAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AddPanicBuyProductIsAudit", this.DropDownListAddPanicBuyProductIsAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductCommentISAudit", this.DropDownListProductCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentISAudit", this.DropDownListSupplyDemandCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentISAudit", this.DropDownListArticleCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentISAudit", this.DropDownListShopArticleCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageCommentISAudit", this.DropDownListMessageCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageCommentISAudit", this.DropDownListShopMessageCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentISAudit", this.DropDownListVideoCommentISAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentCondition", this.DropDownListVideoCommentCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandIsAudit", this.DropDownListSupplyDemandIsAudit.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegPresentScore", this.TextBoxRegPresentScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegPresentRankScore", this.TextBoxRegPresentRankScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductCommentVerifyCode", this.DropDownListProductCommentVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentVerifyCode", this.DropDownListSupplyDemandCommentVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ProductBuyVerifyCode", this.DropDownListProductBuyVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AriticleCommentVerifyCode", this.DropDownListAriticleCommentVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopAriticleCommentVerifyCode", this.DropDownListShopAriticleCommentVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentVerifyCode", this.DropDownListVideoCommentVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageVerifyCode", this.DropDownListMessageVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageVerifyCode", this.DropDownListShopMessageVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegVerifyCode", this.DropDownListRegVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MemLoginVerifyCode", this.DropDownListMemLoginVerifyCode.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentCondition", this.DropDownListArticleCommentCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentCondition", this.DropDownListShopArticleCommentCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MessageCondition", this.DropDownListMessageCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopMessageCondition", this.DropDownListShopMessageCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SupplyDemandCommentCondition", this.DropDownListSupplyDemandCommentCondition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/DecreaseRepertory", this.DropDownListDecreaseRepertory.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyMessageRankSorce", this.TextBoxMyMessageRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyMessageSorce", this.TextBoxMyMessageSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyShopMessageRankSorce", this.TextBoxMyShopMessageRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyShopMessageSorce", this.TextBoxMyShopMessageSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BuyProductRankScore", this.TextBoxBuyProductRankScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BuyProductScore", this.TextBoxBuyProductScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyProductCommentRankSorce", this.TextBoxMyCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyProductCommentSorce", this.TextBoxMyCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SellerCommentRankSorce", this.TextBoxSellerCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SellerCommentSorce", this.TextBoxSellerCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentRankSorce", this.TextBoxArticleCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ArticleCommentSorce", this.TextBoxArticleCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentRankSorce", this.TextBoxShopArticleCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopArticleCommentSorce", this.TextBoxShopArticleCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MySupplyDemandCommentRankSorce", this.TextBoxMySupplyDemandCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MySupplyDemandCommentSorce", this.TextBoxMySupplyDemandCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyCategoryInfoCommentRankSorce", this.TextBoxMyCategoryInfoCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MyCategoryInfoCommentSorce", this.TextBoxMyCategoryInfoCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentRankSorce", this.TextBoxVideoCommentRankSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/VideoCommentSorce", this.TextBoxVideoCommentSorce.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/GoodAppraiseReputation", this.TextBoxGoodAppraiseReputation.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/StandardAppraiseReputation", this.TextBoxStandardAppraiseReputation.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/BadAppraiseReputation", this.TextBoxBadAppraiseReputation.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignOrSendScore", this.DropDownListSignOrSendScore.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignScore", this.TextBoxSignScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SignRankScore", this.TextBoxSignRankScore.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsRecommendCommisionOpen", this.DropDownListIsRecommendCommision.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RecommendCommision", this.TextBoxRecommendCommision.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsShopProductFcRate", this.DropDownListAdminProductFcRate.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AdminProductFcRate", this.TextBoxAdminProductFcRate.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsAdminProductFcCount", this.DropDownListIsAdminProductFcCount.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AdminProductFcCount", this.TextBoxAdminProductFcCount.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsOrderCommission", this.DropDownListIsOrderCommission.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderCommission", this.TextBoxOrderCommission.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WxPayMoney", this.txtWxPay.Value.Trim());
            ShopSettings.ResetShopSetting();
        }
        protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
        {
            new Random();
            string fileName = fileUpload.PostedFile.FileName;
            FileInfo fileInfo = new FileInfo(fileName);
            string text = "~/Upload/";
            fileName.Substring(fileName.LastIndexOf(".") + 1);
            string arg_3E_0 = fileUpload.PostedFile.ContentType;
            int contentLength = fileUpload.PostedFile.ContentLength;
            bool result;
            if (fileName != "")
            {
                if (contentLength < 1024000)
                {
                    if (!Directory.Exists(base.Server.MapPath(text)))
                    {
                        Directory.CreateDirectory(base.Server.MapPath(text));
                    }
                    fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
                    strext = fileName;
                    result = true;
                }
                else
                {
                    strext = "文件不能大于1M！";
                    result = false;
                }
            }
            else
            {
                strext = "upload 为空！";
                result = false;
            }
            return result;
        }
    }
}