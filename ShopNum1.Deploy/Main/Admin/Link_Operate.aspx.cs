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
    public partial class Link_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var link = new ShopNum1_Link
                {
                    Guid = Guid.NewGuid(),
                    Href = textBoxLinkAddress.Text.Trim()
                };
            if (Convert.ToInt32(DropListLinkType.SelectedValue) == 1)
            {
                link.ImgADD = textBoxImgAddress.Text.Trim();
                link.ImgType = radioButtonImgType.SelectedValue;
            }
            else
            {
                link.ImgADD = string.Empty;
                link.ImgType = string.Empty;
            }
            link.Description = textBoxDescription.Text.Trim();
            link.Memo = textBoxMemo.Text.Trim();
            link.Name = textBoxTitle.Text.Trim();
            link.LinkType = Convert.ToInt32(DropListLinkType.SelectedValue);
            link.CreateUser = "Admin";
            link.ModifyUser = "Admin";
            link.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.IsDeleted = 0;
            link.OrderID = Convert.ToInt32(textBoxOrderID.Text.Trim());
            if (CheckBoxIsShow.Checked)
            {
                link.IsShow = 1;
            }
            else
            {
                link.IsShow = 0;
            }
            var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
            if (action.Add(link) > 0)
            {
                GetOrderID();
                ClearControl();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = "图片链接",
                    Value = "1"
                };
            DropListLinkType.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "文字链接",
                    Value = "0"
                };
            DropListLinkType.Items.Add(item2);
            DropListLinkType.SelectedValue = "1";
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + textBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Link_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "新增" + textBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Link_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ClearControl()
        {
            DropListLinkType.SelectedValue = "0";
            textBoxTitle.Text = string.Empty;
            textBoxImgAddress.Text = string.Empty;
            textBoxLinkAddress.Text = string.Empty;
            textBoxMemo.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
        }

        protected void DropListLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DropListLinkType.SelectedValue) == 0)
            {
                PanelPic.Visible = false;
            }
            else
            {
                PanelPic.Visible = true;
            }
        }

        protected void Edit()
        {
            var link = new ShopNum1_Link
                {
                    Guid = Guid.NewGuid(),
                    Href = textBoxLinkAddress.Text.Trim(),
                    ImgADD = textBoxImgAddress.Text.Trim(),
                    Description = textBoxDescription.Text.Trim()
                };
            if (Convert.ToInt32(DropListLinkType.SelectedValue) == 1)
            {
                link.ImgADD = textBoxImgAddress.Text.Trim();
                link.ImgType = radioButtonImgType.SelectedValue;
            }
            else
            {
                link.ImgADD = string.Empty;
                link.ImgType = string.Empty;
            }
            link.Memo = textBoxMemo.Text.Trim();
            link.Name = textBoxTitle.Text.Trim();
            link.LinkType = Convert.ToInt32(DropListLinkType.SelectedValue);
            link.ImgType = radioButtonImgType.SelectedValue;
            link.OrderID = Convert.ToInt32(textBoxOrderID.Text.Trim());
            link.CreateUser = "Admin";
            link.ModifyUser = "Admin";
            link.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.IsDeleted = 0;
            if (CheckBoxIsShow.Checked)
            {
                link.IsShow = 1;
            }
            else
            {
                link.IsShow = 0;
            }
            var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
            if (action.Update(hiddenFieldGuid.Value, link) > 0)
            {
                base.Response.Redirect("Link_Manage.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action()).GetEditInfo(hiddenFieldGuid.Value);
            textBoxTitle.Text = editInfo.Rows[0]["Name"].ToString();
            DropListLinkType.SelectedValue = editInfo.Rows[0]["LinkType"].ToString();
            if (DropListLinkType.SelectedValue == "0")
            {
                PanelPic.Visible = false;
            }
            textBoxLinkAddress.Text = editInfo.Rows[0]["Href"].ToString();
            radioButtonImgType.SelectedValue = editInfo.Rows[0]["ImgType"].ToString();
            textBoxImgAddress.Text = editInfo.Rows[0]["ImgADD"].ToString();
            textBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            textBoxMemo.Text = editInfo.Rows[0]["Memo"].ToString();
            textBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            ImageOriginalImge.Src = editInfo.Rows[0]["ImgADD"].ToString();
            BottonConfirm.Text = "更新";
            if (editInfo.Rows[0]["IsShow"].ToString() == "1")
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_Link";
            textBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                BindStatus();
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑友情链接";
                    GetEditInfo();
                }
            }
        }

        protected void radioButtonIMGTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonImgType.SelectedIndex == 0)
            {
                lblImgAddress.Text = "本地上传";
                Panelimage.Visible = true;
            }
            if (radioButtonImgType.SelectedIndex == 1)
            {
                lblImgAddress.Text = "远程链接";
                Panelimage.Visible = false;
            }
        }
    }
}