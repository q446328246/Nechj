using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopReplyText : BaseShopWebControl
    {
        private HiddenField hid_ruleid;
        private Label lbl_waplink;
        private RadioButton rbtn_accurate;
        private RadioButton rbtn_vague;
        private string skinFilename = "W_ShopReplyText.ascx";
        private TextBox txt_content;
        private TextBox txt_keyword;

        public W_ShopReplyText()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            lbl_waplink = (Label) skin.FindControl("lbl_waplink");
            if (ConfigurationManager.AppSettings["wap_urlhost"] != null)
            {
                lbl_waplink.Text = string.Format("&nbsp;&nbsp;微信商城链接：&lt;a href=\"{0}\"&gt;进入微信商城&lt;/a&gt;",
                    ConfigurationManager.AppSettings["wap_urlhost"].Replace("{2}", ""));
            }
            string str = HttpContext.Current.Request.QueryString["ruleid"];
            if (!string.IsNullOrEmpty(str))
            {
                txt_keyword = (TextBox) skin.FindControl("txt_keyword");
                rbtn_accurate = (RadioButton) skin.FindControl("rbtn_accurate");
                rbtn_vague = (RadioButton) skin.FindControl("rbtn_vague");
                txt_content = (TextBox) skin.FindControl("txt_content");
                hid_ruleid = (HiddenField) skin.FindControl("hid_ruleid");
                IShopNum1_Weixin_ReplyRule_Active active = new ShopNum1_Weixin_ReplyRule_Active();
                DataSet set = active.SelectReplyRule(str);
                if (set.Tables.Count != 0)
                {
                    DataTable table = set.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        DataTable table2 = set.Tables[1];
                        var builder = new StringBuilder();
                        foreach (DataRow row in table2.Rows)
                        {
                            builder.AppendFormat("{0} ", row["KeyWord"]);
                        }
                        DataTable table3 = set.Tables[2];
                        txt_keyword.Text = builder.ToString().Trim();
                        txt_content.Text = (table3.Rows.Count != 0)
                            ? table3.Rows[0]["RepMsgContent"].ToString()
                            : string.Empty;
                        if (Convert.ToInt32(table.Rows[0]["Matching"]) == 1)
                        {
                            rbtn_vague.Checked = true;
                        }
                        else
                        {
                            rbtn_accurate.Checked = true;
                        }
                        hid_ruleid.Value = str;
                    }
                }
            }
        }
    }
}