using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Member_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonCheckEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
                {
                    MessageBox.Show("该邮箱已注册!");
                }
            }
            else
            {
                MessageBox.Show("邮箱不能为空");
            }
        }

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
                MessageBox.Show("会员ID不能为空");
            }
            else
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                {
                    MessageBox.Show("该会员名已存在!");
                }
                else
                {
                    MessageBox.Show("该会员名可用!");
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ButtonConfirm.ToolTip == "Submit")
            {
                if (TextBoxMemLoginID.Text.Trim() == "")
                {
                    MessageBox.Show("会员ID不能为空");
                }
                else
                {
                    var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                    if (action2.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                    {
                        MessageBox.Show("该会员名已经存在");
                    }
                    else if (!string.IsNullOrEmpty(TextBoxEmail.Text) &&
                             (action2.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0))
                    {
                        MessageBox.Show("该邮箱已注册!");
                    }
                    else if (!string.IsNullOrEmpty(TextBoxPwd.Text))
                    {
                        if (!string.IsNullOrEmpty(TextBoxEmail.Text) &&
                            (action2.CheckMemMobileByMobile1(TextBoxMobile.Text.Trim()) > 0))
                        {
                            MessageBox.Show("该手机已注册!");
                        }
                        else
                        {
                            var member = new ShopNum1_Member
                                {
                                    MemLoginID = TextBoxMemLoginID.Text.Trim(),
                                    Email = TextBoxEmail.Text.Trim(),
                                    Pwd = ShopNum1.Common.Encryption.GetMd5Hash(TextBoxPwd.Text.Trim())
                                };
                            if (HiddenFieldRegionCode.Value != "0")
                            {
                                member.AddressCode = HiddenFieldRegionCode.Value;
                                if (HiddenFieldRegionValue.Value != ",,|0,0,0")
                                {
                                    member.AddressValue = HiddenFieldRegionValue.Value;
                                }
                                else
                                {
                                    member.AddressValue = "";
                                }
                            }
                            else
                            {
                                member.AddressCode = "";
                                member.AddressValue = "";
                            }
                            member.Name = TextBoxRealName.Text.Trim();
                            member.IsDeleted = 0;
                            member.MemberType = 1;
                            member.Score = 0;
                            member.MemberRank = 0;
                            member.LoginTime = 0;
                            member.LockSocre = 0;
                            member.AdvancePayment = 0;
                            member.LockAdvancePayment = 0;
                            member.CostMoney = 0;
                            member.IsMailActivation = 1;
                            if (!string.IsNullOrEmpty(TextBoxPayPwd2.Text))
                            {
                                if (TextBoxPayPwd.Text != TextBoxPayPwd2.Text)
                                {
                                    member.PayPwd = "";
                                }
                                else
                                {
                                    member.PayPwd = ShopNum1.Common.Encryption.GetMd5SecondHash(TextBoxPayPwd.Text.Trim());
                                }
                            }
                            else
                            {
                                member.PayPwd = "";
                            }
                            if (!string.IsNullOrEmpty(TextBoxBirthday.Text.Trim()))
                            {
                                if (Convert.ToDateTime(TextBoxBirthday.Text.Trim()) > DateTime.Now)
                                {
                                    MessageBox.Show("出生日期选择有误");
                                    return;
                                }
                                member.Birthday = Convert.ToDateTime(TextBoxBirthday.Text.Trim());
                            }
                            else
                            {
                                member.Birthday = DateTime.Now;
                            }
                            member.IsForbid = Convert.ToInt32(DropDownListIsForbid.SelectedValue);
                            member.Sex = Convert.ToByte(DropDownListSex.SelectedValue);
                            if (TextBoxCreditMoney.Text == string.Empty)
                            {
                                TextBoxCreditMoney.Text = "0";
                            }
                            member.CreditMoney = Convert.ToDecimal(TextBoxCreditMoney.Text.Trim());
                            member.Photo = HiddenFieldOriginalImge.Value.Trim();
                            member.Vocation = TextBoxVocation.Text.Trim();
                            member.Address = TextBoxAddress.Text;
                            member.Postalcode = TextBoxPostalcode.Text.Trim();
                            member.Mobile = TextBoxMobile.Text.Trim();
                            member.Fax = TextBoxFax.Text.Trim();
                            member.QQ = TextBoxQQ.Text.Trim();
                            member.Msn = TextBoxMsn.Text.Trim();
                            member.WebSite = TextBoxWebSite.Text.Trim();
                            member.Question = DropDownListQuestion.SelectedValue.Trim();
                            member.Answer = TextBoxAnswer.Text.Trim();
                            member.Tel = TextBoxTel.Text.Trim();
                            member.RegeDate = Convert.ToDateTime(DateTime.Now);
                            member.ModifyUser = "admin";
                            member.ModifyTime = DateTime.Now;
                            member.PromotionMemLoginID = "";
                            member.IdentityCard = TextBoxCardNum.Text.Trim();
                            member.Area = GetAdress(member.AddressValue) + member.Address;
                            DataTable defaultMemberRank =
                                ((ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action())
                                    .GetDefaultMemberRank();
                            Guid guid = Guid.NewGuid();
                            try
                            {
                                if ((defaultMemberRank != null) && (defaultMemberRank.Rows.Count > 0))
                                {
                                    guid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
                                }
                                else
                                {
                                    guid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                                }
                            }
                            catch (Exception)
                            {
                                guid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                            }
                            member.MemberRankGuid = guid;
                            if (action2.AddByAdmin(member) == 1)
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
        }

        protected void ClearControl()
        {
            TextBoxMemLoginID.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            TextBoxPwd.Text = string.Empty;
            TextBoxPwd2.Text = string.Empty;
            TextBoxPayPwd.Text = string.Empty;
            TextBoxPayPwd2.Text = string.Empty;
            TextBoxBirthday.Text = string.Empty;
            TextBoxCreditMoney.Text = string.Empty;
            TextBoxRealName.Text = string.Empty;
            TextBoxVocation.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxPostalcode.Text = string.Empty;
            TextBoxTel.Text = string.Empty;
            TextBoxMobile.Text = string.Empty;
            TextBoxFax.Text = string.Empty;
            TextBoxQQ.Text = string.Empty;
            TextBoxMsn.Text = string.Empty;
            TextBoxCardNum.Text = string.Empty;
            TextBoxWebSite.Text = string.Empty;
            DropDownListQuestion.SelectedValue = TextBoxAnswer.Text = string.Empty;
            DropDownListIsForbid.SelectedValue = "0";
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