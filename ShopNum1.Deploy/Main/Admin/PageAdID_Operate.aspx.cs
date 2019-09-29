using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PageAdID_Operate : PageBase, IRequiresSessionState
    {
        private ShopNum1_PageAdID_Action shopNum1_PageAdID_Action_0 = ((ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action());

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", "");
            if (!this.Page.IsPostBack)
            {
                this.GetFileName();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.GetEditInfo();
                    this.lbltitle.Text = "编辑自动广告位";
                    this.ButtonConfirm.Text = "更新";
                }
                else
                {
                    this.TextBoxAdID.Text = this.shopNum1_PageAdID_Action_0.GetNewDivID();
                }
            }
        }

        public void Add()
        {
            PageAdID pageAdID = new PageAdID
            {
                Guid = Guid.NewGuid().ToString(),
                PageName = this.TextBoxPageName.Text,
                FileName = this.DropDownListFileName.SelectedItem.Text,
                Content = this.TextBoxContent.Text.Trim(),
                DivID = this.TextBoxAdID.Text.Trim(),
                Height = this.TextBoxHeight.Text.Trim(),
                Width = this.TextBoxWidth.Text.Trim()
            };
            if (this.shopNum1_PageAdID_Action_0.Add(pageAdID) > 0)
            {
                base.Response.Redirect("PageAdID_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("PageAdID_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (this.hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "编辑自动广告位",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "PageAdID_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "添加自动广告位",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "PageAdID_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.Add();
            }
        }

        public void Edit()
        {
            PageAdID pageAdID = new PageAdID
            {
                Guid = this.hiddenFieldGuid.Value,
                PageName = this.TextBoxPageName.Text,
                FileName = this.DropDownListFileName.SelectedValue,
                Content = this.TextBoxContent.Text.Trim(),
                Height = this.TextBoxHeight.Text.Trim(),
                Width = this.TextBoxWidth.Text.Trim()
            };
            if (this.shopNum1_PageAdID_Action_0.Update(pageAdID) > 0)
            {
                base.Response.Redirect("PageAdID_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        public void GetEditInfo()
        {
            ShopNum1_PageAdID_Action action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
            DataRow row = action.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
            this.TextBoxPageName.Text = row["pagename"].ToString();
            this.DropDownListFileName.SelectedValue = row["filename"].ToString();
            this.TextBoxAdID.Text = row["divid"].ToString();
            this.TextBoxHeight.Text = row["height"].ToString();
            this.TextBoxWidth.Text = row["width"].ToString();
            this.TextBoxContent.Text = row["content"].ToString();
        }

        public void GetFileName()
        {
            string[] files = Directory.GetFiles(base.Server.MapPath("~/Main/Themes/Skin_Default/"), "*.aspx");
            this.DropDownListFileName.Items.Clear();
            ListItem item = new ListItem
            {
                Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                Value = "-1"
            };
            this.DropDownListFileName.Items.Add(item);
            for (int i = 0; i < files.Length; i++)
            {
                ListItem item2 = new ListItem
                {
                    Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
                    Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
                };
                this.DropDownListFileName.Items.Add(item2);
            }
        }

    }
}