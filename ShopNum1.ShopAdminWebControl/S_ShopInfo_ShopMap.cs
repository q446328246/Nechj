using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopInfo_ShopMap : BaseShopWebControl
    {
        private Button ButtonSave;
        private TextBox TextBoxMapValue;
        private string skinFilename = "S_ShopInfo_ShopMap.ascx";

        public S_ShopInfo_ShopMap()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindData()
        {
            DataTable shopInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopInfo(base.MemLoginID);
            if (((shopInfo != null) && (shopInfo.Rows.Count > 0)) && (shopInfo.Rows[0]["Longitude"].ToString() != ""))
            {
                TextBoxMapValue.Text = shopInfo.Rows[0]["Longitude"] + "," + shopInfo.Rows[0]["Latitude"];
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (TextBoxMapValue.Text == "")
            {
                MessageBox.Show("请点击一个地区！");
            }
            else
            {
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                if (
                    action.UpdateLongLat(TextBoxMapValue.Text.Split(new[] {','})[0],
                        TextBoxMapValue.Text.Split(new[] {','})[1],
                        base.MemLoginID) > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxMapValue = (TextBox) skin.FindControl("TextBoxMapValue");
            ButtonSave = (Button) skin.FindControl("ButtonSave");
            ButtonSave.Click += ButtonSave_Click;
            BindData();
        }
    }
}