using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_MemInfo : BaseMemberControl
    {
        public string StrMemLoginID { get; set; }
        private string StrBank;
        private string StrBankName;


        protected void Page_Load(object sender, EventArgs e)
        {
            StrMemLoginID = base.MemLoginID;
            Lab_MemLoginID.Text = base.MemLoginID;
            if (!Page.IsPostBack)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                string MemberLoginID = cookie2.Values["MemRankGuid"];

                BindData(StrMemLoginID);


           }
        }

        private void BindData(string string_2)
        {
            try
            {
                DataTable memInfo =
                    ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo(string_2);

                if (memInfo.Rows.Count > 0)
                {
                    if (memInfo.Rows[0]["RealName"].ToString() == null || memInfo.Rows[0]["RealName"].ToString() == "")
                    {
                        //Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                        //                                                            "<script>alert(\"系统检测到你没有填写真实姓名，请绑定！\");location.href='http://" +
                        //                                                            ShopSettings.siteDomain +
                        //                                                            "/Main/Account/A_Index.aspx?tomurl=A_BindRealName.aspx';</script>");
                        Response.Write("<script>top.location='a_index.aspx?action=1&toaurl=A_BindRealName.aspx';</script>");
                    }
                    else
                    {


                        Lab_MemLoginNO.Text = memInfo.Rows[0]["MemLoginNO"].ToString();
                        Lab_MemLoginID.Text = memInfo.Rows[0]["MemLoginID"].ToString();
                        txt_UserName.Value = memInfo.Rows[0]["Name"].ToString();
                        txt_Email.Value = memInfo.Rows[0]["Email"].ToString();
                        txt_Address.Value = memInfo.Rows[0]["Address"].ToString();
                        txt_Mobile.Value = memInfo.Rows[0]["Mobile"].ToString();
                        txt_Tel.Value = memInfo.Rows[0]["Tel"].ToString();
                        txt_Voc.Value = memInfo.Rows[0]["Vocation"].ToString();
                        txt_WebSite.Value = memInfo.Rows[0]["WebSite"].ToString();
                        txt_Post.Value = memInfo.Rows[0]["Postalcode"].ToString();
                        txt_Fax.Value = memInfo.Rows[0]["Fax"].ToString();
                        txt_QQ.Value = memInfo.Rows[0]["QQ"].ToString();

                        txt_Bth.Value = (memInfo.Rows[0]["Birthday"].ToString() == string.Empty)
                                            ? string.Empty
                                            : DateTime.Parse(memInfo.Rows[0]["Birthday"].ToString())
                                                      .ToString("yyyy-MM-dd");
                        hid_Sex.Value = memInfo.Rows[0]["Sex"].ToString();
                        txt_PalyName.Value = memInfo.Rows[0]["RealName"].ToString();


                        hid_AreaValue.Value = memInfo.Rows[0]["AddressValue"].ToString();
                        hid_AreaCode.Value = memInfo.Rows[0]["AddressCode"].ToString();
                        ImagePath.ImageUrl = (memInfo.Rows[0]["Photo"].ToString() == "")
                                                 ? ShopSettings.GetValue("MemberImage")
                                                 : memInfo.Rows[0]["Photo"].ToString();
                        hid_CheckEmail.Value = memInfo.Rows[0]["IsEmailActivation"].ToString();
                        hid_CheckMobile.Value = memInfo.Rows[0]["IsMobileActivation"].ToString();

                        txtPCreateTime.Text = memInfo.Rows[0]["RegeDate"].ToString();
                        TxtBank.Text = memInfo.Rows[0]["Bank"].ToString();
                        
                        TxtBankName.Text = memInfo.Rows[0]["RealName"].ToString();
                        
                        TxtBankNo.Text = memInfo.Rows[0]["BankNo"].ToString();
                        TxtBankAddress.Text = memInfo.Rows[0]["BankAddress"].ToString();
    
                        //TJAPItwo.WebService webservice = new TJAPItwo.WebService();

                        //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                        //string privateKey_two = "Info=" + Lab_MemLoginNO.Text + md5_one;
                        //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                        //string returnResult = webservice.Operate("GETCUSTOMERINFO", Lab_MemLoginNO.Text, md5Check_two);
                        //string[] sArray = returnResult.Split(new char[2] { '~', '|' });
                        //if (sArray[0] == "true")
                        //{
                        //    txtReferee.Text = sArray[7];
                        //    txtPlace.Text = sArray[4];
                        //}
                    }
                }
            }
            catch (InvalidCastException)
            {

            }
        }

        protected void btn_Sure_Click(object sender, EventArgs e)
        {
            DataTable memInfo =
                   ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo( base.MemLoginID);
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            var member = new ShopNum1_Member
                {
                   RealName=memInfo.Rows[0]["RealName"].ToString()
                };

            if (hid_Sex.Value != "")
            {
                member.Sex = Convert.ToByte(hid_Sex.Value);
            }
            else
            {
                member.Sex = Convert.ToByte("2");
            }

            //if (((txt_Email.Value.Trim() != "") && (action.CheckmemEmail(txt_Email.Value.Trim()) > 0)) &&
            //    (action.FindPwdEamil(base.MemLoginID, txt_Email.Value.Trim()).Rows.Count == 0))
            //{
            //    MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
            //}
            //else if (((txt_Mobile.Value.Trim() != "") &&
            //          (action.CheckMemMobileByMobile(txt_Mobile.Value.Trim()).Rows.Count > 0)) &&
            //         (base.MemLoginID !=
            //          action.CheckMemMobileByMobile(txt_Mobile.Value).Rows[0]["MemLoginID"].ToString()))
            //{
            //    MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
            //}
            //else
            //{
             
                member.QQ = txt_QQ.Value;
                member.Email = txt_Email.Value;
                member.Mobile = txt_Mobile.Value;
                member.ModifyUser = StrMemLoginID;
                member.ModifyTime = DateTime.Now;
                member.Name = txt_UserName.Value;
                member.Tel = txt_Tel.Value;
  
                try
                {
                    if (action.UpdateMemInfo(StrMemLoginID, member) > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                }
                catch
                {
                }
            //}
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Address.Value == "")
            {
                MessageBox.Show("地址不能为空");
            }
            else if (txt_Post.Value == "")
            {
                MessageBox.Show("邮编不能为空");
            }
            else
            {
                ShopNum1_Member member;
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
               
                member = new ShopNum1_Member
                    {
                        AddressCode = hid_AreaCode.Value,
                        AddressValue = hid_AreaValue.Value,
                        Address = txt_Address.Value,
                        Area = GetAdress(hid_AreaValue.Value, txt_Address.Value),
                        WebSite = txt_WebSite.Value,
                        Fax = txt_Fax.Value,
                        ModifyUser = StrMemLoginID,
                        ModifyTime = DateTime.Now
                    };
                
                if (txt_Bth.Value != "")
                {
                    member.Birthday = DateTime.Parse(txt_Bth.Value);
                    DateTime? birthday = member.Birthday;
                    DateTime now = DateTime.Now;
                    if (birthday.HasValue ? (birthday.GetValueOrDefault() > now) : false)
                    {
                        MessageBox.Show("出生日期填写有误");
                        return;
                    }
                }
                else
                {
                    member.Birthday = DateTime.Now;
                }

                member.Vocation = txt_Voc.Value;
                member.Postalcode = txt_Post.Value;
                
                try
                {
                    if (action.UpdateMemInfoDetail(StrMemLoginID, member) > 0)
                    {
                        MessageBox.Show("信息补充成功");
                    }
                }
                catch
                {
                }
            }
        }

        protected string GetAdress(object AddressValue, object Address)
        {
            try
            {
                string[] strArray2 = AddressValue.ToString().Split(new[] {'|'})[0].Split(new[] {','});
                string str2 = string.Empty;
                if (strArray2.Length == 3)
                {
                    str2 = strArray2[0] + strArray2[1] + strArray2[2];
                }
                else if (strArray2.Length == 2)
                {
                    str2 = strArray2[0] + strArray2[1];
                }
                else if (strArray2.Length == 1)
                {
                    str2 = strArray2[0];
                }
                else
                {
                    str2 = Address.ToString();
                }
                return (str2 + Address);
            }
            catch
            {
                return "";
            }
        }

        public string GetMemLoginID()
        {
            return StrMemLoginID;
        }

        //protected void butTJR_Click(object sender, EventArgs e)
        //{
        //    ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //    DataTable tbc = member_Action.SearchCMember(txtTJR.Text.Trim());
        //     if (tbc.Rows.Count > 0)
        //     {
        //         DataTable tba = member_Action.GetMemInfoByNO(txtTJR.Text.Trim());

        //         if (tba.Rows[0]["MemLoginID"].ToString().Trim().ToUpper() == base.MemLoginID.Trim().ToUpper())
        //         {
        //             Response.Write("<script>alert('不能绑定自己做推荐人！');</script>");
        //             BindData(StrMemLoginID);
        //         }
        //         else
        //         {
        //             member_Action.UpdateMemberSuperior(base.MemLoginID, txtTJR.Text);
        //             Response.Write("<script>alert('绑定成功！');</script>");
        //             BindData(StrMemLoginID);
        //         }
        //     }
        //     else
        //     {
        //         Response.Write("<script>alert('会员不存在！');</script>");
        //         BindData(StrMemLoginID);
        //     }

        //}

        protected void btnBank_Click(object sender, EventArgs e)
        {

            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable member = action.GetMemInfo(base.MemLoginID);
            if (member.Rows.Count > 0)
            {
                StrBank = member.Rows[0]["Bank"].ToString();
                StrBankName = member.Rows[0]["RealName"].ToString();
            }

            int tl = action.UpdateMemberBank(TxtBanklist.SelectedValue, StrBankName, TxtBankNo.Text.Trim(), TxtBankAddress.Text.Trim(), base.MemLoginID);
            if (tl != 0)
            {
                MessageBox.Show("银行信息修改成功");
            }
            else 
            {
                MessageBox.Show("操作失败");
            }


        }
    }
}
                                            
