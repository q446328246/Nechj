using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ClearData : PageBase, IRequiresSessionState
    {
        protected void ButtonClearExperienceData_Click(object sender, EventArgs e)
        {
            method_5();
            string str = TextBoxLoginID.Text.Trim();
            string str2 = ShopNum1.Common.Encryption.GetSHA1SecondHash(TextBoxPwd.Text.Trim());
            int num = method_6(str, str2);
            if (num > 0)
            {
                var action = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
                if (action.DeleteAllFromTables(hiddenFieldCheckedClearData.Value) > 0)
                {
                    MessageBox.Show("清除体验数据成功");
                }
                else
                {
                    MessageBox.Show("清除体验数据失败");
                }
            }
            else
            {
                switch (num)
                {
                    case 0:
                        MessageBox.Show("用户名或密码错误");
                        break;

                    case -1:
                        MessageBox.Show("用户被锁定");
                        break;
                }
            }
        }

        private void method_5()
        {
            if (checkboxAll.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_Brand;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_Shop_Product;ShopNum1_CategoryType;ShopNum1_ProductCategory;ShopNum1_Shop_ProductCategory;ShopNum1_ShopProductProp;ShopNum1_ShopProductPropValue;ShopNum1_ShopProduct_Browse;ShopNum1_Spec;shopnum1_specvalue;ShopNum1_SpecProudct;shopnum1_shop_productcomment;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_Member;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_ShopInfo;ShopNum1_Shop_UserDefinedColumn;ShopNum1_ShopCategory;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_Image;ShopNum1_ImageCategory;ShopNum1_Shop_Image;ShopNum1_Shop_ImageCategory;ShopNum1_Shop_ImagePath;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle;ShopNum1_Shop_News;ShopNum1_Shop_NewsCategory;ShopNum1_Announcement;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_UserMessage;shopNum1_MemberMessage;ShopNum1_MessageInfo;ShopNum1_AttachMent;ShopNum1_AttachMentCategory;ShopNum1_Link;ShopNum1_OnlineService;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_ZtcApply;ShopNum1_ZtcGoods;ShopNum1_ShopProduct_Browse;ShopNum1_ShopProduct_Browse;ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory;ShopNum1_ScoreOrderInfo;ShopNum1_ScoreOrderProduct;ShopNum1_ScoreProductCategory;ShopNum1_SignIn;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_RankScoreModifyLog;ShopNum1_ScoreModifyLog;ShopNum1_SupplyDemand;ShopNum1_SupplyDemandCategory;ShopNum1_SupplyDemandComment;ShopNum1_PreTransfer;";
                hiddenFieldCheckedClearData.Value = hiddenFieldCheckedClearData.Value +
                                                    "ShopNum1_AdvancePaymentApplyLog;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentModifyLog;ShopNum1_Limt_Package;ShopNum1_Limt_Product;ShopNum1_Product_Activity";
            }
            else if (CheckboxProduct.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Shop_ProductCategory;ShopNum1_ShopProductProp;ShopNum1_ProductCategory;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog;ShopNum1_Shop_Product;ShopNum1_CategoryType;ShopNum1_ZtcApply;ShopNum1_ZtcGoods;ShopNum1_ShopProduct_Browse;ShopNum1_Spec;shopnum1_specvalue;ShopNum1_SpecProudct;ShopNum1_SpecProudctDetails;ShopNum1_ProductCategory;ShopNum1_CategoryType;ShopNum1_Shop_Product;ShopNum1_ShopProductPropValue;ShopNum1_ShopProduct_Browse;shopnum1_shop_productcomment";
            }
            else if (CheckboxCategoryAndBrand.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_Brand";
            }
            else if (CheckboxMem.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Member;ShopNum1_MemberInfo;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;ShopNum1_SignIn;ShopNum1_RankScoreModifyLog;ShopNum1_ScoreModifyLog;ShopNum1_SupplyDemand;ShopNum1_SupplyDemandCategory;ShopNum1_SupplyDemandComment;ShopNum1_OperateLog";
            }
            else if (CheckboxShop.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_ShopInfo;ShopNum1_Shop_UserDefinedColumn;ShopNum1_ShopRank;ShopNum1_ShopCategory;ShopNum1_Shop_ApplyEnsure";
            }
            else if (CheckboxImage.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Image;ShopNum1_ImageCategory;ShopNum1_Shop_Image;ShopNum1_Shop_ImageCategory;ShopNum1_Shop_ImagePath";
            }
            else if (CheckboxArticle.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle;ShopNum1_Shop_News;ShopNum1_Shop_NewsCategory;ShopNum1_Announcement";
            }
            else if (CheckboxVideo.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment;ShopNum1_Video;ShopNum1_VideoCategory;ShopNum1_VideoComment";
            }
            else if (CheckboxAgentMessage.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_UserMessage;shopNum1_MemberMessage;ShopNum1_MessageInfo";
            }
            else if (CheckboxAttachMent.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_AttachMent;ShopNum1_AttachMentCategory";
            }
            else if (CheckboxLink.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_Link";
            }
            else if (CheckboxService.Checked)
            {
                hiddenFieldCheckedClearData.Value = "ShopNum1_OnlineService";
            }
            else if (CheckboxScore.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_ShopProduct_Browse;ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory;ShopNum1_ScoreOrderInfo;ShopNum1_ScoreOrderProduct;ShopNum1_ScoreProductCategory";
            }
            else if (CheckboxAdvancePayment.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_AdvancePaymentApplyLog;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentModifyLog;ShopNum1_PreTransfer";
            }
            else if (CheckboxLimtPackage.Checked)
            {
                hiddenFieldCheckedClearData.Value =
                    "ShopNum1_Limt_Package;ShopNum1_Limt_Product;ShopNum1_Product_Activity";
            }
        }

        private int method_6(string string_4, string string_5)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            return action.CheckLogin(string_4, string_5, 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
        }
    }
}