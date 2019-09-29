using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PaymentType_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var paymentType = new ShopNum1_PaymentType();
            if (FileUploadImage.HasFile)
            {
                paymentType.BakcImg = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
            }
            else
            {
                paymentType.BakcImg = hiddenFieldImage.Value;
            }
            paymentType.Guid = new Guid(hiddenFieldGuid.Value);
            if (CheckBoxIsShopUse.Checked)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "更新支付类型成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "PaymentType_Operate.aspx",
                        Date = DateTime.Now
                    };
                base.OperateLog(operateLog);
                paymentType.IsShopUse = 1;
            }
            else
            {
                paymentType.IsShopUse = 0;
            }
            paymentType.Memo = TextBoxMemo.Text.Trim();
            paymentType.Name = TextBoxName.Text.Trim();
            paymentType.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
            paymentType.PaymentType = TextBoxPaymentType.Text.Trim();
            try
            {
                ((ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action()).UpDatePaymentType(paymentType);
                base.Response.Redirect("PaymentType_List.aspx");
            }
            catch (Exception)
            {
            }
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/";
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

        private void BindData()
        {
            DataTable table =
                ((ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action()).SearchTypeByGuid(
                    hiddenFieldGuid.Value);
            TextBoxName.Text = table.Rows[0]["Name"].ToString();
            TextBoxPaymentType.Text = table.Rows[0]["PaymentType"].ToString();
            ImageUrl.ImageUrl = table.Rows[0]["BakcImg"].ToString();
            hiddenFieldImage.Value = table.Rows[0]["BakcImg"].ToString();
            TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
            if (table.Rows[0]["IsShopUse"].ToString() == "1")
            {
                CheckBoxIsShopUse.Checked = true;
            }
            else
            {
                CheckBoxIsShopUse.Checked = false;
            }
            ButtonConfirm.ToolTip = "Update";
            ButtonConfirm.Text = "更新";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelPageTitle.Text = "编辑支付类型";
                BindData();
            }
        }
    }
}