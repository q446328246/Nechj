using System;
using System.IO;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberReport : BaseMemberControl
    {
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxID.Text.Trim()))
            {
                MessageBox.Show("举报商家的ID号不能为空！");
            }
            else if (string.IsNullOrEmpty(TextBoxProductUrl.Text.Trim()))
            {
                MessageBox.Show("商品链接不能为空！");
            }
            else if (DropDownListType.SelectedValue == "-1")
            {
                MessageBox.Show("举报类型必选！");
            }
            else if (string.IsNullOrEmpty(TextBoxEvidence.Text.Trim()))
            {
                MessageBox.Show("证据不能为空！");
            }
            else
            {
                var action = (ShopNum1_MemberReport_Action) LogicFactory.CreateShopNum1_MemberReport_Action();
                var memberReport = new ShopNum1_MemberReport
                {
                    ProductUrl = TextBoxProductUrl.Text.Trim(),
                    ReportType = DropDownListType.SelectedValue,
                    Evidence = TextBoxEvidence.Text.Trim(),
                    ReportTime = DateTime.Now,
                    MemLoginID = base.MemLoginID,
                    ReportShop = TextBoxID.Text.Trim()
                };
                string str = string.Empty;
                if (FileUploadImage.HasFile)
                {
                    string str2 = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
                    if ((!(str2 != "0") || !(str2 != "1")) || !(str2 != "2"))
                    {
                        return;
                    }
                    str = str2;
                }
                memberReport.EvidenceImage = str;
                try
                {
                    if (action.Add(memberReport) > 0)
                    {
                        TextBoxProductUrl.Text = "";
                        DropDownListType.SelectedValue = "-1";
                        TextBoxEvidence.Text = "";
                        TextBoxID.Text = "";
                        MessageBox.Show("添加成功！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("操作错误");
                }
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_MyReport.aspx");
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                string fileName = ControlName.PostedFile.FileName;
                string strExt = fileName.Substring(fileName.IndexOf('.'));
                var extArry = new[] {".png", ".gif", ".bmp", ".png", ".jpg"};
                if (ImageUpload.CheckImgTypex(extArry, strExt))
                {
                    var info = new FileInfo(fileName);
                    string str4 = "~/ImgUpload/ShopCertification";
                    string filepath = str4 + "/" + ImageName + info.Extension;
                    string retstr = string.Empty;
                    if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                    {
                        return filepath;
                    }
                    MessageBox.Show(retstr);
                    return "0";
                }
                MessageBox.Show("请上传png/jpg/pjpeg/x-png/jpeg类型图片！");
                return "2";
            }
            return "1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}