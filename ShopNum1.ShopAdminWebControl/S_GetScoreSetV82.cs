using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    public class S_GetScoreSetV82 : BaseShopWebControl
    {
        public DataTable dt_SubProduct = null;
        private HiddenField hiddenField_0;
        private HtmlGenericControl pageDiv1;
        private Repeater repMainSetScore;
        private Repeater repeater_1;
        private string skinFilename = "S_GetScoreSetV82.ascx";

        public S_GetScoreSetV82()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        public DataTable dt_GetOrderProduct(string OrderGuId)
        {
            var action = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
            return action.SelectOrderProductByGuIdorAll(OrderGuId, HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
        }

        protected override void InitializeSkin(Control skin)
        {
            repMainSetScore = (Repeater) skin.FindControl("repMainSetScore");
            repMainSetScore.ItemDataBound += repMainSetScore_ItemDataBound;
            pageDiv1 = (HtmlGenericControl) skin.FindControl("pageDiv1");
            if (!Page.IsPostBack)
            {
                dt_SubProduct = dt_GetOrderProduct("");
                method_1();
            }
        }

        private string BindData()
        {
            var builder = new StringBuilder();
            builder.Append(" and shopid='" + base.MemLoginID + "' and BuyIsDeleted=0 and Oderstatus=3 ");
            string str = Common.Common.ReqStr("ord");
            string str2 = Common.Common.ReqStr("sd");
            string str3 = Common.Common.ReqStr("ed");
            string str4 = HttpUtility.HtmlDecode(Common.Common.ReqStr("mid"));
            Common.Common.ReqStr("ostate");
            Common.Common.ReqStr("sstate");
            Common.Common.ReqStr("pstate");
            Common.Common.ReqStr("quit");
            if (str != "")
            {
                builder.Append(" and ordernumber='" + str + "'");
            }
            if (str2 != "")
            {
                builder.Append(" and createtime>='" + str2 + "'");
            }
            if (str3 != "")
            {
                builder.Append(" and createtime<='" + str3 + "'");
            }
            if (str4 != "")
            {
                builder.Append(" and memloginid like '%" + str4 + "%'");
            }
            return builder.ToString();
        }

        protected void method_1()
        {
            DataTable table = null;
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            int pageCount = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                pageCount = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    action.SelectOrderList(PageSize.ToString(), pageCount.ToString(), BindData(), "3",
                        HttpUtility.HtmlDecode(Common.Common.ReqStr("pn"))).Rows[0][0]);
            var bll = new PageListBll("shop/ShopAdmin/S_GetScoreSetV82.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = pageCount,
                RecordCount = num3
            };
            pageDiv1.InnerHtml = bll.GetPageListNew(pl);
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pageCount > pl.PageCount)
            {
                pageCount = pl.PageCount;
            }
            table = action.SelectOrderList(PageSize.ToString(), pageCount.ToString(), BindData(), "2",
                HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            repMainSetScore.DataSource = table.DefaultView;
            repMainSetScore.DataBind();
        }

        protected void repMainSetScore_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                repeater_1 = (Repeater) e.Item.FindControl("repSubSetScore");
                hiddenField_0 = (HiddenField) e.Item.FindControl("hidGuId");
                DataRow[] rows = dt_SubProduct.Select("OrderInfoGuid='" + hiddenField_0.Value + "'");
                repeater_1.DataSource = ToDataTable(rows);
                repeater_1.DataBind();
            }
        }

        public DataTable ToDataTable(DataRow[] rows)
        {
            if ((rows == null) || (rows.Length == 0))
            {
                return null;
            }
            DataTable table = rows[0].Table.Clone();
            foreach (DataRow row in rows)
            {
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }
    }
}