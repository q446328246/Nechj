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
    public class W_ShopApiConfig : BaseShopWebControl
    {
        private CheckBox cb_Atten;
        private CheckBox cb_NotFind;
        private TextBox default_new;
        private TextBox default_reply;
        private string skinFilename = "W_ShopApiConfig.ascx";

        public W_ShopApiConfig()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            default_new = (TextBox) skin.FindControl("default_new");
            default_reply = (TextBox) skin.FindControl("default_reply");
            cb_Atten = (CheckBox) skin.FindControl("cb_Atten");
            cb_NotFind = (CheckBox) skin.FindControl("cb_NotFind");
            IShopNum1_Weixin_ShopWeiXinConfig_Active active = new ShopNum1_Weixin_ShopWeiXinConfig_Active();
            DataTable weixinConfig = active.GetWeixinConfig(base.MemLoginID);
            if (weixinConfig.Rows.Count != 0)
            {
                default_new.Text = weixinConfig.Rows[0]["AttenRepKeys"].ToString();
                default_reply.Text = weixinConfig.Rows[0]["NotFindKeys"].ToString();
                if (Convert.ToBoolean(weixinConfig.Rows[0]["IsOpenAtten"]))
                {
                    cb_Atten.Checked = true;
                }
                else
                {
                    cb_Atten.Checked = false;
                }
                if (Convert.ToBoolean(weixinConfig.Rows[0]["IsOpenNotFindKey"]))
                {
                    cb_NotFind.Checked = true;
                }
                else
                {
                    cb_NotFind.Checked = false;
                }
            }
        }
    }
}