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

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_ShipAddress : BaseMemberWebControl
    {
        private Repeater Rep_NoValue;
        private HtmlGenericControl pageDiv;
        private Repeater rep_Address;
        private string skinFilename = "A_ShipAddress.ascx";

        public A_ShipAddress()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Hid_GuidValue { get; set; }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public static string GetAddressDetil(string area, string address)
        {
            string[] strArray2 = area.Split(new[] {'|'})[0].Split(new[] {','});
            string str = string.Empty;
            if (strArray2.Length > 2)
            {
                str = strArray2[0] + strArray2[1] + strArray2[2];
            }
            else if (strArray2.Length > 1)
            {
                str = strArray2[0] + strArray2[1];
            }
            else if (strArray2.Length > 0)
            {
                str = strArray2[0];
            }
            return (str + address);
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            rep_Address = (Repeater) skin.FindControl("rep_Address");
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            rep_Address.ItemCommand += Rep_Address_ItemCommand;
            method_0();
        }

        private void method_0()
        {
            var action = (ShopNum1_Address_Action) LogicFactory.CreateShopNum1_Address_Action();
            try
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(base.MemLoginID))
                {
                    str = str + "  AND  MemLoginID=  '" + base.MemLoginID + "'   ";
                }
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0",
                    Currentpage = pageid,
                    Tablename = "ShopNum1_Address",
                    Resultnum = "0",
                    PageSize = PageSize
                };
                DataTable table = action.SelectAddress_List(commonModel);
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
                    new PageListBll("main/Account/A_ShipAddress.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                DataTable table3 = action.SelectAddress_List(commonModel);
                if (table3.Rows.Count > 0)
                {
                    rep_Address.DataSource = table3.DefaultView;
                    rep_Address.DataBind();
                }
                else
                {
                    Rep_NoValue.Visible = true;
                    rep_Address.Visible = false;
                    var table2 = new DataTable();
                    table2.Columns.Add("NoValue", typeof (string));
                    DataRow row = table2.NewRow();
                    row["NoValue"] = "暂无信息";
                    table2.Rows.Add(row);
                    Rep_NoValue.DataSource = table2;
                    Rep_NoValue.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Rep_Address_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            var field = (HiddenField) e.Item.FindControl("HiddenField_Guid");
            Hid_GuidValue = field.Value;
            if (e.CommandName == "delete")
            {
                var action = (ShopNum1_Address_Action) LogicFactory.CreateShopNum1_Address_Action();
                action.Delete("'" + Hid_GuidValue + "'");
                Page.Response.Redirect("A_ShipAddress.aspx");
            }
            if (e.CommandName == "defalut")
            {
                ((ShopNum1_Address_Action) LogicFactory.CreateShopNum1_Address_Action()).ChangeDefaultAddress(
                    base.MemLoginID, Hid_GuidValue);
                method_0();
            }
        }
    }
}