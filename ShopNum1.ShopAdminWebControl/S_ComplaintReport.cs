using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ComplaintReport : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private FileUpload FileUploadImage;
        private Repeater RepeaterShow;
        private TextBox TextBoxEvidence;
        private string skinFilename = "S_ComplaintReport.ascx";
        private HtmlTableRow trResult;

        public S_ComplaintReport()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEvidence.Text.Trim()))
            {
                MessageBox.Show("证据不能为空");
            }
            else
            {
                string complainimage = string.Empty;
                if (FileUploadImage.HasFile)
                {
                    string str = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
                    if ((str != "0") && (str != "1"))
                    {
                        complainimage = str;
                    }
                }
                var action = (ShopNum1_MemberReport_Action) LogicFactory.CreateShopNum1_MemberReport_Action();
                if (
                    action.UpdateComplainInfoByID(Page.Request.QueryString["id"], complainimage,
                        TextBoxEvidence.Text.Trim()) >
                    0)
                {
                    MessageBox.Show("申诉成功！");
                    GetReport(Page.Request.QueryString["id"]);
                }
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_MemberReport.aspx");
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/ShopCertification";
                string filepath = str2 + "/" + ImageName + info.Extension;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                {
                    return filepath;
                }
                MessageBox.Show(retstr);
                return "0";
            }
            return "1";
        }

        public void GetReport(string string_1)
        {
            DataTable reportDetailByID =
                ((ShopNum1_MemberReport_Action) LogicFactory.CreateShopNum1_MemberReport_Action()).GetReportDetailByID(
                    string_1);
            if ((reportDetailByID != null) && (reportDetailByID.Rows.Count > 0))
            {
                if (reportDetailByID.Rows[0]["IsComplaint"].ToString() == "1")
                {
                    ButtonSubmit.Visible = false;
                    TextBoxEvidence.Enabled = false;
                }
                if (reportDetailByID.Rows[0]["ProcessingStatus"].ToString() == "2")
                {
                    ButtonSubmit.Visible = false;
                    TextBoxEvidence.Enabled = false;
                    trResult.Visible = true;
                }
                RepeaterShow.DataSource = reportDetailByID.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            TextBoxEvidence = (TextBox) skin.FindControl("TextBoxEvidence");
            FileUploadImage = (FileUpload) skin.FindControl("FileUploadImage");
            trResult = (HtmlTableRow) skin.FindControl("trResult");
            if (Page.Request.QueryString["id"] != null)
            {
                GetReport(Page.Request.QueryString["id"]);
            }
        }
    }
}