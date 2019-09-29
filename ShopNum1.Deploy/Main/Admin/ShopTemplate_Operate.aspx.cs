using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopTemplate_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string str;
            string str2;
            ShopNum1_OperateLog log;
            if (this.CheckGuid.Value == "0")
            {
                if (CheckTemplateName(Operator.FilterString(this.TextBoxName.Text)))
                {
                    str = "ShopSkin" + DateTime.Now.ToString("yyyyMMddhhmmss");
                    string str3 = method_6(str);
                    if (!(str3 == "0"))
                    {
                        str2 = str;
                        string str4 = method_7(str2, "");
                        if (str4 != "0")
                        {
                            log = new ShopNum1_OperateLog
                                {
                                    Record = "管理员新增模板",
                                    OperatorID = base.ShopNum1LoginID,
                                    IP = Globals.IPAddress,
                                    PageName = "ShopTemplate_Operate.aspx",
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                };
                            base.OperateLog(log);
                            method_9(str3, str4);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("模板名重复！");
                }
            }
            else
            {
                str = ViewState["shopTemName"].ToString();
                str2 = ViewState["shopTemImg"].ToString();
                if (this.FileUploadShopTemplate.HasFile)
                {
                    method_6(str.Split(new[] {'.'})[0]);
                }
                if (this.FileUploadTemplateImg.HasFile)
                {
                    str2 = method_7(str2.Split(new[] {'.'})[0], str2);
                }
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改模板",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopTemplate_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_8(str2);
            }
        }

        public bool CheckTemplateName(string name)
        {
            var action = (ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action();
            return (action.CheckTemplateName(name) == 0);
        }

        private void method_10()
        {
            this.TextBoxName.Text = string.Empty;
            this.TextBoxMeto.Text = string.Empty;
        }

        private void BindData()
        {
            DataTable table =
                ((ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action()).Edit(
                    this.CheckGuid.Value);
            this.TextBoxName.Text = table.Rows[0]["name"].ToString();
            this.TextBoxMeto.Text = table.Rows[0]["Meto"].ToString();
            this.ImageTemplate.ImageUrl = Page.ResolveUrl("/Template/ShopTemplate/" + table.Rows[0]["TemplateImg"]);
            this.ImageLink.HRef = Page.ResolveUrl("/Template/ShopTemplate/" + table.Rows[0]["TemplateImg"]);
            ViewState["shopTemName"] = table.Rows[0]["Path"].ToString();
            ViewState["shopTemImg"] = table.Rows[0]["TemplateImg"].ToString();
            ViewState["TextBoxName"] = table.Rows[0]["name"].ToString();
        }

        private string method_6(string string_4)
        {
            if (this.FileUploadShopTemplate.HasFile)
            {
                new FileInfo(this.FileUploadShopTemplate.PostedFile.FileName);
                string str2 = "~/Template/ShopTemplate/";
                switch (this.FileUploadShopTemplate.PostedFile.ContentType)
                {
                    case "application/x-zip-compressed":
                    case "application/zip":
                    case "application/octet-stream":
                        try
                        {
                            if (File.Exists(Page.Server.MapPath(str2 + string_4 + ".zipzz")))
                            {
                                File.Delete(Page.Server.MapPath(str2 + string_4 + ".zipzz"));
                            }
                            this.FileUploadShopTemplate.PostedFile.SaveAs(base.Server.MapPath(str2 + string_4 + ".zipzz"));
                            return (string_4 + ".zipzz");
                        }
                        catch
                        {
                            MessageBox.Show("上传出错啦！");
                            return "0";
                        }
                }
                MessageBox.Show("文件格式不正确！");
                return "0";
            }
            MessageBox.Show("请上传模板！");
            return "0";
        }

        private string method_7(string string_4, string string_5)
        {
            if (this.FileUploadTemplateImg.HasFile)
            {
                var info = new FileInfo(this.FileUploadTemplateImg.PostedFile.FileName);
                string str2 = "/Template/ShopTemplate/";
                if ((string_5 != "") && File.Exists(base.Server.MapPath(str2 + string_5)))
                {
                    File.Delete(base.Server.MapPath(str2 + string_5));
                }
                string_4 = string_4 + info.Extension;
                string contentType = this.FileUploadTemplateImg.PostedFile.ContentType;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageType(this.FileUploadTemplateImg, out retstr))
                {
                    try
                    {
                        if (Directory.Exists(base.Server.MapPath(str2 + string_4)))
                        {
                            MessageBox.Show("此图片已存在！");
                            return "0";
                        }
                        this.FileUploadTemplateImg.PostedFile.SaveAs(base.Server.MapPath(str2 + string_4));
                        return string_4;
                    }
                    catch
                    {
                        MessageBox.Show("上传出错啦！");
                        return "0";
                    }
                }
                MessageBox.Show(retstr);
                return "0";
            }
            MessageBox.Show("请上传图片！");
            return "0";
        }

        private void method_8(string string_4)
        {
            if ((this.TextBoxName.Text != ViewState["TextBoxName"].ToString()) &&
                !CheckTemplateName(Operator.FilterString(this.TextBoxName.Text)))
            {
                MessageBox.Show("模板名重复！");
            }
            else
            {
                var template = new ShopNum1_Shop_Template
                    {
                        Name = this.TextBoxName.Text,
                        Money = 0,
                        Meto = this.TextBoxMeto.Text,
                        ValidDay = 0x3e8,
                        ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        ModifyUser = "admin",
                        TemplateImg = string_4,
                        IsForbid = 0,
                        IsDefault = 1,
                        ID = int.Parse(this.CheckGuid.Value.Replace("'", "").ToString())
                    };
                var action = (ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action();
                if (action.Updata(template) > 0)
                {
                    base.Response.Redirect("ShopTemplate_List.aspx");
                }
                else
                {
                    this.MessageShow.ShowMessage("EditNo");
                    this.MessageShow.Visible = true;
                }
            }
        }

        private void method_9(string string_4, string string_5)
        {
            var template = new ShopNum1_Shop_Template
                {
                    Name = this.TextBoxName.Text,
                    Money = 0,
                    Meto = this.TextBoxMeto.Text,
                    ValidDay = 0x3e8,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    CreateUser = "admin",
                    Path = string_4,
                    IsForbid = 0,
                    TemplateImg = string_5,
                    IsDefault = 1
                };
            var action = (ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action();
            if (action.Add(template) > 0)
            {
                method_10();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.CheckGuid.Value = (Page.Request.QueryString["guid"] == "0")
                                           ? "0"
                                           : base.Request.QueryString["guid"];
                if (this.CheckGuid.Value != "0")
                {
                    this.LabelPageTitle.Text = "修改店铺模板";
                    BindData();
                    this.ButtonConfirm.Text = "更新";
                }
            }
        }
    }
}