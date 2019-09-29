using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopConfig : BaseShopWebControl
    {
        private HiddenField hid_log;
        private Image img_logo;
        private Repeater rep_flash;
        private string skinFilename = "W_ShopConfig.ascx";
        private TextBox txt_mobile;
        private TextBox txt_weixin;

        public W_ShopConfig()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_weixin = (TextBox) skin.FindControl("txt_weixin");
            txt_mobile = (TextBox) skin.FindControl("txt_mobile");
            img_logo = (Image) skin.FindControl("img_logo");
            hid_log = (HiddenField) skin.FindControl("hid_log");
            rep_flash = (Repeater) skin.FindControl("rep_flash");
            string shopid = Common.Common.GetNameById("ShopId", "shopnum1_shopinfo",
                string.Format(" and memloginid='{0}'", base.MemLoginID));
            IShopNum1_Weixin_ShopConfig_Active active = new ShopNum1_Weixin_ShopConfig_Active();
            DataTable table = active.Get_Config(shopid);
            DataTable table2 = table.Clone();
            if (table.Rows.Count != 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    switch (Convert.ToInt32(row["ConfigType"]))
                    {
                        case 0:
                            hid_log.Value = img_logo.ImageUrl = row["Value"].ToString();
                            break;

                        case 1:
                            table2.Rows.Add(row.ItemArray);
                            break;

                        case 2:
                            txt_weixin.Text = row["Value"].ToString();
                            break;

                        case 3:
                            txt_mobile.Text = row["Value"].ToString();
                            break;
                    }
                }
                rep_flash.DataSource = table2;
                rep_flash.DataBind();
            }
        }
    }
}