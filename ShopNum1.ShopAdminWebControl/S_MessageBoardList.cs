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
    public class S_MessageBoardList : BaseShopWebControl
    {
        private LinkButton LinkDelete;
        private Repeater Rep_NoValue;
        private Repeater RepeaterShow;
        private HiddenField hid_SelectGuid;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_MessageBoardList.ascx";

        public S_MessageBoardList()
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
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemCommand += RepeaterShow_ItemCommand;
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            LinkDelete = (LinkButton) skin.FindControl("LinkDelete");
            LinkDelete.Click += LinkDelete_Click;
            hid_SelectGuid = (HiddenField) skin.FindControl("hid_SelectGuid");
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

        public static string IsType(object object_0)
        {
            string str2 = object_0.ToString();
            switch (str2)
            {
                case null:
                    break;

                case "0":
                    return "询问";

                case "1":
                    return "求购";

                default:
                    if (!(str2 == "2"))
                    {
                        if (str2 == "3")
                        {
                            return "其它";
                        }
                    }
                    else
                    {
                        return "售后";
                    }
                    break;
            }
            return "其它";
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            string guid = hid_SelectGuid.Value;
            var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            if (action.DeleteMessageBoard(guid) > 0)
            {
                MessageBox.Show("删除成功！");
                Page.Response.Redirect("S_MessageBoardList.aspx");
            }
        }

        protected void BindData()
        {
            var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(base.MemLoginID))
            {
                str = str + "  AND  ReplyUser=  '" + base.MemLoginID + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "   " + str + "  ",
                Currentpage = pageid,
                Tablename = "ShopNum1_Shop_MessageBoard",
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table2 = action.SelectMessageBoard_List(commonModel);
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
                new PageListBll("/Shop/ShopAdmin/S_MessageBoardList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table = action.SelectMessageBoard_List(commonModel);
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
            var hidden = (HtmlInputHidden) e.Item.FindControl("hid_Guid");
            string str = hidden.Value;
            if (e.CommandName == "delete")
            {
                var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
                if (action.DeleteMessageBoard("'" + str + "'") > 0)
                {
                    MessageBox.Show("删除成功！");
                    Page.Response.Redirect("S_MessageBoardList.aspx");
                }
            }
        }
    }
}