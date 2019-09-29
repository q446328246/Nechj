using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_UserDefinedColumnList : BaseShopWebControl
    {
        private LinkButton LinkDelete;
        private Repeater Rep_NoValue;
        private HiddenField hid_SelectGuid;
        private HtmlGenericControl pageDiv;
        private Repeater rep_UserDefinedColumn;
        private string skinFilename = "S_UserDefinedColumnList.ascx";

        public S_UserDefinedColumnList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            LinkDelete = (LinkButton) skin.FindControl("LinkDelete");
            LinkDelete.Click += LinkDelete_Click;
            hid_SelectGuid = (HiddenField) skin.FindControl("hid_SelectGuid");
            rep_UserDefinedColumn = (Repeater) skin.FindControl("rep_UserDefinedColumn");
            rep_UserDefinedColumn.ItemCommand += rep_UserDefinedColumn_ItemCommand;
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            BindData();
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            string guid = hid_SelectGuid.Value;
            var action = (Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action();
            if (action.DeleteUserDefinedColumn(guid) > 0)
            {
                MessageBox.Show("删除成功！");
                Page.Response.Redirect("S_UserDefinedColumnList.aspx");
            }
        }

        protected void BindData()
        {
            var action = (Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(base.MemLoginID))
            {
                str = str + "  AND  MemLoginID=  '" + base.MemLoginID + " '";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "   " + str + "  ",
                Currentpage = pageid
            };
            string currentpage = commonModel.Currentpage;
            commonModel.Tablename = "ShopNum1_Shop_UserDefinedColumn";
            commonModel.Resultnum = "0";
            commonModel.PageSize = PageSize;
            DataTable table3 = action.SelectNavigation_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table3 != null) && (table3.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table3.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("/Shop/ShopAdmin/S_UserDefinedColumnList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table = action.SelectNavigation_List(commonModel);
            if (table.Rows.Count < 0)
            {
                Rep_NoValue.Visible = true;
                var table2 = new DataTable();
                table2.Columns.Add("NoValue", typeof (string));
                DataRow row = table2.NewRow();
                row["NoValue"] = "暂无数据";
                table2.Rows.Add(row);
                Rep_NoValue.DataSource = table2;
                Rep_NoValue.DataBind();
            }
            else
            {
                rep_UserDefinedColumn.DataSource = table;
                rep_UserDefinedColumn.DataBind();
            }
        }

        protected void rep_UserDefinedColumn_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            var hidden = (HtmlInputHidden) e.Item.FindControl("hid_Guid");
            string str = hidden.Value;
            if (e.CommandName == "delete")
            {
                var action = (Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action();
                if (action.DeleteUserDefinedColumn("'" + str + "'") > 0)
                {
                    MessageBox.Show("删除成功！");
                    Page.Response.Redirect("S_UserDefinedColumnList.aspx");
                }
            }
        }
    }
}