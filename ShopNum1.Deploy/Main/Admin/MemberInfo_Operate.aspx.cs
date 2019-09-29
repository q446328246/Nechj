using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberInfo_Operate : PageBase, IRequiresSessionState
    {
        private string ShopID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void ButtonCheckEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                //method_6();
                MessageBox.Show("邮箱可以用！");
            }
            else
            {
                MessageBox.Show("电子邮箱为空");
            }
        }

        protected void ButtonCheckMobile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxMobile.Text))
            {
                //ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                //DataTable table = action.YZmobile(TextBoxMobile.Text.Trim());
                //if (table.Rows.Count > 0)
                //{
                //    MessageBox.Show("手机号码已存在");
                //}
                //else
                //{

                //}

            }
            else
            {
                MessageBox.Show("手机号码为空");
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var member = new ShopNum1_Member();
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (!string.IsNullOrEmpty(TextBoxPwd2.Text))
            {
                if (TextBoxPwd.Text != TextBoxPwd2.Text)
                {
                    member.Pwd = ViewState["Pwd"].ToString();
                }
                else
                {
                    member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(TextBoxPwd.Text.Trim());
                }
            }
            else
            {
                member.Pwd = ViewState["Pwd"].ToString();
            }
            if (!string.IsNullOrEmpty(TextBoxPayPwd2.Text))
            {
                if (TextBoxPayPwd.Text != TextBoxPayPwd2.Text)
                {
                    member.PayPwd = ViewState["PayPwd"].ToString();
                }
                else
                {
                    member.PayPwd = ShopNum1.Common.Encryption.GetMd5SecondHash(TextBoxPayPwd.Text.Trim());
                }
            }
            else
            {
                member.PayPwd = ViewState["PayPwd"].ToString();
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
                try
                {
                    member.Birthday = Convert.ToDateTime(ViewState["Birthday"]);
                }
                catch
                {
                }
            }
            if (!string.IsNullOrEmpty(TextBoxEmail.Text.Trim()))
            {
                //if (method_6())
                //{
                //    return;
                //}
                member.Email = TextBoxEmail.Text.Trim();
            }
            else
            {
                member.Email = ViewState["Email"].ToString();
            }
            if (!string.IsNullOrEmpty(TextBoxMobile.Text.Trim()))
            {
                ShopNum1_Member_Action actionMobileID = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable table = actionMobileID.JCmobile(TextBoxMobile.Text.Trim(), TextBoxName.Text.Trim());
                //if (table.Rows.Count > 0)
                //{
                //    MessageBox.Show("手机号码已存在");
                //}
                //else
                //{
                    member.Mobile = TextBoxMobile.Text.Trim();
                    if (!string.IsNullOrEmpty(TextBoxCardNum.Text.Trim()))
                    {
                        ShopNum1_Member_Action actioncarID = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable table2 = actioncarID.JCIDCard(TextBoxCardNum.Text.Trim(), TextBoxName.Text.Trim());
                        //if (table2.Rows.Count > 0)
                        //{
                        //    MessageBox.Show("身份证号码已存在");
                        //}
                        //else
                        //{
                            
                            #region
                            member.MemLoginID = TextBoxName.Text.Trim();
                            if (DropDownListMemberRankGuid.SelectedValue != "-1")
                            {
                                if (DropDownListMemberRankGuid.SelectedValue == "1")
                                {
                                    member.RetailersStates = 1;
                                    member.MemberRankGuid = new Guid(MemberRankGuid.Text);
                                }
                                else
                                {
                                    member.RetailersStates = 0;
                                    member.MemberRankGuid = new Guid(DropDownListMemberRankGuid.SelectedValue);
                                }
                            }
                            else
                            {
                                member.RetailersStates = Convert.ToInt32(LabelRetailersStates.Text);
                                member.MemberRankGuid = new Guid(MemberRankGuid.Text);
                            }
                            member.Name = TextBoxMemberName.Text.Trim();
                            member.LastLoginIP = HttpContext.Current.Request.UserHostAddress;
                            member.Address = TextBoxAddress.Text.Trim();
                            member.AddressCode = HiddenFieldRegionCode.Value;
                            member.AddressValue = HiddenFieldRegionValue.Value;
                            member.Area = GetAdress(member.AddressValue) + member.Address;
                            member.Vocation = TextBoxVocation.Text.Trim();
                            member.Postalcode = TextBoxPostalcode.Text.Trim();
                            member.Fax = TextBoxFax.Text.Trim();
                            member.ModifyUser = "admin";
                            member.IdentityCard = TextBoxCardNum.Text.Trim();
                            member.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            member.QQ = TextBoxQQ.Text.Trim();
                            member.WebSite = TextBoxWebSite.Text.Trim();
                            member.Sex = Convert.ToByte(DropDownListSex.SelectedValue);
                            member.Tel = TextBoxTel.Text.Trim();
                            member.RealName = TextBoxRealName.Text;
                            member.Superior = TextBoxSuperior.Text;
                            member.ShopNames = TextBoxShopNames.Text;

                            try
                            {
                                if (HiddenFieldOriginalImge.Value != "")
                                {
                                    member.Photo = HiddenFieldOriginalImge.Value;
                                }
                                else
                                {
                                    member.Photo = "";
                                }
                                if (action.Update(member) > 0)
                                {
                                    //#region 修改3G网会员电话
                                    //String Guid1 = action.GetGuidByMemLoginID(member.MemLoginID);
                                    //DataTable tablemember = action.SearchMemberGuid(Guid1);
                                    //action.Update3GMobile(tablemember.Rows[0]["MemLoginNO"].ToString(), member.Mobile);
                                    //#endregion

                                    var operateLog = new ShopNum1_OperateLog
                                    {
                                        Record = "编辑" + TextBoxName.Text.Trim() + "成功",
                                        OperatorID = base.ShopNum1LoginID,
                                        IP = Globals.IPAddress,
                                        PageName = "MemberInfo_Operate.aspx",
                                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    };
                                    base.OperateLog(operateLog);
                                    base.Response.Redirect("Member_List.aspx");
                                }
                            }
                            catch
                            {
                            }
                            #endregion
                        //}

                    }
                    else
                    {
                        MessageBox.Show("身份证号码为空");
                        
                    }
                    
                }
                
            //}
            //else
            //{
            //    MessageBox.Show("手机号码为空");
                
            //}
            
            
        }

        protected string GetAdress(string Address)
        {
            string[] strArray2 = Address.Split(new[] { '|' })[0].Split(new[] { ',' });
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
            return Address;
        }

        private void BindData()
        {
            CheckGuid.Value = base.Request.QueryString["guid"];
            DataTable allShopInfoByGuid =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetAllShopInfoByGuid(
                    CheckGuid.Value);
            if ((allShopInfoByGuid != null) && (allShopInfoByGuid.Rows.Count > 0))
            {
                TextBoxName.Text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
                TextBoxRealName.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();
                TextBoxMemberName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
                //TextBoxMemberName.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();

                LabelCreditMoney.Text = allShopInfoByGuid.Rows[0]["CreditMoney"].ToString();
                TextBoxSuperior.Text = allShopInfoByGuid.Rows[0]["Superior"].ToString();
                string card = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();
                string birthday = allShopInfoByGuid.Rows[0]["Birthday"].ToString();
                MemberRankGuid.Text = allShopInfoByGuid.Rows[0]["MemberRankGuid"].ToString();
                LabelRetailersStates.Text = allShopInfoByGuid.Rows[0]["RetailersState"].ToString();

                if (LabelRetailersStates.Text == "1")
                {
                    LabelIsRetailersStates.Text = "是";
                }
                else
                {
                    LabelIsRetailersStates.Text = "否";
                }

                if (birthday == string.Empty && card != string.Empty)
                {
                    TextBoxCardNum.Text = card;
                    if (card.Length == 15)
                    {


                        birthday = "19" + card.Substring(6, 2) + "-" + card.Substring(8, 2) + "-" + card.Substring(10, 2);

                    }
                    else
                    {
                        birthday = card.Substring(6, 4) + "-" + card.Substring(10, 2) + "-" + card.Substring(12, 2);
                    }
                    TextBoxBirthday.Text = birthday;
                }
                else
                {

                    TextBoxCardNum.Text = card;
                    TextBoxBirthday.Text = birthday;

                }
                TextBoxEmail.Text = allShopInfoByGuid.Rows[0]["Email"].ToString();
                TextBoxVocation.Text = allShopInfoByGuid.Rows[0]["Vocation"].ToString();
                TextBoxPostalcode.Text = allShopInfoByGuid.Rows[0]["Postalcode"].ToString();
                TextBoxFax.Text = allShopInfoByGuid.Rows[0]["Fax"].ToString();
                ImagePhoto.Src = allShopInfoByGuid.Rows[0]["Photo"].ToString();

                string str = allShopInfoByGuid.Rows[0]["MemberRankGuid"].ToString();
                DataTable table2 =
                    ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).Search(
                        "'" + str + "'", 0);
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    LabelMemberRankGuid.Text = table2.Rows[0]["Name"].ToString();
                }
                TextBoxQQ.Text = allShopInfoByGuid.Rows[0]["QQ"].ToString();
                TextBoxWebSite.Text = allShopInfoByGuid.Rows[0]["WebSite"].ToString();
                LabelRegeDate.Text = allShopInfoByGuid.Rows[0]["RegeDate"].ToString();
                TextBoxMobile.Text = allShopInfoByGuid.Rows[0]["Mobile"].ToString();
                LabelLockSocre.Text = allShopInfoByGuid.Rows[0]["LockSocre"].ToString();
                if (allShopInfoByGuid.Rows[0]["LoginDate"].ToString() == string.Empty)
                {
                    LabelLastLoginTime.Text = "";
                }
                else if (Convert.ToDateTime(allShopInfoByGuid.Rows[0]["LoginDate"]).ToString("yyyy-MM-dd") ==
                         "1900-01-01")
                {
                    LabelLastLoginTime.Text = "";
                }
                else
                {
                    LabelLastLoginTime.Text = allShopInfoByGuid.Rows[0]["LoginDate"].ToString();
                }
                LabelScore.Text = allShopInfoByGuid.Rows[0]["Score"].ToString();
                LabelLockAdvancePayment.Text = allShopInfoByGuid.Rows[0]["LockAdvancePayment"].ToString();
                TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
                HiddenFieldRegionCode.Value = ((allShopInfoByGuid.Rows[0]["AddressCode"].ToString() == "") ||
                                               (allShopInfoByGuid.Rows[0]["AddressCode"].ToString() == "0"))
                                                  ? "0"
                                                  : allShopInfoByGuid.Rows[0]["AddressCode"].ToString();
                HiddenFieldRegionValue.Value = ((allShopInfoByGuid.Rows[0]["AddressValue"].ToString() == "") ||
                                                (allShopInfoByGuid.Rows[0]["AddressValue"].ToString() == ",,|0,0,0"))
                                                   ? "0"
                                                   : allShopInfoByGuid.Rows[0]["AddressValue"].ToString();
                HiddenFieldOriginalImge.Value = allShopInfoByGuid.Rows[0]["Photo"].ToString();
                ImagePhoto.Src = Page.ResolveUrl(allShopInfoByGuid.Rows[0]["Photo"].ToString());
                TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
                DropDownListSex.SelectedValue = allShopInfoByGuid.Rows[0]["SEX"].ToString();
                LabelCostMoney.Text = allShopInfoByGuid.Rows[0]["CostMoney"].ToString();
                ViewState["Pwd"] = allShopInfoByGuid.Rows[0]["Pwd"].ToString();
                ViewState["PayPwd"] = allShopInfoByGuid.Rows[0]["PayPwd"].ToString();
                ViewState["Birthday"] = allShopInfoByGuid.Rows[0]["Birthday"].ToString();
                ViewState["Email"] = allShopInfoByGuid.Rows[0]["Email"].ToString();
                ViewState["Mobile"] = allShopInfoByGuid.Rows[0]["Mobile"].ToString();
                DropDownListSex.SelectedValue = allShopInfoByGuid.Rows[0]["Sex"].ToString();
                if (allShopInfoByGuid.Rows[0]["MemberType"].ToString() == "1")
                {
                    LabelMemberType.Text = "个人会员";
                    TextBoxShopNames.Enabled = false;
                }
                else
                {
                    LabelMemberType.Text = "店铺会员";
                    TextBoxShopNames.Text = allShopInfoByGuid.Rows[0]["ShopNames"].ToString();
                }
            }
        }

        //private bool method_6()
        //{
        //var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
        //if (action.CheckMemEmailByEmail(TextBoxEmail.Text.Trim()).Rows.Count > 0)
        //{
        //    string str = action.CheckMemEmailByEmail(TextBoxEmail.Text.Trim()).Rows[0]["MemLoginID"].ToString();
        //    if (TextBoxName.Text.Trim() == str)
        //    {
        //        return false;
        //    }
        //    MessageBox.Show("该邮箱已被使用!");
        //return true;
        //}
        //    //return false;
        //}

        //private bool method_7()
        //{
        //    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //    if (action.CheckMemMobileByMobile(TextBoxMobile.Text.Trim()).Rows.Count > 0)
        //    {
        //        string str = action.CheckMemMobileByMobile(TextBoxMobile.Text.Trim()).Rows[0]["MemLoginID"].ToString();
        //        if (TextBoxName.Text.Trim() == str)
        //        {
        //            return false;
        //        }
        //        MessageBox.Show("该手机已被使用!");
        //        return true;
        //    }
        //    return false;
        //}

        protected void DropDownListMemberRankGuid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListMemberRankGuid.SelectedItem.Text != "1")
            {
                LabelMemberRankGuid.Text = DropDownListMemberRankGuid.SelectedItem.Text;
            }
        }


    }
}