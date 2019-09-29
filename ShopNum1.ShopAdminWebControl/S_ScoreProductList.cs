using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ScoreProductList : BaseShopWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListIsAudit;
        private Repeater RepeaterShow;
        private TextBox TextBoxName;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ScoreProductList.ascx";

        public S_ScoreProductList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public static string GetProductCategoryCode(string code)
        {
            string str = string.Empty;
            if (code != "")
            {
                int length = code.Length;
                if ((length <= 0) || (length > 9))
                {
                    return str;
                }
                int num3 = length/3;
                string str2 = string.Empty;
                for (int i = 1; i <= num3; i++)
                {
                    str2 = code.Substring(0, 3*i);
                    DataTable dataInfoByCode =
                        ((ShopNum1_ScoreProductCategory_Action)
                            LogicFactory.CreateShopNum1_ScoreProductCategory_Action()).GetDataInfoByCode(str2);
                    if ((dataInfoByCode != null) && (dataInfoByCode.Rows.Count > 0))
                    {
                        if (str == string.Empty)
                        {
                            str = dataInfoByCode.Rows[0]["Name"].ToString();
                        }
                        else
                        {
                            str = str + "/" + dataInfoByCode.Rows[0]["Name"];
                        }
                    }
                }
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            DropDownListIsAudit = (DropDownList) skin.FindControl("DropDownListIsAudit");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            BindData();
        }

        public static string IsAudit(string IsAudit)
        {
            if (IsAudit == "0")
            {
                return "<span style=\" color:red\">未审核</span>";
            }
            if (IsAudit == "1")
            {
                return "审核通过";
            }
            if (IsAudit == "2")
            {
                return "<span style=\" color:red\">审核未通过</span>";
            }
            return "";
        }

        protected void BindData()
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            string str = string.Empty;
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "  AND  IsAudit=  '" + DropDownListIsAudit.SelectedValue + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxName.Text))
            {
                str = str + "  AND  Name   LIKE   '%" + TextBoxName.Text.Trim() + "%'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND    MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("Shop/ShopAdmin/S_ScoreProduct.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}