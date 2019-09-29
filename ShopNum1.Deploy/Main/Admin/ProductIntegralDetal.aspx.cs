using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ProductIntegralDetal : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (hiddenFieldType.Value == "0")
            {
                base.Response.Redirect("ProductIntegralChecked_List.aspx");
            }
            else if (hiddenFieldType.Value == "1")
            {
                base.Response.Redirect("ProductIntegral_List.aspx");
            }
        }

        public void GetData()
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            try
            {
                DataTable infoByGuid = action.GetInfoByGuid(hiddenFieldGuid.Value);
                if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
                {
                    ImageProduct.ImageUrl = infoByGuid.Rows[0]["OriginalImge"].ToString();
                    LabelProductName.Text = infoByGuid.Rows[0]["Name"].ToString();
                    LabelProductCategoryName.Text = infoByGuid.Rows[0]["ProductCategoryName"].ToString();
                    LabelRepertoryNumber.Text = infoByGuid.Rows[0]["RepertoryNumber"].ToString();
                    LabelProductUnit.Text = infoByGuid.Rows[0]["UnitName"].ToString();
                    LabelMarketPrice.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
                    LabelScore.Text = infoByGuid.Rows[0]["Score"].ToString();
                    LabelTitle.Text = infoByGuid.Rows[0]["Meto_Title"].ToString();
                    LabelKeywords.Text = infoByGuid.Rows[0]["Meto_Keywords"].ToString();
                    LabelDescribe.Text = infoByGuid.Rows[0]["Meto_Description"].ToString();
                    LabelRepertoryCount.Text = infoByGuid.Rows[0]["RepertoryCount"].ToString();
                    if (infoByGuid.Rows[0]["IsNew"].ToString() == "1")
                    {
                        LabelIsNew.Text = "��";
                    }
                    else
                    {
                        LabelIsNew.Text = "��";
                    }
                    if (infoByGuid.Rows[0]["IsHot"].ToString() == "1")
                    {
                        LabelIsHot.Text = "��";
                    }
                    else
                    {
                        LabelIsHot.Text = "��";
                    }
                    if (infoByGuid.Rows[0]["IsSaled"].ToString() == "1")
                    {
                        LabelIsSaled.Text = "��";
                    }
                    else
                    {
                        LabelIsSaled.Text = "��";
                    }
                    if (infoByGuid.Rows[0]["IsAudit"].ToString() == "0")
                    {
                        LabelIsAudit.Text = "δ���";
                    }
                    else if (infoByGuid.Rows[0]["IsAudit"].ToString() == "1")
                    {
                        LabelIsAudit.Text = "���ͨ��";
                    }
                    else if (infoByGuid.Rows[0]["IsAudit"].ToString() == "2")
                    {
                        LabelIsAudit.Text = "���δͨ��";
                    }
                    FCKeditorDetail.Text = infoByGuid.Rows[0]["Detail"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = Page.Request.QueryString["Guid"].Replace("'", "");
                hiddenFieldType.Value = Page.Request.QueryString["Type"].Replace("'", "");
            }
            GetData();
        }
    }
}