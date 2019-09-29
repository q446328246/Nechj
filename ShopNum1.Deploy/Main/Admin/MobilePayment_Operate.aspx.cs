using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MobilePayment_Operate : PageBase, IRequiresSessionState
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                             ? "0"
                                             : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                this.RadioButtonListForredepositrecharge.RepeatLayout = RepeatLayout.Flow;
                this.RadioButtonListForredepositrecharge.RepeatDirection = RepeatDirection.Horizontal;
                BindData();
                this.RadioButtonListForredepositrecharge.SelectedValue = "1";
                method_8();
                GetOrderID();
                this.DropDownListPaymentType.SelectedValue = "-1";
                if (this.DropDownListPaymentType.SelectedValue != "-1")
                {
                    this.TextBoxName.Text = this.DropDownListPaymentType.SelectedValue;
                }
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelPageTitle.Text = "编辑支付方式";
                    method_7();
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ShopNum1_Payment payment;
                ShopNum1_Payment_Action action;
                ShopNum1_OperateLog log;
                if (this.ButtonConfirm.ToolTip == "Submit")
                {
                    payment = new ShopNum1_Payment
                        {
                            Guid = Guid.NewGuid(),
                            PaymentType = this.DropDownListPaymentType.SelectedValue,
                            Name = this.TextBoxName.Text.Trim(),
                            MerchantCode = this.TextBoxMerchantCode.Text.Trim(),
                            SecretKey = this.TextBoxSecretKey.Text.Trim(),
                            SecondKey = this.TextBoxSecretKey.Text.Trim(),
                            Pwd = this.TextBoxSecretKey.Text.Trim(),
                            Partner = "1",
                            Charge = Convert.ToDecimal(this.TextBoxCharge.Text.Trim()),
                            Email = this.TextBoxEmail.Text.Trim()
                        };
                    if (this.CheckBoxIsPercent.Checked)
                    {
                        payment.IsPercent = 1;
                    }
                    else
                    {
                        payment.IsPercent = 0;
                    }
                    payment.Memo = this.TextBoxMemo.Text.Trim();
                    payment.IsCOD = 0;
                    payment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
                    payment.CreateUser = base.ShopNum1LoginID;
                    payment.CreateTime = DateTime.Now;
                    payment.ModifyUser = base.ShopNum1LoginID;
                    payment.ModifyTime = DateTime.Now;
                    payment.ForAdvancePayment = Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue);
                    payment.IsDeleted = 0;
                    action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
                    if (action.AddMobile(payment) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "新增" + this.TextBoxName.Text.Trim() + "成功!",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "MobilePayment_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        this.MessageShow.ShowMessage("AddYes");
                        this.MessageShow.Visible = true;
                        method_6();
                    }
                    else
                    {
                        this.MessageShow.ShowMessage("AddNo");
                        this.MessageShow.Visible = true;
                    }
                }
                else if (this.ButtonConfirm.ToolTip == "Update")
                {
                    payment = new ShopNum1_Payment
                        {
                            Guid = new Guid(this.hiddenFieldGuid.Value.ToString().Replace("'", "")),
                            PaymentType = this.DropDownListPaymentType.SelectedValue,
                            Name = this.TextBoxName.Text.Trim(),
                            MerchantCode = this.TextBoxMerchantCode.Text.Trim(),
                            SecretKey = this.TextBoxSecretKey.Text.Trim(),
                            SecondKey = TextBoxSecretKey.Text.Trim(),
                            Pwd = TextBoxSecretKey.Text.Trim(),
                            Partner = "1",
                            Charge = Convert.ToDecimal(this.TextBoxCharge.Text.Trim()),
                            Email = this.TextBoxEmail.Text.Trim(),
                            Memo = this.TextBoxMemo.Text.Trim()
                        };
                    if (this.CheckBoxIsPercent.Checked)
                    {
                        payment.IsPercent = 1;
                    }
                    else
                    {
                        payment.IsPercent = 0;
                    }
                    payment.IsCOD = 0;
                    payment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
                    payment.ModifyUser = base.ShopNum1LoginID;
                    payment.ModifyTime = DateTime.Now;
                    payment.ForAdvancePayment = Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue);
                    action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
                    if (action.UpdateMobile(payment, this.hiddenFieldGuid.Value, 0) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "编辑" + this.TextBoxName.Text.Trim() + "成功!",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "MobilePayment_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        this.MessageShow.ShowMessage("EditYes");
                        this.MessageShow.Visible = true;
                    }
                    else
                    {
                        this.MessageShow.ShowMessage("EditNo");
                        this.MessageShow.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("所有带*的编辑框必须填写完整！");
            }
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_Payment";
            this.TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void BindData()
        {
            this.RadioButtonListForredepositrecharge.Items.Clear();
            var item = new ListItem
                {
                    Text = "是",
                    Value = "1"
                };
            this.RadioButtonListForredepositrecharge.Items.Add(item);
            item = new ListItem
                {
                    Text = "否",
                    Value = "0"
                };
            this.RadioButtonListForredepositrecharge.Items.Add(item);
        }

        private void method_6()
        {
            this.TextBoxOrderID.Text = string.Empty;
            this.TextBoxEmail.Text = string.Empty;
            this.TextBoxCharge.Text = string.Empty;
            this.TextBoxMemo.Text = string.Empty;
            this.TextBoxMerchantCode.Text = string.Empty;
            this.TextBoxSecretKey.Text = string.Empty;
            this.TextBoxName.Text = string.Empty;
            this.TextBoxOrderID.Text = string.Empty;
            this.CheckBoxIsPercent.Checked = false;
        }

        private void method_7()
        {
            DataTable table = new ShopNum1_Payment_Action().SearchPayInfoMobile(this.hiddenFieldGuid.Value.ToString(), 0);
            this.TextBoxName.Text = table.Rows[0]["Name"].ToString();
            this.TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
            this.DropDownListPaymentType.SelectedValue = table.Rows[0]["PaymentType"].ToString();
            this.TextBoxEmail.Text = table.Rows[0]["Email"].ToString();
            this.TextBoxCharge.Text = table.Rows[0]["Charge"].ToString();
            this.TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            this.TextBoxMerchantCode.Text = table.Rows[0]["MerchantCode"].ToString();
            this.TextBoxSecretKey.Text = table.Rows[0]["SecretKey"].ToString();
            this.RadioButtonListForredepositrecharge.SelectedValue = table.Rows[0]["ForAdvancePayment"].ToString();
            if (table.Rows[0]["IsPercent"].ToString() == "0")
            {
                this.CheckBoxIsPercent.Checked = false;
            }
            else
            {
                this.CheckBoxIsPercent.Checked = true;
            }
            this.ButtonConfirm.ToolTip = "Update";
            this.ButtonConfirm.Text = "更新";
        }

        private void method_8()
        {
        }

       
    }
}