using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Logistics : BaseShopWebControl
    {
        private HtmlInputHidden HiddenShowCount;
        private Label LabelPageMessage;
        private Repeater RepeaterFeeTemplate;
        private DataView dataView_0;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "S_Logistics.ascx";

        public S_Logistics()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            HiddenShowCount = (HtmlInputHidden) skin.FindControl("HiddenShowCount");
            RepeaterFeeTemplate = (Repeater) skin.FindControl("RepeaterFeeTemplate");
            RepeaterFeeTemplate.ItemDataBound += RepeaterFeeTemplate_ItemDataBound;
            if (!Page.IsPostBack && ((Common.Common.ReqStr("sing") != "") && (Common.Common.ReqStr("delid") != "")))
            {
                var action = new Shop_FeeTemplate_Action();
                string path = method_2();
                if (action.DelByTemplateID(Common.Common.ReqStr("delid"), Page.Server.MapPath(path)))
                {
                }
            }
            BindData();
        }

        protected void BindData()
        {
            var action = new Shop_FeeTemplate_Action();
            string path = method_2();
            string strerror = string.Empty;
            DataTable table = action.GetFeesByIDRegion(Page.Server.MapPath(path), "-1", "-1", "-1", out strerror);
            if ((table != null) && (table.Rows.Count != 0))
            {
                int num2 = int.Parse(HiddenShowCount.Value);
                dataView_0 = new DataView(table);
                var source = new PagedDataSource();
                DataTable table2 = dataView_0.ToTable(true, new[] {"templateid", "templatename", "altertime"});
                source.DataSource = table2.DefaultView;
                source.AllowPaging = true;
                if (num2 < 1)
                {
                    source.PageSize = 10;
                }
                else
                {
                    source.PageSize = num2;
                }
                int currentPage = -1;
                if (Page.Request.QueryString.Get("page") != null)
                {
                    currentPage = Convert.ToInt32(Page.Request.QueryString.Get("page"));
                }
                else
                {
                    currentPage = 1;
                }
                source.CurrentPageIndex = currentPage - 1;
                var common = new Num1WebControlCommon();
                LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                    currentPage);
                lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage);
                lnkPrev.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage - 1));
                lnkFirst.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1";
                lnkNext.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage + 1));
                lnkLast.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + source.PageCount;
                if ((currentPage <= 1) && (source.PageCount <= 1))
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }
                if ((currentPage <= 1) && (source.PageCount > 1))
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                }
                if (currentPage >= source.PageCount)
                {
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }
                RepeaterFeeTemplate.DataSource = source;
                RepeaterFeeTemplate.DataBind();
            }
        }

        private string method_1(string string_1)
        {
            string str = string_1;
            switch (str)
            {
                case null:
                    break;

                case "1":
                    return "平邮";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
                        {
                            return "EMS";
                        }
                    }
                    else
                    {
                        return "快递";
                    }
                    break;
            }
            return "";
        }

        private string method_2()
        {
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            return ("~/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + str + "/xml/PostageTemplate.xml");
        }

        protected void RepeaterFeeTemplate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var hidden = (HtmlInputHidden) e.Item.FindControl("hiddenTemplateid");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChildFeeTemplate");
                string format = "templateid='{0}'";
                string sort = "orderid DESC";
                DataTable table = dataView_0.Table.Select(string.Format(format, hidden.Value), sort).CopyToDataTable();
                if ((table != null) && (table.Rows.Count != 0))
                {
                    table.Columns.Add("feename", typeof (string));
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i]["feename"] = method_1(table.Rows[i]["feetype"].ToString());
                    }
                    repeater.DataSource = table;
                    repeater.DataBind();
                }
            }
        }
    }
}