using System;
using System.Collections.Generic;
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
    public class S_PackAgeOpreate : BaseShopWebControl
    {
        private Button btnSub;
        private HtmlInputHidden hidCheckIsOpen;
        private HtmlInputHidden hidPrice;
        private HtmlInputHidden hidProductGuId;
        private HtmlInputHidden htmlInputHidden_3;
        private Label lblShopPrice;
        private Repeater repSp;
        private string skinFilename = "S_PackAgeOpreate.ascx";
        private string string_1 = string.Empty;
        private HtmlTextArea txtDesc;
        private HtmlInputText txtName;
        private HtmlInputText txtSalePrice;

        public S_PackAgeOpreate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var action = (Shop_PackAge_Action) LogicFactory.CreateShop_PackAge_Action();
            string str = Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                " and memloginID='" + base.MemLoginID + "'");
            var age = new ShopNum1_PackAge
            {
                Name = Operator.FilterString(txtName.Value),
                Desc = txtDesc.Value,
                Price = decimal.Parse(hidPrice.Value),
                SalePrice = decimal.Parse(txtSalePrice.Value),
                Pic = htmlInputHidden_3.Value,
                State = Convert.ToInt32(hidCheckIsOpen.Value),
                MemloginId = base.MemLoginID,
                ShopName = str,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            if (Common.Common.ReqStr("packid") == "")
            {
                age.Id = 0;
            }
            else
            {
                age.Id = Convert.ToInt32(Common.Common.ReqStr("packid"));
            }
            var listPackAgeRalate = new List<ShopNum1_PackAgeRalate>();
            if (hidProductGuId.Value != "")
            {
                string[] strArray = (hidProductGuId.Value + ",0").Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "0")
                    {
                        var item = new ShopNum1_PackAgeRalate
                        {
                            ProductGuid = new Guid(strArray[i])
                        };
                        listPackAgeRalate.Add(item);
                    }
                }
            }
            action.OpPackAge(age, listPackAgeRalate);
            Page.Response.Redirect("S_PackAgeList.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            lblShopPrice = (Label) skin.FindControl("lblShopPrice");
            repSp = (Repeater) skin.FindControl("repSp");
            txtName = (HtmlInputText) skin.FindControl("txtName");
            txtSalePrice = (HtmlInputText) skin.FindControl("txtSalePrice");
            txtDesc = (HtmlTextArea) skin.FindControl("txtDesc");
            hidCheckIsOpen = (HtmlInputHidden) skin.FindControl("hidCheckIsOpen");
            hidProductGuId = (HtmlInputHidden) skin.FindControl("hidProductGuId");
            hidPrice = (HtmlInputHidden) skin.FindControl("hidPrice");
            btnSub = (Button) skin.FindControl("btnSub");
            htmlInputHidden_3 = (HtmlInputHidden) skin.FindControl("hidPic");
            btnSub.Click += btnSub_Click;
            string_1 = Common.Common.ReqStr("packid");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataSet packAgeInfo =
                ((Shop_PackAge_Action) LogicFactory.CreateShop_PackAge_Action()).GetPackAgeInfo(string_1,
                    base.MemLoginID);
            if (packAgeInfo != null)
            {
                if (packAgeInfo.Tables[0].Rows.Count > 0)
                {
                    txtName.Value = packAgeInfo.Tables[0].Rows[0]["name"].ToString();
                    txtSalePrice.Value = packAgeInfo.Tables[0].Rows[0]["SalePrice"].ToString();
                    txtDesc.Value = packAgeInfo.Tables[0].Rows[0]["Desc"].ToString();
                    hidPrice.Value = packAgeInfo.Tables[0].Rows[0]["Price"].ToString();
                    lblShopPrice.Text = packAgeInfo.Tables[0].Rows[0]["Price"].ToString();
                    htmlInputHidden_3.Value = packAgeInfo.Tables[0].Rows[0]["Pic"].ToString();
                    hidCheckIsOpen.Value = packAgeInfo.Tables[0].Rows[0]["state"].ToString();
                }
                repSp.DataSource = packAgeInfo.Tables[1].DefaultView;
                repSp.DataBind();
            }
        }
    }
}