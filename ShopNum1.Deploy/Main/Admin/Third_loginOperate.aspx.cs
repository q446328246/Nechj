using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.Second;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Third_loginOperate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 =
            new ShopNum1_SecondTypeBussiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑第三方账户";
                    method_6();
                    ButtonConfirm.ToolTip = "Update";
                }
                else
                {
                    ButtonConfirm.ToolTip = "Submit";
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_SecondType type;
            string str;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                type = new ShopNum1_SecondType
                    {
                        TypeName = TextBoxName.Text.Trim(),
                        AppID = TextBoxAppID.Text.Trim(),
                        AppSecret = TextBoxSecretKey.Text.Trim()
                    };
                if (RadioButtonListAvailable.SelectedValue == "1")
                {
                    type.isAvabile = 1;
                }
                else
                {
                    type.isAvabile = 0;
                }
                type.content = TextBoxMemo.Text.Trim();
                type.redirectURL = TextBoxRedirectURL.Text.Trim();
                type.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                if (FileUploadImgSrc.HasFile)
                {
                    str = string.Empty;
                    if (!ShopNum1UpLoad.ImageUpLoad(FileUploadImgSrc, "~/ImgUpload/", out str, false))
                    {
                        MessageBox.Show(str);
                        return;
                    }
                    type.ImgSrc = str;
                }
                if (shopNum1_SecondTypeBussiness_0.Add(type))
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "新增" + TextBoxName.Text.Trim() + "成功!",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Third_loginOperate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                    method_5();
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                type = new ShopNum1_SecondType
                    {
                        ID = int.Parse(hiddenFieldGuid.Value.Trim()),
                        TypeName = TextBoxName.Text.Trim(),
                        AppID = TextBoxAppID.Text.Trim(),
                        AppSecret = TextBoxSecretKey.Text.Trim()
                    };
                if (RadioButtonListAvailable.SelectedValue == "1")
                {
                    type.isAvabile = 1;
                }
                else
                {
                    type.isAvabile = 0;
                }
                type.content = TextBoxMemo.Text.Trim();
                type.redirectURL = TextBoxRedirectURL.Text.Trim();
                type.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                type.ImgSrc = ImageSrc.ImageUrl;
                if (FileUploadImgSrc.HasFile)
                {
                    str = string.Empty;
                    if (!ShopNum1UpLoad.ImageUpLoad(FileUploadImgSrc, "~/ImgUpload/", out str, false))
                    {
                        MessageBox.Show(str);
                        return;
                    }
                    type.ImgSrc = str;
                    if (File.Exists(Page.Server.MapPath(ImageSrc.ImageUrl)))
                    {
                        File.Delete(Page.Server.MapPath(ImageSrc.ImageUrl));
                    }
                }
                if (shopNum1_SecondTypeBussiness_0.Update(type))
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "编辑" + TextBoxName.Text.Trim() + "成功!",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Third_loginOperate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("EditYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("EditNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void GetOrderID()
        {
            TextBoxOrderID.Text = shopNum1_SecondTypeBussiness_0.GetMaxOrderId().ToString();
        }

        private void method_5()
        {
            TextBoxName.Text = "";
        }

        private void method_6()
        {
            trID.Visible = true;
            DataTable model = shopNum1_SecondTypeBussiness_0.GetModel(int.Parse(hiddenFieldGuid.Value.Trim()));
            TextBoxName.Text = model.Rows[0]["TypeName"].ToString();
            TextBoxOrderID.Text = model.Rows[0]["OrderID"].ToString();
            TextBoxAppID.Text = model.Rows[0]["AppID"].ToString();
            TextBoxSecretKey.Text = model.Rows[0]["AppSecret"].ToString();
            TextBoxMemo.Text = model.Rows[0]["content"].ToString();
            TextBoxRedirectURL.Text = model.Rows[0]["redirectURL"].ToString();
            TextBoxID.Text = model.Rows[0]["ID"].ToString();
            RadioButtonListAvailable.SelectedValue = model.Rows[0]["isAvabile"].ToString();
            ImageSrc.ImageUrl = model.Rows[0]["ImgSrc"].ToString();
            ButtonConfirm.ToolTip = "Update";
            ButtonConfirm.Text = "更新";
        }

        private void method_7()
        {
        }
    }
}