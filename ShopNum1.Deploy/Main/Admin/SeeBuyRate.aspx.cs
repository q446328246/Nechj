using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SeeBuyRate : PageBase, IRequiresSessionState
    {
        protected const string SeeBuyRate_Report = "SeeBuyRate_Report.aspx";
        protected char charSapce = '　';
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindProductCategory();
                BindBrand();
                DropDownListProductGuidBind();
            }
        }

        protected void AddSubProductCategory(DataTable dataTable)
        {
        }

        protected void BindBrand()
        {
            var item = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListBrandGuid.Items.Add(item);
            var action = (ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                DropDownListBrandGuid.Items.Add(item2);
            }
        }

        protected void BindProductCategory()
        {
        }

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            if (this.DropDownListProductGuid3.SelectedValue != "-1")
            {
                this.DropDownListProductGuid3.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            else if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                this.DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            else if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                this.DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出访问购买率Html数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SeeBuyRate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("SeeBuyRate_Report.aspx?Type=html&name=" + txtProductName.Text +
                                   "&ProductCategoryCode1=" + this.DropDownListProductGuid1.SelectedValue +
                                   "&ProductCategoryCode2=" + this.DropDownListProductGuid2.SelectedValue +
                                   "&ProductCategoryCode3=" + this.DropDownListProductGuid3.SelectedValue +
                                   "&BrandGuid=" + DropDownListBrandGuid.SelectedValue + "&&ShopPrice1=" +
                                   TextBoxShopPrice1.Text.Trim() + "&&ShopPrice2=" + TextBoxShopPrice2.Text.Trim() +
                                   "&&MarketPrice1=" + TextBoxMarketPrice1.Text.Trim() + "&&MarketPrice2=" +
                                   TextBoxMarketPrice2.Text.Trim());
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            if (this.DropDownListProductGuid3.SelectedValue != "-1")
            {
                this.DropDownListProductGuid3.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            else if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                this.DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            else if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                this.DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[0].Trim();
            }
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出访问购买率Excel数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SeeBuyRate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("SeeBuyRate_Report.aspx?Type=xls&name=" + txtProductName.Text +
                                   "&ProductCategoryCode1=" + this.DropDownListProductGuid1.SelectedValue +
                                   "&ProductCategoryCode2=" + this.DropDownListProductGuid2.SelectedValue +
                                   "&ProductCategoryCode3=" + this.DropDownListProductGuid3.SelectedValue +
                                   "&BrandGuid=" + DropDownListBrandGuid.SelectedValue + "&&ShopPrice1=" +
                                   TextBoxShopPrice1.Text.Trim() + "&&ShopPrice2=" + TextBoxShopPrice2.Text.Trim() +
                                   "&&MarketPrice1=" + TextBoxMarketPrice1.Text.Trim() + "&&MarketPrice2=" +
                                   TextBoxMarketPrice2.Text.Trim());
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Num1GridViewShow.DataBind();
        }

        protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid2.Items.Clear();
            this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(
                        this.DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListProductGuid2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid3.Items.Clear();
            this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(
                        this.DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListProductGuidBind()
        {
            this.DropDownListProductGuid1.Items.Clear();
            this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                     list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListProductGuid1_SelectedIndexChanged(null, null);
        }


    }
}