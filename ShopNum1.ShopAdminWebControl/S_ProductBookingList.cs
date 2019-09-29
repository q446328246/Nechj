using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ProductBookingList : BaseShopWebControl
    {
        private LinkButton LinkDelete;
        private Repeater Rep_NoValue;
        private Repeater RepeaterShow;
        private HiddenField hid_SelectGuid;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ProductBookingList.ascx";

        public S_ProductBookingList()
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
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemCommand += RepeaterShow_ItemCommand;
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            BindData();
        }

        public static string IsOrNo(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已预约";
            }
            return "未预约";
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            string guid = hid_SelectGuid.Value;
            var action = (Shop_ProductBooking_Action) LogicFactory.CreateShop_ProductBooking_Action();
            if (action.DeleteProductBooking(guid) > 0)
            {
                MessageBox.Show("删除成功！");
                BindData();
            }
        }

        protected void BindData()
        {
            var action = (Shop_ProductBooking_Action) LogicFactory.CreateShop_ProductBooking_Action();
            var action2 = (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string str = action2.GetShopIDByMemLoginID(base.MemLoginID).Rows[0]["ShopID"].ToString();
            string str2 = string.Empty;
            if (!string.IsNullOrEmpty(base.MemLoginID))
            {
                str2 = str2 + "  AND  shopid=  '" + str + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "   " + str2 + "  ",
                Currentpage = pageid,
                Tablename = "ShopNum1_Shop_ProductBooking",
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table2 = action.SelectProductBook_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("/Shop/ShopAdmin/S_ProductBookingList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table = action.SelectProductBook_List(commonModel);
            if (table.Rows.Count > 0)
            {
                RepeaterShow.DataSource = table;
                RepeaterShow.DataBind();
            }
            else
            {
                Rep_NoValue.Visible = true;
                var table3 = new DataTable();
                table3.Columns.Add("NoValue", typeof (string));
                DataRow row = table3.NewRow();
                row["NoValue"] = "暂无数据";
                table3.Rows.Add(row);
                Rep_NoValue.DataSource = table3;
                Rep_NoValue.DataBind();
            }
        }

        protected void RepeaterShow_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
        }
    }
}