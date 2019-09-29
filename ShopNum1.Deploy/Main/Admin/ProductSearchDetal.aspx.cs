using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ProductSearchDetal : PageBase, IRequiresSessionState
    {
        protected void BindMultiImageTable(string srePics)
        {
            string[] strArray = srePics.Split(new[] {','});
            var table = new DataTable();
            var column = new DataColumn
                {
                    DataType = Type.GetType("System.Guid"),
                    ColumnName = "Guid"
                };
            table.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "OriginalImge"
                };
            table.Columns.Add(column);
            for (int i = 0; i < strArray.Length; i++)
            {
                DataRow row = table.NewRow();
                row["Guid"] = Guid.NewGuid();
                row["OriginalImge"] = strArray[i];
                table.Rows.Add(row);
            }
            DataListPorductImage.DataSource = table.DefaultView;
            DataListPorductImage.DataBind();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (ViewState["Back"].ToString() == "1")
            {
                base.Response.Redirect("Prouduct_List.aspx");
            }
            if (ViewState["Back"].ToString() == "2")
            {
                base.Response.Redirect("ProuductChecked_List.aspx");
            }
            if (ViewState["Back"].ToString() == "3")
            {
                base.Response.Redirect("ProuductPanicBuy_List.aspx");
            }
            if (ViewState["Back"].ToString() == "4")
            {
                base.Response.Redirect("Prouduct_PanicChecked_List.aspx");
            }
            if (ViewState["Back"].ToString() == "5")
            {
                base.Response.Redirect("ProuductSpellBuy_List.aspx");
            }
            if (ViewState["Back"].ToString() == "6")
            {
                base.Response.Redirect("Prouduct_SpellChecked_List.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = Page.Request.QueryString["Guid"].Replace("'", "");
                hiddenFieldType.Value = Page.Request.QueryString["Type"];
                ViewState["Back"] = Page.Request.QueryString["Back"];
            }
            DataTable shopInfoByGuid =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .GetShopInfoByGuid("'" + hiddenFieldGuid.Value + "'");
            TextBoxProductCategory.Text = shopInfoByGuid.Rows[0]["ProductCategoryName"].ToString();
            TextBoxProductBrand.Text = shopInfoByGuid.Rows[0]["BrandName"].ToString();
            TextBoxShopProductCategory.Text = shopInfoByGuid.Rows[0]["ProductSeriesName"].ToString();
            TextBoxProductName.Text = shopInfoByGuid.Rows[0]["Name"].ToString();
            TextBoxProductType.Text = (shopInfoByGuid.Rows[0]["IsReal"].ToString() == "0") ? "������Ʒ" : "ʵ����Ʒ";
            TextBoxProductNum.Text = shopInfoByGuid.Rows[0]["ProductNum"].ToString();
            TextBoxProductUnit.Text = shopInfoByGuid.Rows[0]["UnitName"].ToString();
            TextBoxShopPrice.Text = shopInfoByGuid.Rows[0]["ShopPrice"].ToString();
            TextBoxMarketPrice.Text = shopInfoByGuid.Rows[0]["MarketPrice"].ToString();
            TextBoxBuyCount.Text = shopInfoByGuid.Rows[0]["repertorycount"].ToString();
            TextBoxKeywords.Text = shopInfoByGuid.Rows[0]["Keywords"].ToString();
            TextBoxDescribe.Text = shopInfoByGuid.Rows[0]["Description"].ToString();
            TextBoxBuyStartTime.Text = shopInfoByGuid.Rows[0]["starttime"].ToString();
            TextBoxBuyEndTime.Text = shopInfoByGuid.Rows[0]["endtime"].ToString();
            TextBoxFeeType.Text = (shopInfoByGuid.Rows[0]["FeeType"].ToString() == "0") ? "��ҳе�" : "���ҳе�";
            if (shopInfoByGuid.Rows[0]["FeeType"].ToString() == "0")
            {
                TextBoxPost_fee.Text = shopInfoByGuid.Rows[0]["Post_fee"].ToString();
                TextBoxExpress_fee.Text = shopInfoByGuid.Rows[0]["Express_fee"].ToString();
                TextBoxEms_fee.Text = shopInfoByGuid.Rows[0]["Ems_fee"].ToString();
            }
            FCKeditorDetail.Text = Page.Server.HtmlDecode(shopInfoByGuid.Rows[0]["Detail"].ToString());
            ProductImage.ImageUrl = shopInfoByGuid.Rows[0]["OriginalImage"].ToString();
            FCKeditorInstruction.Text = Page.Server.HtmlDecode(shopInfoByGuid.Rows[0]["Instruction"].ToString());
            BindMultiImageTable(shopInfoByGuid.Rows[0]["MultiImages"].ToString());
            if (hiddenFieldType.Value == "Other")
            {
                LabelPageTitle.Text = "��Ʒ�鿴ҳ";
                LocalizePrice.Text = "��Ʒ�ۣ�";
                LocalizeBuyStartTime.Text = "��ʼʱ�䣺";
                LocalizeBuyEndTime.Text = "����ʱ�䣺";
                LocalizeBuyCount.Text = "��Ʒ������";
                LocalizeMemberCount.Text = "��������:";
                LocalizeMemberCount.Visible = false;
                TextBoxSpellMemberCount.Visible = false;
                LocalizeMemberMM.Visible = false;
                TrStartTime.Visible = false;
                TrEndTime.Visible = false;
            }
            else
            {
                hiddenFieldType.Visible = true;
                if (hiddenFieldType.Value == "Panic")
                {
                    LabelPageTitle.Text = "������Ʒ�鿴ҳ";
                    LocalizePrice.Text = "�����ۣ�";
                    LocalizeBuyStartTime.Text = "������ʼʱ�䣺";
                    LocalizeBuyEndTime.Text = "��������ʱ�䣺";
                    LocalizeBuyCount.Text = "������Ʒ������";
                    LocalizeMemberCount.Text = "����������";
                    LocalizeMemberMM.Text = "������������";
                    LabelPriceName.Text = "������";
                }
                else if (hiddenFieldType.Value == "Spell")
                {
                    LabelPageTitle.Text = "�Ź���Ʒ�鿴ҳ";
                    LocalizePrice.Text = "�Ź��ۣ�";
                    LocalizeBuyStartTime.Text = "�Ź���ʼʱ�䣺";
                    LocalizeBuyEndTime.Text = "�Ź�����ʱ�䣺";
                    LocalizeBuyCount.Text = "�Ź���Ʒ������";
                    LocalizeMemberCount.Text = "�Ź�������";
                    LocalizeMemberMM.Text = "�����Ź�����";
                }
            }
        }
    }
}