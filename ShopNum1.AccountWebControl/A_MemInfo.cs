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

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_MemInfo : BaseMemberWebControl
    {
        private Image ImagePath;
        private Label Lab_MemLoginID;
        private Button btn_Save;
        private Button btn_Sure;
        private HtmlInputHidden hid_AreaCode;
        private HtmlInputHidden hid_AreaValue;
        private HtmlInputHidden hid_CheckEmail;
        private HtmlInputHidden hid_CheckMobile;
        private HtmlInputHidden hid_Sex;
        private HtmlSelect sel_Area;
        private HtmlSelect sel_City;
        private HtmlSelect sel_Prov;
        private string skinFilename = "A_MemInfo.ascx";
        private HtmlInputText txt_Address;
        private HtmlInputText txt_Bth;
        private HtmlInputText txt_Email;
        private HtmlInputText txt_Fax;
        private HtmlInputText txt_Mobile;
        private HtmlInputText txt_PalyName;
        private HtmlInputText txt_Post;
        private HtmlInputText txt_QQ;
        private HtmlInputText txt_Tel;
        private HtmlInputText txt_UserName;
        private HtmlInputText txt_Voc;
        private HtmlInputText txt_WebSite;

        public A_MemInfo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string StrMemLoginID { get; set; }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            var member = new ShopNum1_Member
            {
                RealName = txt_PalyName.Value
            };
            if (hid_Sex.Value != "")
            {
                member.Sex = Convert.ToByte(hid_Sex.Value);
            }
            else
            {
                member.Sex = Convert.ToByte("2");
            }
            if (((txt_Email.Value.Trim() != "") && (action.CheckmemEmail(txt_Email.Value.Trim()) > 0)) &&
                (action.FindPwdEamil(base.MemLoginID, txt_Email.Value.Trim()).Rows.Count == 0))
            {
                MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
            }
            else if (((txt_Mobile.Value.Trim() != "") &&
                      (action.CheckMemMobileByMobile(txt_Mobile.Value.Trim()).Rows.Count > 0)) &&
                     (base.MemLoginID !=
                      action.CheckMemMobileByMobile(txt_Mobile.Value).Rows[0]["MemLoginID"].ToString()))
            {
                MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
            }
            else
            {
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
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
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
                    Area = string.Empty, //GetAdress(member.AddressValue, member.Address),
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

        protected override void InitializeSkin(Control skin)
        {
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            hid_Sex = (HtmlInputHidden) skin.FindControl("hid_Sex");
            txt_UserName = (HtmlInputText) skin.FindControl("txt_UserName");
            txt_PalyName = (HtmlInputText) skin.FindControl("txt_PalyName");
            txt_Email = (HtmlInputText) skin.FindControl("txt_Email");
            txt_Address = (HtmlInputText) skin.FindControl("txt_Address");
            sel_Prov = (HtmlSelect) skin.FindControl("sel_Prov");
            sel_City = (HtmlSelect) skin.FindControl("sel_City");
            sel_Area = (HtmlSelect) skin.FindControl("sel_Area");
            btn_Sure = (Button) skin.FindControl("btn_Sure");
            btn_Save = (Button) skin.FindControl("btn_Save");
            txt_QQ = (HtmlInputText) skin.FindControl("txt_QQ");
            txt_Mobile = (HtmlInputText) skin.FindControl("txt_Mobile");
            txt_Tel = (HtmlInputText) skin.FindControl("txt_Tel");
            txt_WebSite = (HtmlInputText) skin.FindControl("txt_WebSite");
            txt_Bth = (HtmlInputText) skin.FindControl("txt_Bth");
            txt_Post = (HtmlInputText) skin.FindControl("txt_Post");
            txt_Voc = (HtmlInputText) skin.FindControl("txt_Voc");
            txt_Fax = (HtmlInputText) skin.FindControl("txt_Fax");
            hid_AreaCode = (HtmlInputHidden) skin.FindControl("hid_AreaCode");
            hid_AreaValue = (HtmlInputHidden) skin.FindControl("hid_AreaValue");
            hid_CheckMobile = (HtmlInputHidden) skin.FindControl("hid_CheckMobile");
            hid_CheckEmail = (HtmlInputHidden) skin.FindControl("hid_CheckEmail");
            btn_Sure.Click += btn_Sure_Click;
            btn_Save.Click += btn_Save_Click;
            ImagePath = (Image) skin.FindControl("ImagePath");
            StrMemLoginID = base.MemLoginID;
            Lab_MemLoginID.Text = base.MemLoginID;
            if (!Page.IsPostBack)
            {
                method_0(StrMemLoginID);
            }
        }

        private void method_0(string string_2)
        {
            DataTable memInfo =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo(string_2);
            try
            {
                if (memInfo.Rows.Count > 0)
                {
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
                }
            }
            catch (InvalidCastException)
            {
            }
        }
    }
}