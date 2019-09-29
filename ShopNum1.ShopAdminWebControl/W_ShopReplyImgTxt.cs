using System;
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
    public class W_ShopReplyImgTxt : BaseShopWebControl
    {
        private TextBox FCKeditorRemark;
        private HiddenField hid_articleid;
        private HiddenField hid_ruleid;
        private RadioButton rbtn_Arti;
        private RadioButton rbtn_accurate;
        private RadioButton rbtn_link;
        private RadioButton rbtn_vague;
        private Repeater rep_contentlist;
        private string skinFilename = "W_ShopReplyImgTxt.ascx";
        private HiddenField thumb;
        private Image thumb_img;
        private TextBox txt_description;
        private TextBox txt_keyword;
        private TextBox txt_title;

        public W_ShopReplyImgTxt()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            string str = HttpContext.Current.Request.QueryString["ruleid"];
            if (!string.IsNullOrEmpty(str))
            {
                txt_keyword = (TextBox) skin.FindControl("txt_keyword");
                rbtn_accurate = (RadioButton) skin.FindControl("rbtn_accurate");
                rbtn_vague = (RadioButton) skin.FindControl("rbtn_vague");
                txt_title = (TextBox) skin.FindControl("txt_title");
                thumb_img = (Image) skin.FindControl("thumb_img");
                thumb = (HiddenField) skin.FindControl("thumb");
                txt_description = (TextBox) skin.FindControl("txt_description");
                FCKeditorRemark = (TextBox) skin.FindControl("FCKeditorRemark");
                hid_ruleid = (HiddenField) skin.FindControl("hid_ruleid");
                hid_articleid = (HiddenField) skin.FindControl("hid_articleid");
                rep_contentlist = (Repeater) skin.FindControl("rep_contentlist");
                rbtn_Arti = (RadioButton) skin.FindControl("rbtn_Arti");
                rbtn_link = (RadioButton) skin.FindControl("rbtn_link");
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
                        if (table3.Rows.Count != 0)
                        {
                            txt_title.Text = table3.Rows[0]["Title"].ToString();
                            txt_description.Text = table3.Rows[0]["Description"].ToString();
                            thumb.Value = thumb_img.ImageUrl = table3.Rows[0]["ImgSrc"].ToString();
                            DataTable table4 = active.SelectArticle(table3.Rows[0]["ID"].ToString());
                            if (table4.Rows.Count != 0)
                            {
                                FCKeditorRemark.Text = table4.Rows[0]["ArticleContent"].ToString();
                                hid_articleid.Value = table4.Rows[0]["ID"].ToString();
                                if (Convert.ToInt32(table4.Rows[0]["Type"]) == 0)
                                {
                                    rbtn_link.Checked = true;
                                }
                                else
                                {
                                    rbtn_Arti.Checked = true;
                                }
                            }
                            DataTable table5 = active.SelectContent(str);
                            rep_contentlist.DataSource = table5;
                            rep_contentlist.DataBind();
                        }
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