using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AttachMent_Operate : PageBase, IRequiresSessionState
    {
        protected void AssociatedCategoryGuidBind()
        {
            DataTable table =
                ((ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action()).Search();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListDropDownListAssociatedCategoryGuid.Items.Add(
                    new ListItem(table.Rows[i]["CategoryName"].ToString(), table.Rows[i]["Guid"].ToString()));
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (!FileUploadAttachmentURL.HasFile)
            {
                MessageBox.Show("请选择要上传的文件！");
            }
            else
            {
                string str;
                if (!Directory.Exists(Page.Server.MapPath("/ImgUpload/attachfile/")))
                {
                    Directory.CreateDirectory(Page.Server.MapPath("/ImgUpload/attachfile/"));
                }
                if (ShopNum1UpLoad.FileUpLoad(FileUploadAttachmentURL, "/ImgUpload/attachfile/", out str))
                {
                    var ment = new ShopNum1_AttachMent
                        {
                            Guid = Guid.NewGuid(),
                            Title = TextBoxTitle.Text,
                            AttachmentURL = str,
                            Description = TextBoxDescription.Text,
                            AssociatedCategoryGuid =
                                new Guid(DropDownListDropDownListAssociatedCategoryGuid.SelectedValue)
                        };
                    var action = (ShopNum1_AttachMent_Action) LogicFactory.CreateShopNum1_AttachMent_Action();
                    if (action.Insert(ment) > 0)
                    {
                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "新增" + TextBoxTitle.Text.Trim() + "成功",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "AttachMent_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(operateLog);
                        MessageShow.ShowMessage("AddYes");
                        MessageShow.Visible = true;
                        base.Response.Redirect("AttachMent_list.aspx");
                    }
                    else
                    {
                        MessageShow.ShowMessage("AddNo");
                        MessageShow.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show(str);
                }
            }
        }

        protected bool FileUpload(FileUpload fileUpload_0, string filepath, out string retstr)
        {
            var random = new Random();
            string fileName = fileUpload_0.PostedFile.FileName;
            string str2 = HttpContext.Current.Server.MapPath(filepath);
            string str3 = fileName.Substring(fileName.LastIndexOf(".") + 1);
            string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100, 0x3e7).ToString() + "." + str3;
            if (!File.Exists(str2 + str5))
            {
                fileUpload_0.PostedFile.SaveAs(str2 + str5);
                retstr = filepath + str5;
                return true;
            }
            retstr = "文件已存在！";
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                AssociatedCategoryGuidBind();
            }
        }
    }
}