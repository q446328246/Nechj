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

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_MyMessageBoard : BaseMemberWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListIsReply;
        private DropDownList DropDownListMessageType;
        private Repeater RepeaterShow;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_MyMessageBoard.ascx";

        public M_MyMessageBoard()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public static string GetMessageTypeName(string MessageType)
        {
            string str = MessageType;
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "询问";

                case "1":
                    return "求购";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
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

        public static string GetShopName(string MemLoginID)
        {
            string str = string.Empty;
            try
            {
                string str3 = Common.Common.GetNameById("ShopName", "ShopNum1_ShopInfo",
                    "   AND  MemLoginID='" + MemLoginID + "'   ");
                if (!string.IsNullOrEmpty(str3))
                {
                    str = str3;
                }
            }
            catch (Exception)
            {
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            DropDownListMessageType = (DropDownList) skin.FindControl("DropDownListMessageType");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            DropDownListIsReply = (DropDownList) skin.FindControl("DropDownListIsReply");
            BindData();
        }

        private void BindData()
        {
            var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            string str = string.Empty;
            if (DropDownListMessageType.SelectedValue != "-1")
            {
                str = str + "  AND  MessageType=  '" + DropDownListMessageType.SelectedValue + "'   ";
            }
            if (DropDownListIsReply.SelectedValue != "-1")
            {
                str = str + "  AND    IsReply=  '" + DropDownListIsReply.SelectedValue + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND    MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.SelectMyShopMessageBoard_List(commonModel);
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
                new PageListBll("main/member/M_MyMessageBoard.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.SelectMyShopMessageBoard_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}