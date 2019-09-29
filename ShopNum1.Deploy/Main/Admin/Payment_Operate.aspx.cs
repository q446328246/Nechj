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
    public partial class Payment_Operate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                RadioButtonListForredepositrecharge.RepeatLayout = RepeatLayout.Flow;
                RadioButtonListForredepositrecharge.RepeatDirection = RepeatDirection.Horizontal;
                BindData();
                RadioButtonListForredepositrecharge.SelectedValue = "1";
                method_8();
                GetOrderID();
                DropDownListPaymentType.SelectedValue = "-1";
                if (DropDownListPaymentType.SelectedValue != "-1")
                {
                    TextBoxName.Text = DropDownListPaymentType.SelectedValue;
                }
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑支付方式";
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
                if (ButtonConfirm.ToolTip == "Submit")
                {
                    payment = new ShopNum1_Payment
                        {
                            Guid = Guid.NewGuid(),
                            PaymentType = DropDownListPaymentType.SelectedValue,
                            Name = TextBoxName.Text.Trim(),
                            MerchantCode = TextBoxMerchantCode.Text.Trim(),
                            SecretKey = TextBoxSecretKey.Text.Trim(),
                            SecondKey = TextBoxSecretKey.Text.Trim(),
                            Pwd = TextBoxSecretKey.Text.Trim(),
                            Partner = "1",
                            Charge = Convert.ToDecimal(TextBoxCharge.Text.Trim()),
                            Email = TextBoxEmail.Text.Trim()
                        };
                    if (CheckBoxIsPercent.Checked)
                    {
                        payment.IsPercent = 1;
                    }
                    else
                    {
                        payment.IsPercent = 0;
                    }
                    payment.Memo = TextBoxMemo.Text.Trim();
                    payment.IsCOD = 0;
                    payment.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                    payment.CreateUser = base.ShopNum1LoginID;
                    payment.CreateTime = DateTime.Now;
                    payment.ModifyUser = base.ShopNum1LoginID;
                    payment.ModifyTime = DateTime.Now;
                    payment.ForAdvancePayment = Convert.ToInt32(RadioButtonListForredepositrecharge.SelectedValue);
                    payment.IsDeleted = 0;
                    action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
                    if (action.Add(payment) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "新增" + TextBoxName.Text.Trim() + "成功!",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "Payment_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        MessageShow.ShowMessage("AddYes");
                        MessageShow.Visible = true;
                        method_6();
                    }
                    else
                    {
                        MessageShow.ShowMessage("AddNo");
                        MessageShow.Visible = true;
                    }
                }
                else if (ButtonConfirm.ToolTip == "Update")
                {
                    payment = new ShopNum1_Payment
                        {
                            Guid = new Guid(hiddenFieldGuid.Value.Replace("'", "")),
                            PaymentType = DropDownListPaymentType.SelectedValue,
                            Name = TextBoxName.Text.Trim(),
                            MerchantCode = TextBoxMerchantCode.Text.Trim(),
                            SecretKey = TextBoxSecretKey.Text.Trim(),
                            SecondKey = TextBoxSecretKey.Text.Trim(),
                            Pwd = TextBoxSecretKey.Text.Trim(),
                            Partner = "1",
                            Charge = Convert.ToDecimal(TextBoxCharge.Text.Trim()),
                            Email = TextBoxEmail.Text.Trim(),
                            Memo = TextBoxMemo.Text.Trim()
                        };
                    if (CheckBoxIsPercent.Checked)
                    {
                        payment.IsPercent = 1;
                    }
                    else
                    {
                        payment.IsPercent = 0;
                    }
                    payment.IsCOD = 0;
                    payment.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                    payment.ModifyUser = base.ShopNum1LoginID;
                    payment.ModifyTime = DateTime.Now;
                    payment.ForAdvancePayment = Convert.ToInt32(RadioButtonListForredepositrecharge.SelectedValue);
                    action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
                    if (action.Update(payment, hiddenFieldGuid.Value, 0) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "编辑" + TextBoxName.Text.Trim() + "成功!",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "Payment_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        MessageShow.ShowMessage("EditYes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("EditNo");
                        MessageShow.Visible = true;
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
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void BindData()
        {
            RadioButtonListForredepositrecharge.Items.Clear();
            var item = new ListItem
                {
                    Text = "是",
                    Value = "1"
                };
            RadioButtonListForredepositrecharge.Items.Add(item);
            item = new ListItem
                {
                    Text = "否",
                    Value = "0"
                };
            RadioButtonListForredepositrecharge.Items.Add(item);
        }

        private void method_6()
        {
            TextBoxOrderID.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            TextBoxCharge.Text = string.Empty;
            TextBoxMemo.Text = string.Empty;
            TextBoxMerchantCode.Text = string.Empty;
            TextBoxSecretKey.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            TextBoxOrderID.Text = string.Empty;
            CheckBoxIsPercent.Checked = false;
        }

        private void method_7()
        {
            DataTable table = new ShopNum1_Payment_Action().SearchPayInfo(hiddenFieldGuid.Value, 0);
            if (table.Rows.Count > 0)
            {
                TextBoxName.Text = table.Rows[0]["Name"].ToString();
                TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
                DropDownListPaymentType.SelectedValue = table.Rows[0]["PaymentType"].ToString();
                TextBoxEmail.Text = table.Rows[0]["Email"].ToString();
                TextBoxCharge.Text = table.Rows[0]["Charge"].ToString();
                TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
                TextBoxMerchantCode.Text = table.Rows[0]["MerchantCode"].ToString();
                TextBoxSecretKey.Text = table.Rows[0]["SecretKey"].ToString();
                RadioButtonListForredepositrecharge.SelectedValue = table.Rows[0]["ForAdvancePayment"].ToString();
                if (table.Rows[0]["IsPercent"].ToString() == "0")
                {
                    CheckBoxIsPercent.Checked = false;
                }
                else
                {
                    CheckBoxIsPercent.Checked = true;
                }
                ButtonConfirm.ToolTip = "Update";
                ButtonConfirm.Text = "更新";
            }
        }

        private void method_8()
        {
        }


    }
}