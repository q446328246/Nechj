using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.KCELogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Member_Operate : PageBase, IRequiresSessionState
    {
        //protected void ButtonCheckEmail_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TextBoxEmail.Text))
        //    {
        //        var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
        //        if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
        //        {
        //            MessageBox.Show("该邮箱已注册!");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("邮箱不能为空");
        //    }
        //}

        protected void ButtonCheckMobile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxMobile.Text))
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (action.CheckMemMobileByMobile1(TextBoxMobile.Text.Trim()) > 0)
                {
                    MessageBox.Show("该手机已注册!");
                }
            }
            else
            {
                MessageBox.Show("手机号码为空");
            }
        }

        protected void ButtonCheckName_Click(object sender, EventArgs e)
        {
            if (TextBoxMemLoginID.Text.Trim() == "")
            {
                MessageBox.Show("推荐人不能为空");
            }
            else
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                {
                    MessageBox.Show("推荐人可用");
                }
                else
                {
                    MessageBox.Show("推荐人不存在");
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ButtonConfirm.ToolTip == "Submit")
            {
                if (TextBoxMemLoginID.Text.Trim() == "")
                {
                    MessageBox.Show("推荐人不能为空");
                }
                else
                {
                    ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    if ((ShopNum1_Member_Action.CheckMemMobileByMobile1(TextBoxMobile.Text.Trim()) > 0))
                        {
                            MessageBox.Show("该手机已注册!");
                        }
                    
                    else 
                    {
                        
                        
                        
                            Gz_LogicApi gla = new Gz_LogicApi();
                            string fh=gla.MemberRegister(TextBoxMobile.Text.Trim(),TextBoxRealName.Text.Trim(),TextBoxPwd.Text.Trim(),TextBoxPayPwd.Text.Trim(),TextBoxMemLoginID.Text.Trim(),1);



                            if (fh.Contains("K"))
                            {
                                var operateLog = new ShopNum1_OperateLog
                                    {
                                        Record = "添加会员" + TextBoxMemLoginID.Text.Trim() + "成功",
                                        OperatorID = base.ShopNum1LoginID,
                                        IP = Globals.IPAddress,
                                        PageName = "FreezeAdvancePaymentLog_List.aspx",
                                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    };
                                base.OperateLog(operateLog);
                                MessageShow.ShowMessage("AddYes");
                                MessageShow.Visible = true;
                                base.Response.Redirect("Member_List.aspx");
                            }
                            else
                            {
                                MessageShow.ShowMessage("AddNo");
                                MessageShow.Visible = true;
                            }
                        
                    }
                }
            }
        }

        protected void ClearControl()
        {
            TextBoxMemLoginID.Text = string.Empty;
            //TextBoxEmail.Text = string.Empty;
            TextBoxPwd.Text = string.Empty;
            TextBoxPwd2.Text = string.Empty;
            TextBoxPayPwd.Text = string.Empty;
            TextBoxPayPwd2.Text = string.Empty;
            //TextBoxBirthday.Text = string.Empty;
            //TextBoxCreditMoney.Text = string.Empty;
            //TextBoxRealName.Text = string.Empty;
            //TextBoxVocation.Text = string.Empty;
            //TextBoxAddress.Text = string.Empty;
            //TextBoxPostalcode.Text = string.Empty;
            //TextBoxTel.Text = string.Empty;
            //TextBoxMobile.Text = string.Empty;
            //TextBoxFax.Text = string.Empty;
            //TextBoxQQ.Text = string.Empty;
            //TextBoxMsn.Text = string.Empty;
            //TextBoxCardNum.Text = string.Empty;
            //TextBoxWebSite.Text = string.Empty;
            //DropDownListQuestion.SelectedValue = TextBoxAnswer.Text = string.Empty;
            //DropDownListIsForbid.SelectedValue = "0";
        }

        protected string GetAdress(string AddressValue)
        {
            string[] strArray2 = AddressValue.Split(new[] {'|'})[0].Split(new[] {','});
            if (strArray2.Length == 3)
            {
                return (strArray2[0] + strArray2[1] + strArray2[2]);
            }
            if (strArray2.Length == 2)
            {
                return (strArray2[0] + strArray2[1]);
            }
            if (strArray2.Length == 1)
            {
                return strArray2[0];
            }
            return AddressValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (hiddenGuid.Value != "0")
                {
                    LabelPageTitle.Text = "【 编辑会员 】";
                }
            }
        }
    }
}