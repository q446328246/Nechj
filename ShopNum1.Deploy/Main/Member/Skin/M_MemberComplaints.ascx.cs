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
    public partial class M_MemberComplaints : BaseMemberControl
    {
        protected void ButtonSubmit_Click(object sender, EventArgs e)
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

        protected void ButtonBackList_Click(object sender, EventArgs e)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
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