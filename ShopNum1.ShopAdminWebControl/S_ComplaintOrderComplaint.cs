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
    public class S_ComplaintOrderComplaint : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private FileUpload FileUploadImage;
        private Repeater RepeaterShow;
        private TextBox TextBoxEvidence;
        private string skinFilename = "S_ComplaintOrderComplaint.ascx";
        private HtmlTableRow trResult;

        public S_ComplaintOrderComplaint()
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
                string appealimage = string.Empty;
                if (FileUploadImage.HasFile)
                {
                    string str = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
                    if ((str != "0") && (str != "1"))
                    {
                        appealimage = str;
                    }
                }
                var action =
                    (ShopNum1_OrderComplaintsReplyList_Action)
                        LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
                if (
                    action.UpdateOrderComplainInfoByID(Page.Request.QueryString["id"], appealimage,
                        TextBoxEvidence.Text.Trim()) > 0)
                {
                    MessageBox.Show("申诉成功！");
                    GetReport(Page.Request.QueryString["id"]);
                }
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_OrderComplaints.aspx");
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
            DataTable table =
                ((ShopNum1_OrderComplaintsReplyList_Action)
                    LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action()).SearchComplaint(string_1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (table.Rows[0]["IsAppeal"].ToString() == "1")
                {
                    ButtonSubmit.Visible = false;
                    TextBoxEvidence.Enabled = false;
                }
                if (table.Rows[0]["ProcessingStatus"].ToString() == "2")
                {
                    ButtonSubmit.Visible = false;
                    trResult.Visible = true;
                    TextBoxEvidence.Enabled = false;
                }
                RepeaterShow.DataSource = table.DefaultView;
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