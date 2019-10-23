using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.Api;
using ShopNum1.Deploy.KCELogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main
{
    public partial class MemberRegisterHtml5 : System.Web.UI.Page
    {
        ShopNum1_Member_Action action = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Referee = Page.Request.QueryString["Referee"].ToString();
                Tuijian.Value = Referee;
                string MemLoginID = "";
                for (int i = 0; i < 10000; i++)
                {
                    MemLoginID = action.GetGZMemberNumber();
                    DataTable YzMemLoginID = action.KceYzMember(MemLoginID);
                    if (YzMemLoginID == null || YzMemLoginID.Rows.Count==0)
                    {
                        MemloginID.Text = MemLoginID;
                        i = 10000;
                    }
                }
            }
        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {
            //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(Mobile.Text, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
            //if (IsHandset)
            //{
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            DataTable YzMemMobie = action.YzMemberMobile(Mobile.Value);
            if (YzMemMobie.Rows.Count > 0)
            {
                TS.Text = "手机号码已存在";
            }
            else
            {
                string code = new Random().Next(111111, 999999).ToString();
                DataTable activate = Activateaction.GzSelectActivate(Mobile.Value);
                if (activate.Rows.Count > 0)
                {
                    string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                    Activateaction.UpdateMobileCode(Mobile.Value, "", code, time);
                }
                else
                {
                    ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                    shopNum1_MemberActivate.Guid = Guid.NewGuid();
                    shopNum1_MemberActivate.MemberID = "";
                    shopNum1_MemberActivate.Pwd = "";
                    shopNum1_MemberActivate.Key = code;
                    shopNum1_MemberActivate.type = 0;
                    shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                    shopNum1_MemberActivate.Phone = Mobile.Value;
                    shopNum1_MemberActivate.isinvalid = 0;
                    Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                }
                string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NEC】";
                //Gz_LogicApi gla = new Gz_LogicApi();
                Mobile mbo = new Mobile();
                string fh = "";
                int mobileInt = Mobile.Value.IndexOf("+");
                if (Mobile.Value.Length != 11 || mobileInt!=-1)
                {
                    fh = mbo.sendwhj(Mobile.Value, code, "6015499");
                }
                else
                {
                    fh = mbo.sendwhj(Mobile.Value, code, "513065");
                }
                if (fh == "100")
                {
                    TS.Text = "发送成功";
                    Button1.Style.Add("display", "none");
                    counter_btn.Style.Add("display", "block");
                }
                else
                {
                    TS.Text = "发送失败";
                }
            }
            //}
            //else
            //{

            //    TS.Text = "手机号码格式不正确";


            //}

        }

        protected void submit_Click(object sender, EventArgs e)
        {
         
            try
            {
                int result;

                string Referee = Page.Request.QueryString["Referee"].ToString();
                if (Mobile.Value == "")
                {
                    TS.Text = "手机号为空";
                }
                else  if (!isNumberic(IIPassWord.Value, out result))
                {
                    TS.Text = "支付密码不能输入非数字"; 
                }
                else if (IIPassWord.Value.Length!=6)
                {
                    TS.Text = "支付密码必须是6位"; 
                }
                else if (Name.Value == "") { TS.Text = "昵称为空"; }
                else if (PassWord.Value == "") { TS.Text = "密码为空"; }
                else if (PassWord.Value != Passwords.Value) { TS.Text = "两次输入的密码不一致，请确认后重新输入！！！"; }
                else if (IIPassWord.Value == "") { TS.Text = "交易密码为空"; }
                else if (PassWord.Value == IIPassWord.Value) { TS.Text = "交易密码和登陆密码不能相同！！！"; }
                else if (MobileCode.Value == "") { TS.Text = "验证码为空"; }
                else if (Referee == "") { TS.Text = "推荐人为空"; }
                else if (Referee != Tuijian.Value) { TS.Text = "推荐人UID有误"; }
                else if (IIPassWord.Value.Length != 6) { TS.Text = "交易密码必须为6位"; }
                else
                {
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MobileCode.Value, Mobile.Value);
                    if (cw != "1")
                    {

                        TS.Text = "验证码错误";
                    }
                    else
                    {
                        Gz_LogicApi gla = new Gz_LogicApi();
                        string fh = gla.Html5MemberRegister(MemloginID.Text, Mobile.Value, Name.Value, PassWord.Value, IIPassWord.Value, Tuijian.Value);
                        if (fh.Substring(0, 1).Contains("S"))
                        {
                            TS.Text = "注册成功";
                            Response.Redirect("MemberRegisterHtml5CG.aspx?member=" + fh.Substring(1));
                        }
                        else
                        {
                            TS.Text = fh;
                        }

                    }
                }
            }
            catch (Exception )
            {

                TS.Text = "系统错误";
            }

        }

        protected bool isNumberic(string message, out int result)
        {
            //判断是否为整数字符串
            //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false
            result = -1;   //result 定义为out 用来输出值
            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                result = Convert.ToInt32(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
     
    }
}