using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class NewsCategoryShow : BaseWebControl
    {
        private Repeater RepeaterData;
        private Repeater repeater_1;
        private string skinFilename = "NewsCategoryShow.ascx";

        public NewsCategoryShow()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable newsCategoryList =
                ((Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action()).GetNewsCategoryList(
                    MemLoginID, "1");
            RepeaterData.DataSource = newsCategoryList;
            RepeaterData.DataBind();
        }

        protected void method_1(string string_2)
        {
            DataTable table = ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).SearchNewsList(MemLoginID,
                string_2);
            RepeaterData.DataSource = (ShowCount == 0) ? table : Top(table, Convert.ToInt32(ShowCount));
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            repeater_1 = (Repeater) e.Item.FindControl("RepeaterDataTitle");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            method_1(field.Value);
        }

        public DataTable Top(DataTable dt, int count)
        {
            int num3 = (dt.Rows.Count > count) ? count : dt.Rows.Count;
            DataTable table = dt.Clone();
            for (int i = 0; i < num3; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row[j] = dt.Rows[i][j].ToString();
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}