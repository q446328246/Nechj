using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.AdXml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvertisementImg_Operate : PageBase, IRequiresSessionState
    {
        private readonly DefaultAdvertismentOperate defaultAdvertismentOperate_0 = new DefaultAdvertismentOperate();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"].Replace("'", "");
            TextBoxID.Text = defaultAdvertismentOperate_0.GetMaxId().ToString();
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelPageTitle.Text = "编辑图片广告";
                GetEditInfo();
                ButtonConfirm.Text = "更新";
            }
        }

        public void Add()
        {
            string title = TextBoxName.Text.Trim();
            string href = TextBoxHref.Text.Trim();
            string imgsrc = TextBoxpath.Text.Trim();
            string height = TextBoxHeight.Text.Trim();
            string width = TextBoxWidth.Text.Trim();
            string pageName = TextBoxPageName.Text.Trim();
            string str7 = TextBoxDes.Text.Trim();
            int num = 0;
            try
            {
                num = defaultAdvertismentOperate_0.Add(title, imgsrc, href, width, height, pageName, str7);
            }
            catch (Exception)
            {
            }
            if (num > 0)
            {
                base.Response.Redirect("AdvertisementImg_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑图片广告",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvertisementImg_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加图片广告",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvertisementImg_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        public void Edit()
        {
            string str = hiddenFieldGuid.Value.Replace("'", "");
            string title = TextBoxName.Text.Trim();
            string linkUrl = TextBoxHref.Text.Trim();
            string imgsrc = TextBoxpath.Text.Trim();
            string height = TextBoxHeight.Text.Trim();
            string width = TextBoxWidth.Text.Trim();
            string pageName = TextBoxPageName.Text.Trim();
            string str8 = TextBoxDes.Text.Trim();
            var operate = new DefaultAdvertismentOperate();
            if (operate.Update(str, title, imgsrc, linkUrl, height, width, pageName, str8) > 0)
            {
                base.Response.Redirect("AdvertisementImg_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public void GetEditInfo()
        {
            DataRow row = DefaultAdvertismentOperate.SelecByID(hiddenFieldGuid.Value.Replace("'", "")).Rows[0];
            TextBoxID.Text = hiddenFieldGuid.Value;
            TextBoxName.Text = row["title"].ToString();
            TextBoxHeight.Text = row["height"].ToString();
            TextBoxWidth.Text = row["width"].ToString();
            TextBoxpath.Text = row["imgsrc"].ToString();
            TextBoxHref.Text = row["href"].ToString();
            TextBoxPageName.Text = row["pagename"].ToString();
            TextBoxDes.Text = row["des"].ToString();
            imgshow.Src = TextBoxpath.Text;
        }
    }
}