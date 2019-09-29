using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_DeployPayment : BaseShopWebControl
    {
        private Button button_0;
        private CheckBox checkBox_0;
        private HiddenField hiddenField_0;
        private HtmlTableRow htmlTableRow_0;
        private HtmlTableRow htmlTableRow_1;
        private HtmlTableRow htmlTableRow_2;
        private Label label_0;
        private Label label_1;
        private Label label_2;
        private string skinFilename = "S_DeployPayment.ascx";
        private TextBox textBox_0;
        private TextBox textBox_1;
        private TextBox textBox_2;
        private TextBox textBox_3;
        private TextBox textBox_4;
        private TextBox textBox_5;
        private TextBox textBox_6;

        public S_DeployPayment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hiddenField_0 = (HiddenField) skin.FindControl("HiddenFieldType");
            textBox_0 = (TextBox) skin.FindControl("TextBoxName");
            textBox_1 = (TextBox) skin.FindControl("TextBoxAlipay");
            textBox_2 = (TextBox) skin.FindControl("TextBoxMerchantCode");
            textBox_3 = (TextBox) skin.FindControl("TextBoxSecretKey");
            textBox_4 = (TextBox) skin.FindControl("TextBoxCharge");
            checkBox_0 = (CheckBox) skin.FindControl("CheckBoxIsPercent");
            textBox_5 = (TextBox) skin.FindControl("TextBoxMemo");
            textBox_6 = (TextBox) skin.FindControl("TextBoxOrderID");
            button_0 = (Button) skin.FindControl("ButtonConfirm");
            button_0.Click += button_0_Click;
            label_0 = (Label) skin.FindControl("LabelAlipay");
            label_1 = (Label) skin.FindControl("LabelMerchantCode");
            label_2 = (Label) skin.FindControl("LabelSecretKey");
            htmlTableRow_0 = (HtmlTableRow) skin.FindControl("tr1");
            htmlTableRow_1 = (HtmlTableRow) skin.FindControl("tr2");
            htmlTableRow_2 = (HtmlTableRow) skin.FindControl("tr3");
            GetOrderID();
            HiddleControl();
            if (Page.Request.QueryString["type"] != null)
            {
                hiddenField_0.Value = Page.Request.QueryString["type"];
                GetPaymentData();
            }
            if (Page.Request.QueryString["run"] != null)
            {
                if (Page.Request.QueryString["run"] == "edit")
                {
                    GetAllPaymentData();
                    button_0.Text = "编辑";
                }
                else
                {
                    if (Page.Request.QueryString["run"] == "add")
                    {
                        button_0.Text = "添加";
                    }
                }
            }
        }

        public void GetAllPaymentData()
        {
            var shopNum1_ShopPayment_Action =
                (ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action();
            DataTable dataInfo = shopNum1_ShopPayment_Action.GetDataInfo(Page.Request.QueryString["type"], MemLoginID);
            if (dataInfo != null && dataInfo.Rows.Count > 0)
            {
                textBox_0.Text = dataInfo.Rows[0]["Name"].ToString();
                textBox_1.Text = dataInfo.Rows[0]["Email"].ToString();
                textBox_2.Text = dataInfo.Rows[0]["MerchantCode"].ToString();
                textBox_3.Text = dataInfo.Rows[0]["SecretKey"].ToString();
                textBox_4.Text = dataInfo.Rows[0]["Charge"].ToString();
                if (dataInfo.Rows[0]["IsPercent"].ToString() == "0")
                {
                    checkBox_0.Checked = false;
                }
                else
                {
                    checkBox_0.Checked = true;
                }
                textBox_5.Text = dataInfo.Rows[0]["Memo"].ToString();
                textBox_6.Text = dataInfo.Rows[0]["OrderID"].ToString();
            }
        }

        protected void button_0_Click(object sender, EventArgs e)
        {
            double num = 0.0;
            if (!double.TryParse(textBox_4.Text.Trim(), out num))
            {
                MessageBox.Show("手续费格式错误！");
            }
            else
            {
                if (Page.Request.QueryString["run"] != null)
                {
                    if (Page.Request.QueryString["run"] == "add")
                    {
                        Add();
                    }
                    else
                    {
                        if (Page.Request.QueryString["run"] == "edit")
                        {
                            Edit();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("操作错误！");
                }
            }
        }

        public void Edit()
        {
            var shopNum1_ShopPayment_Action =
                (ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action();
            DataTable dataInfo = shopNum1_ShopPayment_Action.GetDataInfo(Page.Request.QueryString["type"], MemLoginID);
            Guid guid = Guid.NewGuid();
            if (dataInfo != null && dataInfo.Rows.Count > 0)
            {
                guid = new Guid(dataInfo.Rows[0]["Guid"].ToString());
            }
            var shopNum1_ShopPayment = new ShopNum1_ShopPayment();
            shopNum1_ShopPayment.Guid = guid;
            shopNum1_ShopPayment.PaymentType = Page.Request.QueryString["type"].Replace("'", "");
            shopNum1_ShopPayment.Name = textBox_0.Text.Trim();
            shopNum1_ShopPayment.MerchantCode = textBox_2.Text.Trim();
            shopNum1_ShopPayment.SecretKey = textBox_3.Text.Trim();
            shopNum1_ShopPayment.SecondKey = shopNum1_ShopPayment.SecretKey;
            shopNum1_ShopPayment.Pwd = shopNum1_ShopPayment.SecretKey;
            shopNum1_ShopPayment.Partner = "1";
            if (textBox_4.Text.Trim() == string.Empty)
            {
                shopNum1_ShopPayment.Charge = 0m;
            }
            else
            {
                shopNum1_ShopPayment.Charge = Convert.ToDecimal(textBox_4.Text.Trim());
            }
            shopNum1_ShopPayment.Email = textBox_1.Text.Trim();
            shopNum1_ShopPayment.Memo = textBox_5.Text.Trim();
            if (checkBox_0.Checked)
            {
                shopNum1_ShopPayment.IsPercent = 1;
            }
            else
            {
                shopNum1_ShopPayment.IsPercent = 0;
            }
            shopNum1_ShopPayment.IsCOD = 0;
            shopNum1_ShopPayment.OrderID = Convert.ToInt32(textBox_6.Text.Trim());
            int num = shopNum1_ShopPayment_Action.Update(shopNum1_ShopPayment, guid.ToString(), 0);
            if (num > 0)
            {
                Page.Response.Redirect("S_ShowPaymentType.aspx");
            }
            else
            {
                MessageBox.Show("编辑失败！");
            }
        }

        protected void GetOrderID()
        {
            var arg_0A_0 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            string columnName = "OrderID";
            string tableName = "ShopNum1_ShopPayment";
            textBox_6.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
        }

        public void Add()
        {
            var shopNum1_ShopPayment = new ShopNum1_ShopPayment();
            shopNum1_ShopPayment.Guid = Guid.NewGuid();
            shopNum1_ShopPayment.PaymentType = Page.Request.QueryString["type"];
            shopNum1_ShopPayment.Name = textBox_0.Text.Trim();
            shopNum1_ShopPayment.MerchantCode = textBox_2.Text.Trim();
            shopNum1_ShopPayment.SecretKey = textBox_3.Text.Trim();
            shopNum1_ShopPayment.SecondKey = shopNum1_ShopPayment.SecretKey;
            shopNum1_ShopPayment.Pwd = shopNum1_ShopPayment.SecretKey;
            shopNum1_ShopPayment.Partner = "1";
            if (textBox_4.Text.Trim() == string.Empty)
            {
                shopNum1_ShopPayment.Charge = 0m;
            }
            else
            {
                shopNum1_ShopPayment.Charge = Convert.ToDecimal(textBox_4.Text.Trim());
            }
            shopNum1_ShopPayment.Email = textBox_1.Text.Trim();
            shopNum1_ShopPayment.memloginID = MemLoginID;
            if (checkBox_0.Checked)
            {
                shopNum1_ShopPayment.IsPercent = 1;
            }
            else
            {
                shopNum1_ShopPayment.IsPercent = 0;
            }
            shopNum1_ShopPayment.Memo = textBox_5.Text.Trim();
            shopNum1_ShopPayment.IsCOD = 0;
            shopNum1_ShopPayment.OrderID = Convert.ToInt32(textBox_6.Text.Trim());
            shopNum1_ShopPayment.IsDeleted = 0;
            var shopNum1_ShopPayment_Action =
                (ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action();
            int num = shopNum1_ShopPayment_Action.Add(shopNum1_ShopPayment);
            if (num > 0)
            {
                Page.Response.Redirect("S_ShowPaymentType.aspx");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

        public void GetPaymentData()
        {
            var shopNum1_Payment_Action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            DataTable dataTable = shopNum1_Payment_Action.PaymentTypeName(Page.Request.QueryString["type"]);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                textBox_0.Text = dataTable.Rows[0]["Name"].ToString();
            }
        }

        public void HiddleControl()
        {
            string text = Page.Request.QueryString["type"];
            string text2 = text;
            switch (text2)
            {
                case "BankTransfer.aspx":
                    htmlTableRow_0.Visible = false;
                    htmlTableRow_1.Visible = false;
                    htmlTableRow_2.Visible = false;
                    break;
                case "Alipay2.aspx":
                    label_1.Text = "合作者身份(PID)：";
                    label_2.Text = "安全校验码(Key)：";
                    break;
                case "Alipay3.aspx":
                    label_1.Text = "合作者身份(PID)：";
                    label_2.Text = "安全校验码(Key)：";
                    break;
                case "Alipay.aspx":
                    label_1.Text = "合作者身份(PID)：";
                    label_2.Text = "安全校验码(Key)：";
                    break;
                case "DeliveryPay.aspx":
                    htmlTableRow_0.Visible = false;
                    htmlTableRow_1.Visible = false;
                    htmlTableRow_2.Visible = false;
                    break;
                case "Tenpay.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "TenpayMed.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "YeepaySZX.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "Yeepay.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "Allbuy.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "PreDeposits.aspx":
                    htmlTableRow_0.Visible = false;
                    htmlTableRow_1.Visible = false;
                    htmlTableRow_2.Visible = false;
                    break;
                case "PayPal.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "Send.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "NetPayClient.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
                case "IcardPay.aspx":
                    htmlTableRow_0.Visible = false;
                    break;
            }
        }
    }
}