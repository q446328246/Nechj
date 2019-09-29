using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_MemberComplaints : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private DropDownList DropDownListType;
        private FileUpload FileUploadImage;
        private TextBox TextBoxEvidence;
        private TextBox TextBoxID;
        private TextBox TextBoxOrderID;
        private string skinFilename = "M_MemberComplaints.ascx";

        public M_MemberComplaints()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxID.Text.Trim()))
            {
                MessageBox.Show("投诉商家的ID号不能为空！");
            }
            else if (string.IsNullOrEmpty(TextBoxOrderID.Text.Trim()))
            {
                MessageBox.Show("订单编号不能为空！");
            }
            else if (DropDownListType.SelectedValue == "-1")
            {
                MessageBox.Show("投诉类型必选！");
            }
            else if (string.IsNullOrEmpty(TextBoxEvidence.Text.Trim()))
            {
                MessageBox.Show("投诉证据不能为空！");
            }
            else
            {
                var action =
                    (ShopNum1_OrderComplaintsReplyList_Action)
                        LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
                var orderComplaint = new ShopNum1_OrderComplaint
                {
                    ComplaintShop = TextBoxID.Text.Trim(),
                    OrderID = TextBoxOrderID.Text.Trim(),
                    ComplaintType = DropDownListType.SelectedValue,
                    Evidence = TextBoxEvidence.Text.Trim(),
                    ComplaintTime = DateTime.Now,
                    MemLoginID = base.MemLoginID,
                    ProcessingStatus = 0
                };
                string str2 = string.Empty;
                if (FileUploadImage.HasFile)
                {
                    string str = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
                    if ((str != "0") && (str != "1"))
                    {
                        str2 = str;
                    }
                }
                orderComplaint.EvidenceImage = str2;
                try
                {
                    if (action.Add(orderComplaint) > 0)
                    {
                        TextBoxOrderID.Text = "";
                        DropDownListType.SelectedValue = "-1";
                        TextBoxEvidence.Text = "";
                        TextBoxID.Text = "";
                        Page.Response.Redirect("M_Complaints.aspx");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("操作错误");
                }
            }
        }

        private void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Complaints.aspx");
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

        protected override void InitializeSkin(Control skin)
        {
            TextBoxID = (TextBox) skin.FindControl("TextBoxID");
            TextBoxOrderID = (TextBox) skin.FindControl("TextBoxOrderID");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            TextBoxEvidence = (TextBox) skin.FindControl("TextBoxEvidence");
            FileUploadImage = (FileUpload) skin.FindControl("FileUploadImage");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            BindData();
        }

        private void BindData()
        {
            string str = Common.Common.ReqStr("shopid");
            if (str.IndexOf("|") != -1)
            {
                TextBoxOrderID.Text = str.Split(new[] {'|'})[1];
                TextBoxOrderID.Enabled = false;
                TextBoxID.Text = Common.Common.GetNameById("shopid", "shopnum1_orderinfo",
                    " and ordernumber='" + str.Split(new[] {'|'})[1] + "'");
            }
        }
    }
}