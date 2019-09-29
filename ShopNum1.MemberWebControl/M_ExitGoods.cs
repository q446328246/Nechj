using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_ExitGoods : BaseMemberWebControl
    {
        private HtmlGenericControl pageDiv;
        private Repeater repExitMoney;
        private string skinFilename = "M_ExitGoods.ascx";

        public M_ExitGoods()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            repExitMoney = (Repeater) skin.FindControl("repExitMoney");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            if (!Page.IsPostBack)
            {
                method_1();
            }
        }

        private string BindData()
        {
            var builder = new StringBuilder(" and memloginid='" + base.MemLoginID + "' And refundtype=1 ");
            string str = Common.Common.ReqStr("rid");
            string str2 = Common.Common.ReqStr("oid");
            string str3 = Common.Common.ReqStr("sid");
            string str4 = Common.Common.ReqStr("type");
            if ((str4 == "") || (str4 == "1"))
            {
                builder.Append(" and refundstatus>0");
            }
            else
            {
                builder.Append(" and refundstatus=0");
            }
            if (str != "")
            {
                builder.Append(" and refundid='" + str + "'");
            }
            if (str2 != "")
            {
                builder.Append(" and ordernumber='" + str2 + "'");
            }
            if (str3 != "")
            {
                builder.Append(" and shopid='" + str3 + "'");
            }
            return builder.ToString();
        }

        private void method_1()
        {
            var action = (ShopNum1_Refund_Action) LogicFactory.CreateShopNum1_Refund_Action();
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(action.SelectRefundList(PageSize.ToString(), num.ToString(), BindData(), "3").Rows[0][0]);
            var bll = new PageListBll("main/member/M_ExitGoods.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            DataTable table2 = action.SelectRefundList(PageSize.ToString(), num.ToString(), BindData(), "2");
            repExitMoney.DataSource = table2.DefaultView;
            repExitMoney.DataBind();
        }

        public static string ReasonType(string rtype)
        {
            string result;
            switch (rtype)
            {
                case "1":
                    result = "七天无理由退换货";
                    return result;
                case "2":
                    result = "收到假货";
                    return result;
                case "3":
                    result = "退运费";
                    return result;
                case "4":
                    result = "收到商品破损";
                    return result;
                case "5":
                    result = "协商一致退货";
                    return result;
                case "6":
                    result = "商品错发/漏发";
                    return result;
                case "7":
                    result = "商品需要维修";
                    return result;
                case "8":
                    result = "发票问题";
                    return result;
                case "9":
                    result = "收到商品与描述不符";
                    return result;
                case "10":
                    result = "商品质量问题";
                    return result;
                case "11":
                    result = "未按约定时间发货";
                    return result;
            }
            result = "";
            return result;
        }

        public static string RefundStatus(string status, string rtype)
        {
            string result;
            switch (rtype)
            {
                case "1":
                    result = "七天无理由退换货";
                    return result;
                case "2":
                    result = "收到假货";
                    return result;
                case "3":
                    result = "退运费";
                    return result;
                case "4":
                    result = "收到商品破损";
                    return result;
                case "5":
                    result = "协商一致退货";
                    return result;
                case "6":
                    result = "商品错发/漏发";
                    return result;
                case "7":
                    result = "商品需要维修";
                    return result;
                case "8":
                    result = "发票问题";
                    return result;
                case "9":
                    result = "收到商品与描述不符";
                    return result;
                case "10":
                    result = "商品质量问题";
                    return result;
                case "11":
                    result = "未按约定时间发货";
                    return result;
            }
            result = "";
            return result;
        }
    }
}