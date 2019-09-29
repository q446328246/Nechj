using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopUser : BaseShopWebControl
    {
        private Button Btn_OK;
        private HtmlInputHidden hidDataCheck;
        private HiddenField hid_TwoDimensionalPic;
        private Image img_TwoDimensionalPic;
        private string skinFilename = "W_ShopUser.ascx";
        private TextBox txt_PublicNo;
        private TextBox txt_weixinName;

        public W_ShopUser()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void Btn_OK_Click(object sender, EventArgs e)
        {
            var active = new ShopNum1_WeiXin_ShopUser_Active();
            var shopUser = new ShopNum1_WeiXin_ShopUser();
            if (hidDataCheck.Value == "ok")
            {
                shopUser.ShopLoginID = base.MemLoginID;
                shopUser.WeiXinName = txt_weixinName.Text.Trim();
                shopUser.PublicNo = txt_PublicNo.Text.Trim();
                shopUser.TwoDimensionalPic = hid_TwoDimensionalPic.Value;
                shopUser.CreateTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                shopUser.ModifyTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                if (active.UpdateWeiXinHao(shopUser) > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            else
            {
                shopUser.ShopLoginID = base.MemLoginID;
                shopUser.WeiXinName = txt_weixinName.Text.Trim();
                shopUser.PublicNo = txt_PublicNo.Text.Trim();
                shopUser.TwoDimensionalPic = hid_TwoDimensionalPic.Value;
                shopUser.CreateTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                shopUser.ModifyTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                if (active.AddWeiXinHao(shopUser) > 0)
                {
                    MessageBox.Show("添加成功！");
                }
            }
            DataBindWx();
        }

        protected void DataBindWx()
        {
            IShopNum1_WeiXin_ShopUser_Active active = new ShopNum1_WeiXin_ShopUser_Active();
            DataTable table = active.SelectWeiXinHao(base.MemLoginID);
            if (table.Rows.Count != 0)
            {
                hidDataCheck.Value = "ok";
                txt_weixinName.Text = table.Rows[0]["WeiXinName"].ToString();
                txt_PublicNo.Text = table.Rows[0]["PublicNo"].ToString();
                hid_TwoDimensionalPic.Value =
                    img_TwoDimensionalPic.ImageUrl = table.Rows[0]["TwoDimensionalPic"].ToString();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_weixinName = (TextBox) skin.FindControl("txt_weixinName");
            txt_PublicNo = (TextBox) skin.FindControl("txt_PublicNo");
            img_TwoDimensionalPic = (Image) skin.FindControl("img_TwoDimensionalPic");
            hid_TwoDimensionalPic = (HiddenField) skin.FindControl("hid_TwoDimensionalPic");
            Btn_OK = (Button) skin.FindControl("Btn_OK");
            Btn_OK.Click += Btn_OK_Click;
            hidDataCheck = (HtmlInputHidden) skin.FindControl("hidDataCheck");
            DataBindWx();
        }
    }
}