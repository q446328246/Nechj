using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System.Web;
using ShopNum1.Common.ShopNum1.Common;


namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopOpenStep2 : BaseMemberWebControl
    {
        private readonly string string_8 = string.Empty;
        private Button ButtonOpen;
        private FileUpload FileUploadBusinessLicense;
        private FileUpload FileUploadIdentityCard;

        private FileUpload FileUploadOrganization;
        private FileUpload FileUploadTaxRegistration;

        private HtmlInputHidden HiddenTaxRegistration;
        private HtmlInputHidden HiddenOrganization;


        private HtmlInputHidden HiddenBusinessImageValue;
        private HtmlInputHidden HiddenIdEdit;
        private HtmlInputHidden HiddenIdentityCard;
        private HtmlInputHidden HiddenIdentityCardValue;
        private HtmlInputHidden HiddenIdentityValue;
        private HtmlInputHidden HiddenShopCategory;
        private HtmlInputHidden HiddenShopCategoryValue;
        private HtmlInputHidden HiddenShopName;
        private HtmlInputHidden HiddenShopNameValue;
        private Panel PanelBusinessLicense;
        private RadioButton RadioButtonBusiness;
        private RadioButton RadioButtonPersonal;
        private TextBox TextBoxAddress;
        private TextBox TextBoxIdentityCard;
        private TextBox TextBoxMainGoods;
        private TextBox TextBoxPhone;
        private TextBox TextBoxPostalCode;
        private TextBox TextBoxShopName;
        private TextBox TextBoxTel;
        private HtmlInputHidden hid_Area;
        private string skinFilename = "S_ShopOpenStep2.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;

        //private TextBox TextBoxReferral;
        public S_ShopOpenStep2()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string scont)
        {
            return new ShopNum1_EmailGroupSend
            {
                Guid = Guid.NewGuid(),
                EmailTitle = string_8,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                EmailGuid = new Guid("114410a5-6f57-465c-b149-b319dd73511e"),
                SendObjectEmail = scont,
                SendObject = memLoginID + "-" + email,
                State = state
            };
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state,
            string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = mobile,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        protected ShopNum1_MMSGroupSend AddSendNote(string memLoginID, string mobile, int state, string scont)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = string_8,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid("114410a5-6f57-465c-b149-b319dd73511e"),
                SendObjectMMS = scont,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        protected void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["OptMsg"] != null)
            {
                method_1();
            }
            else
            {
                BindData();
            }
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/ShopCertification";
                string filepath = str2 + "/" + ImageName + base.MemLoginID + info.Extension;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                {
                    return (ImageName + base.MemLoginID + info.Extension);
                }
                MessageBox.Show(retstr);
                return "0";
            }
            return "1";
        }

        public void GetEditData()
        {
            GetShopC();
            DataTable shopByMemLoginID =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetShopByMemLoginID(
                    base.MemLoginID);
            if ((shopByMemLoginID != null) && (shopByMemLoginID.Rows.Count > 0))
            {
                if (shopByMemLoginID.Rows[0]["ShopType"].ToString() == "0")
                {
                    RadioButtonPersonal.Checked = true;
                }
                else if (shopByMemLoginID.Rows[0]["ShopType"].ToString() == "1")
                {
                    RadioButtonBusiness.Checked = true;
                    PanelBusinessLicense.Visible = true;
                }
                TextBoxShopName.Text = shopByMemLoginID.Rows[0]["ShopName"].ToString();
                TextBoxMainGoods.Text = shopByMemLoginID.Rows[0]["MainGoods"].ToString();
                TextBoxAddress.Text = shopByMemLoginID.Rows[0]["Address"].ToString();
                TextBoxPostalCode.Text = shopByMemLoginID.Rows[0]["PostalCode"].ToString();
                TextBoxPhone.Text = shopByMemLoginID.Rows[0]["Phone"].ToString();
                TextBoxIdentityCard.Text = shopByMemLoginID.Rows[0]["IdentityCard"].ToString();
                hid_Area.Value = shopByMemLoginID.Rows[0]["AddressValue"] + "|" +
                                 shopByMemLoginID.Rows[0]["AddressCode"];
                HiddenShopCategory.Value = shopByMemLoginID.Rows[0]["ShopCategoryID"].ToString();
                TextBoxTel.Text = shopByMemLoginID.Rows[0]["Tel"].ToString();
                HiddenIdentityCardValue.Value = shopByMemLoginID.Rows[0]["CardImage"].ToString();
                HiddenBusinessImageValue.Value = shopByMemLoginID.Rows[0]["BusinessLicense"].ToString();

                HiddenTaxRegistration.Value = shopByMemLoginID.Rows[0]["TaxRegistration"].ToString();
                HiddenOrganization.Value = shopByMemLoginID.Rows[0]["Organization"].ToString();

                HiddenIdEdit.Value = "1";
                HiddenShopNameValue.Value = shopByMemLoginID.Rows[0]["ShopName"].ToString();
                HiddenIdentityValue.Value = shopByMemLoginID.Rows[0]["IdentityCard"].ToString();
                HiddenShopName.Value = "ok";
                HiddenIdentityCard.Value = "ok";
                //TextBoxReferral.Text = shopByMemLoginID.Rows[0]["Referral"].ToString();
            }
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_1 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "EmailServer"));
            string_2 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            string_4 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "ServerPort"));
            string_3 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "EmailAccount"));
            string_5 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "EmailPassword"));
            string_6 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "RestoreEmail"));
            string_7 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                        "EmailCode"));
        }

        public void GetShopC()
        {
        }

        public string GetShopCategory(string strCode)
        {
            DataTable byCode =
                ((ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action()).GetByCode(strCode);
            if ((byCode != null) && (byCode.Rows.Count > 0))
            {
                return (byCode.Rows[0]["ID"] + "|" + byCode.Rows[0]["Code"]);
            }
            return "";
        }

        public string GetShopCategoryName(string strCode)
        {
            DataTable byCode =
                ((ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action()).GetByCode(strCode);
            if ((byCode != null) && (byCode.Rows.Count > 0))
            {
                return byCode.Rows[0]["Name"].ToString();
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenShopCategoryValue = (HtmlInputHidden)skin.FindControl("HiddenShopCategoryValue");
            RadioButtonPersonal = (RadioButton)skin.FindControl("RadioButtonPersonal");
            RadioButtonPersonal.CheckedChanged += RadioButtonPersonal_CheckedChanged;
            RadioButtonBusiness = (RadioButton)skin.FindControl("RadioButtonBusiness");
            RadioButtonBusiness.CheckedChanged += RadioButtonBusiness_CheckedChanged;
            TextBoxShopName = (TextBox)skin.FindControl("TextBoxShopName");
            TextBoxMainGoods = (TextBox)skin.FindControl("TextBoxMainGoods");
            TextBoxAddress = (TextBox)skin.FindControl("TextBoxAddress");
            TextBoxPostalCode = (TextBox)skin.FindControl("TextBoxPostalCode");
            TextBoxPhone = (TextBox)skin.FindControl("TextBoxPhone");
            TextBoxIdentityCard = (TextBox)skin.FindControl("TextBoxIdentityCard");
            FileUploadBusinessLicense = (FileUpload)skin.FindControl("FileUploadBusinessLicense");
            FileUploadIdentityCard = (FileUpload)skin.FindControl("FileUploadIdentityCard");

            FileUploadTaxRegistration = (FileUpload)skin.FindControl("FileUploadTaxRegistration");
            FileUploadOrganization = (FileUpload)skin.FindControl("FileUploadOrganization");

            ButtonOpen = (Button)skin.FindControl("ButtonOpen");
            ButtonOpen.Click += ButtonOpen_Click;
            hid_Area = (HtmlInputHidden)skin.FindControl("hid_Area");
            HiddenShopCategory = (HtmlInputHidden)skin.FindControl("HiddenShopCategory");
            PanelBusinessLicense = (Panel)skin.FindControl("PanelBusinessLicense");
            HiddenIdentityCardValue = (HtmlInputHidden)skin.FindControl("HiddenIdentityCardValue");
            HiddenBusinessImageValue = (HtmlInputHidden)skin.FindControl("HiddenBusinessImageValue");

            HiddenOrganization = (HtmlInputHidden)skin.FindControl("HiddenOrganization");
            HiddenTaxRegistration = (HtmlInputHidden)skin.FindControl("HiddenTaxRegistration");

            HiddenIdEdit = (HtmlInputHidden)skin.FindControl("HiddenIdEdit");
            HiddenShopNameValue = (HtmlInputHidden)skin.FindControl("HiddenShopNameValue");
            HiddenIdentityValue = (HtmlInputHidden)skin.FindControl("HiddenIdentityValue");
            HiddenShopName = (HtmlInputHidden)skin.FindControl("HiddenShopName");
            HiddenIdentityCard = (HtmlInputHidden)skin.FindControl("HiddenIdentityCard");
            TextBoxTel = (TextBox)skin.FindControl("TextBoxTel");

            //TextBoxReferral = (TextBox)skin.FindControl("TextBoxReferral");

            GetShopC();
            if ((Page.Request.QueryString["OptMsg"] != null) && (Page.Request.QueryString["OptMsg"] == "edit"))
            {
                GetEditData();
                ButtonOpen.Text = "编辑信息";
            }
            else if ((Page.Request.QueryString["OptMsg"] != null) && (Page.Request.QueryString["OptMsg"] == "reopen"))
            {
                GetEditData();
                ButtonOpen.Text = "重新开店";
            }
            else if (Page.Request.QueryString["type"] != null)
            {
                ButtonOpen.Text = "立即开店";
            }

            DataTable memInfo =
                   ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo(base.MemLoginID);
            string memloginno = memInfo.Rows[0]["MemLoginNO"].ToString();
            //TJapi.WebService webservice = new TJapi.WebService();

            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Info=" + memloginno + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = webservice.Operate("GETCUSTOMERINFO", memloginno, md5Check_two);
            //string[] sArray = returnResult.Split(new char[2] { '~', '|' });
            //if (sArray[0] == "true")
            //{

            //TextBoxReferral.Text = memInfo.Rows[0]["Superior"].ToString();

            //}

        }

        protected void IsEmail()
        {
            DataTable memberInfoByMemLoginID =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByMemLoginID(
                    base.MemLoginID);
            if (memberInfoByMemLoginID.Rows[0]["Email"].ToString() != "")
            {
                ShopNum1_EmailGroupSend send;
                string str = ShopSettings.GetValue("Name");
                var shop = new OpenShop();
                GetEmailSetting();
                var mail = new NetMail();
                mail.MailDomain = string_2;
                mail.Mailserverport = Convert.ToInt32(string_4.Trim());
                mail.Username = string_3;
                mail.Password = string_5;
                mail.Html = true;
                mail.AddRecipient(memberInfoByMemLoginID.Rows[0]["Email"].ToString());
                shop.Name = memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString();
                shop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByMemLoginID.Rows[0]["ShopID"];
                shop.ShopStatus = "审核中...";
                shop.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                shop.ShopName = str;
                var action2 = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                string s = string.Empty;
                string str3 = string.Empty;
                DataTable editInfo = action2.GetEditInfo("'baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    str3 = editInfo.Rows[0]["Title"].ToString();
                }
                s =
                    s.Replace("{$Name}", memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString())
                        .Replace("{$ShopName}", shop.ShopName)
                        .Replace("{$SendTime}", DateTime.Now.ToString());
                mail.Subject = str3;
                mail.Body = shop.ChangeOpenShop(Page.Server.HtmlDecode(s));
                mail.From = string_6;
                if (!mail.Send())
                {
                    send = Add(memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString(),
                        memberInfoByMemLoginID.Rows[0]["Email"].ToString(), 0, mail.Body);
                    action2.AddEmailGroupSend(send);
                }
                else
                {
                    send = Add(memberInfoByMemLoginID.Rows[0]["MemLoginID"].ToString(),
                        memberInfoByMemLoginID.Rows[0]["Email"].ToString(), 2, mail.Body);
                    action2.AddEmailGroupSend(send);
                }
            }
        }

        protected void IsMMS(string ShopID, string string_9)
        {
            if (string_9.Trim() != "")
            {
                var shop = new OpenShop();
                shop.Name = base.MemLoginID;
                shop.ShopID = ShopID;
                shop.ShopName = TextBoxShopName.Text.Trim();
                shop.ShopStatus = "审核中";
                shop.SysSendTime = DateTime.Now.ToString();
                IShopNum1_MMS_Action action = LogicFactory.CreateShopNum1_MMS_Action();
                string mmsGuid = "baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c";
                DataTable editInfo = action.GetEditInfo(mmsGuid, 0);
                if (editInfo.Rows.Count > 0)
                {
                    ShopNum1_MMSGroupSend send;
                    string s =
                        editInfo.Rows[0]["Remark"].ToString()
                            .Replace("{$Name}", shop.Name)
                            .Replace("{$ShopName}", shop.ShopName)
                            .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sms = new SMS();
                    string retmsg = "";
                    s = shop.ChangeOpenShop(Page.Server.HtmlDecode(s));
                    sms.Send(string_9.Trim(), s + "【唐江宝宝】", out retmsg);
                    if (retmsg.IndexOf("发送成功") != -1)
                    {
                        send = AddMMS(base.MemLoginID, string_9.Trim(), mMsTitle, 2, mmsGuid);
                        action.AddMMSGroupSend(send);
                    }
                    else
                    {
                        send = AddMMS(base.MemLoginID, string_9.Trim(), mMsTitle, 0, mmsGuid);
                        action.AddMMSGroupSend(send);
                    }
                }
            }
        }

        protected void BindData()
        {
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string MemRankGuid = cookie2.Values["MemRankGuid"].ToUpper();
            if (MemRankGuid == MemberLevel.NORMAL_MEMBER_ID.ToUpper() || MemRankGuid == MemberLevel.NORMAL_Regular_Members.ToUpper())
            {
                MessageBox.Show("会员等级不够不能开店");
            }
            else
            {


                var action = (Shop_Rank_Action)ShopFactory.LogicFactory.CreateShop_Rank_Action();
                DataTable table = action.Search("'" + Page.Request.QueryString["type"] + "'", 0);
                decimal payprice = 0M;
                if ((table != null) && (table.Rows.Count > 0))
                {
                    payprice = Convert.ToDecimal(table.Rows[0]["price"].ToString());
                }
                DataTable advancePayment =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetAdvancePayment(base.MemLoginID);
                decimal num4 = 0M;
                if ((advancePayment != null) && (advancePayment.Rows.Count > 0))
                {
                    num4 = Convert.ToDecimal(advancePayment.Rows[0][0].ToString());
                }
                if (payprice > num4)
                {
                    MessageBox.Show("金币（BV）不足，请充值后在操作！");
                }
                else
                {
                    var action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    try
                    {
                        if (action2.GetMemTypeByMemberId(base.MemLoginID) == "2")
                        {
                            MessageBox.Show("此会员已经有店铺");
                            return;
                        }
                    }
                    catch
                    {
                    }

                    string AddressCode = hid_Area.Value.Split(new[] { '|' })[1];
                    string ShopCategoryID = HiddenShopCategoryValue.Value.Split(new[] { '|' })[1];
                    var info = new ShopNum1_ShopInfo();
                    info.AddressCode = AddressCode;
                    info.ShopCategoryID = ShopCategoryID;
                    info.IsIntegralShop = 0;

                    string str2 = FileUpload(FileUploadIdentityCard, new Order().CreateOrderNumber());
                    switch (str2)
                    {
                        case "0":
                            MessageBox.Show("请上传身份证图片！");
                            return;

                        case "1":
                            MessageBox.Show("请上传身份证图片！");
                            return;
                    }
                    string str = "";

                    str = FileUpload(FileUploadBusinessLicense, new Order().CreateOrderNumber());
                    switch (str)
                    {
                        case "0":
                        case "1":
                            MessageBox.Show("请上传营业执照图片！");
                            return;
                    }
                    string str48 = "";
                    string str58 = "";
                    if (RadioButtonBusiness.Checked)
                    {
                        Thread.Sleep(10);
                        str48 = FileUpload(FileUploadTaxRegistration, new Order().CreateOrderNumber());
                        switch (str48)
                        {
                            case "0":
                            case "1":
                                MessageBox.Show("请上传税务登记证图片！");
                                return;
                        }
                        str58 = FileUpload(FileUploadOrganization, new Order().CreateOrderNumber());
                        switch (str58)
                        {
                            case "0":
                            case "1":
                                MessageBox.Show("请上传组织机构代码图片！");
                                return;
                        }

                    }
                    var action3 = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    var action6 = (Shop_Common_Action)ShopFactory.LogicFactory.CreateShop_Common_Action();
                    info.ShopRank = new Guid(Page.Request.QueryString["type"]);
                    info.ShopName = TextBoxShopName.Text.Trim();
                    info.SalesRange = hid_Area.Value.Split(new[] { '|' })[0].Replace(",", "");
                    info.AddressValue = hid_Area.Value.Split(new[] { '|' })[0];
                    info.Banner = "~/Shop/ShopAdmin/images/logodfwe.jpg";
                    info.CollectCount = 0;
                    info.ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    info.OpenTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    info.ModifyUser = base.MemLoginID;
                    info.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    info.ShopCategory = HiddenShopCategoryValue.Value.Split(new[] { '|' })[1];
                    info.OrderID = action6.ReturnMaxID("OrderID", "ShopNum1_ShopInfo") + 1;
                    info.MemLoginID = base.MemLoginID;
                    info.CompanIsAudit = -1;
                    info.IdentityIsAudit = -1;
                    info.IsAudit = 0;
                    info.IsDeleted = 0;
                    info.Name = base.MemLoginID;
                    info.IdentityCard = TextBoxIdentityCard.Text;
                    info.Address = TextBoxAddress.Text;
                    info.MainGoods = TextBoxMainGoods.Text.Trim();
                    info.PostalCode = TextBoxPostalCode.Text.Trim();
                    info.Tel = TextBoxTel.Text.Trim();
                    info.CardImage = str2;
                    info.Organization = str58;
                    info.TaxRegistration = str48;
                    //info.TextBoxReferral = TextBoxReferral.Text.Trim();

                    DataTable defaultTemplate = action.GetDefaultTemplate();
                    string str4 = string.Empty;
                    if ((defaultTemplate != null) && (defaultTemplate.Rows.Count > 0))
                    {
                        str4 = defaultTemplate.Rows[0]["Path"].ToString();
                    }
                    info.TemplateType = str4;
                    info.RegistrationNum = "";
                    info.CompanName = "";
                    info.LegalPerson = "";
                    info.RegisteredCapital = 0M;
                    info.BusinessTerm = "";
                    info.BusinessScope = "";
                    info.BusinessLicense = str;
                    info.Phone = TextBoxPhone.Text.Trim();
                    info.Longitude = "116.40391";
                    info.Latitude = "39.914861";
                    if (RadioButtonPersonal.Checked)
                    {
                        info.ShopType = 0;
                    }
                    else if (RadioButtonBusiness.Checked)
                    {
                        info.ShopType = 1;
                    }
                    else
                    {
                        info.ShopType = 0;
                    }
                    try
                    {
                        info.ShopID = int.Parse(ShopSettings.GetValue("InitialShopID"));
                    }
                    catch
                    {
                        info.ShopID = 0x2710;
                    }
                    int shopIdMax = action3.GetShopIdMax();
                    if (shopIdMax >= info.ShopID)
                    {
                        info.ShopID = shopIdMax + 1;
                    }
                    info.ShopUrl = ShopSettings.GetValue("PersonShopUrl") + info.ShopID;
                    //action3.SelectMemberloginIDQuantity(info.TextBoxReferral).Rows.Count>0&&
                    if (action3.RegistShopMember(info) > 0)
                    {
                        if (ShopSettings.GetValue("ApplyOpenShopIsEmail") == "1")
                        {
                            IsEmail();
                        }
                        if (!(ShopSettings.GetValue("ApplyOpenShopIsMMS") == "1"))
                        {
                        }
                        if (payprice > 0M)
                        {
                            try
                            {
                                action2.UpdateAdvancePayment(1, base.MemLoginID, payprice);
                                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 3,
                                    CurrentAdvancePayment = num4,
                                    OperateMoney = payprice,
                                    LastOperateMoney = Convert.ToDecimal(num4) - payprice,
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    Memo = "开店铺扣除金币（BV）￥" + payprice,
                                    MemLoginID = base.MemLoginID,
                                    CreateUser = base.MemLoginID,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_AdvancePaymentModifyLog_Action)
                                    LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                        advancePaymentModifyLog);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        DataTable table4 = action.Search("'" + Page.Request.QueryString["type"] + "'", 0);
                        int num5 = 0;
                        string str3 = string.Empty;
                        if ((table4 != null) && (table4.Rows.Count > 0))
                        {
                            num5 = Convert.ToInt32(table4.Rows[0]["IsDefault"].ToString());
                            str3 = table4.Rows[0]["Name"].ToString();
                        }
                        if (num5 == 1)
                        {
                            var action5 =
                                (Shop_ShopApplyRank_Action)ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
                            try
                            {
                                action5.DeleteOutRankGuid(Page.Request.QueryString["type"], base.MemLoginID);
                            }
                            catch (Exception)
                            {
                            }
                            var rank = new ShopNum1_Shop_ApplyShopRank
                            {
                                ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                IsAudit = 1,
                                MemberLoginID = base.MemLoginID,
                                IsPayMent = 1,
                                PaymentName = "金币（BV）支付",
                                PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715"),
                                RankGuid = new Guid(Page.Request.QueryString["type"]),
                                VerifyTime = DateTime.Now.AddYears(100),
                                RankName = str3
                            };
                            try
                            {
                                action5.Add(rank);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("等级记录失败！");
                            }
                        }
                        Page.Response.Redirect("S_ShopOpenStep3.aspx");
                    }
                    else
                    {
                        MessageBox.Show("提交失败，请检查所填写的信息内容以及推荐人是否正确!");
                    }
                }
            }
        }

        protected void method_1()
        {
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string MemRankGuid = cookie2.Values["MemRankGuid"].ToUpper();
            if (MemRankGuid == MemberLevel.NORMAL_MEMBER_ID.ToUpper() || MemRankGuid == MemberLevel.VIP_MEMBER_ID.ToUpper() || MemRankGuid == MemberLevel.NORMAL_Regular_Members.ToUpper() || MemRankGuid == MemberLevel.VISITOR_MEMBER_ID.ToUpper())
            {
                MessageBox.Show("会员等级不够不能开店");
            }
            else
            {
                var action = (Shop_Rank_Action)ShopFactory.LogicFactory.CreateShop_Rank_Action();
                decimal num = 0M;
                decimal num2 = 0M;
                if (((Page.Request.QueryString["OptMsg"] != null) && (Page.Request.QueryString["OptMsg"] == "reopen")) &&
                    (ButtonOpen.Text == "重新开店"))
                {
                    string str4 = Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo",
                        "   AND  MemLoginID='" + base.MemLoginID + "'  ");
                    if (string.IsNullOrEmpty(str4))
                    {
                        MessageBox.Show("店铺信息错误");
                        return;
                    }
                    DataTable table2 = action.Search("'" + str4 + "'", 0);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        num = Convert.ToDecimal(table2.Rows[0]["price"].ToString());
                    }
                    DataTable advancePayment =
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetAdvancePayment(
                            base.MemLoginID);
                    if ((advancePayment != null) && (advancePayment.Rows.Count > 0))
                    {
                        num2 = Convert.ToDecimal(advancePayment.Rows[0][0].ToString());
                    }
                    if (num > num2)
                    {
                        MessageBox.Show("金币（BV）不足，请充值后在操作！");
                        return;
                    }
                }
                var info = new ShopNum1_ShopInfo
                {
                    AddressCode = hid_Area.Value.Split(new[] { '|' })[1]
                };
                try
                {
                    if (HiddenShopCategoryValue.Value.Split(new[] { '|' }).Length > 0)
                    {
                        info.ShopCategoryID = HiddenShopCategoryValue.Value.Split(new[] { '|' })[1];
                    }
                    else
                    {
                        info.ShopCategoryID = HiddenShopCategoryValue.Value;
                    }
                }
                catch (Exception)
                {
                    info.ShopCategoryID = HiddenShopCategoryValue.Value;
                }
                var order2 = new Order();
                string str365 = string.Empty;
                if (FileUploadIdentityCard.HasFile)
                {
                    str365 = FileUpload(FileUploadIdentityCard, order2.CreateOrderNumber());
                }
                else
                {
                    str365 = HiddenIdentityCardValue.Value;
                }
                string str65 = "";


                var order = new Order();
                if (FileUploadBusinessLicense.HasFile)
                {
                    str65 = FileUpload(FileUploadBusinessLicense, order.CreateOrderNumber());
                }
                else
                {
                    str65 = HiddenBusinessImageValue.Value;
                }
                string str33 = string.Empty;
                string str44 = string.Empty;
                if (RadioButtonBusiness.Checked)
                {
                    var order34 = new Order();
                    var order44 = new Order();
                    Thread.Sleep(10);
                    if (FileUploadTaxRegistration.HasFile)
                    {
                        str33 = FileUpload(FileUploadTaxRegistration, order34.CreateOrderNumber());
                    }
                    else
                    {
                        str33 = HiddenTaxRegistration.Value;
                    }
                    if (FileUploadOrganization.HasFile)
                    {
                        str44 = FileUpload(FileUploadOrganization, order44.CreateOrderNumber());
                    }
                    else
                    {
                        str44 = HiddenOrganization.Value;
                    }

                }
                var action2 = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                var action1 = (Shop_Common_Action)ShopFactory.LogicFactory.CreateShop_Common_Action();
                info.ShopName = TextBoxShopName.Text.Trim();
                info.SalesRange = hid_Area.Value.Split(new[] { '|' })[0].Replace(",", "");
                info.AddressValue = hid_Area.Value.Split(new[] { '|' })[0];
                info.ModifyUser = base.MemLoginID;
                info.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    if (HiddenShopCategoryValue.Value.Split(new[] { '|' }).Length > 0)
                    {
                        info.ShopCategory = HiddenShopCategoryValue.Value.Split(new[] { '|' })[1];
                    }
                    else
                    {
                        info.ShopCategory = HiddenShopCategoryValue.Value;
                    }
                }
                catch (Exception)
                {
                    info.ShopCategory = HiddenShopCategoryValue.Value;
                }
                info.IdentityCard = TextBoxIdentityCard.Text;
                info.Address = TextBoxAddress.Text;
                info.MainGoods = TextBoxMainGoods.Text.Trim();
                info.PostalCode = TextBoxPostalCode.Text.Trim();
                info.CardImage = str365;

                info.TaxRegistration = str33;
                info.Organization = str44;


                DataTable defaultTemplate = action.GetDefaultTemplate();
                string str2 = string.Empty;
                if ((defaultTemplate != null) && (defaultTemplate.Rows.Count > 0))
                {
                    str2 = defaultTemplate.Rows[0]["Path"].ToString();
                }
                info.TemplateType = str2;
                info.BusinessLicense = str65;
                info.Phone = TextBoxPhone.Text.Trim();
                info.Tel = TextBoxTel.Text.Trim();
                if (RadioButtonPersonal.Checked)
                {
                    info.ShopType = 0;
                }
                else if (RadioButtonBusiness.Checked)
                {
                    info.ShopType = 1;
                }
                else
                {
                    info.ShopType = 0;
                }
                try
                {
                    if (action2.UpdateShop(base.MemLoginID, info) > 0)
                    {
                        if ((((Page.Request.QueryString["OptMsg"] != null) &&
                              (Page.Request.QueryString["OptMsg"] == "reopen")) && (ButtonOpen.Text == "重新开店")) &&
                            (num > 0M))
                        {
                            try
                            {
                                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 3,
                                    CurrentAdvancePayment = num2,
                                    OperateMoney = num,
                                    LastOperateMoney = Convert.ToDecimal(num2) - num,
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    Memo = "重新开店扣除金币（BV）￥" + num,
                                    MemLoginID = base.MemLoginID,
                                    CreateUser = base.MemLoginID,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_AdvancePaymentModifyLog_Action)
                                    LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                        advancePaymentModifyLog);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        Page.Response.Redirect("S_ShopOpenStep3.aspx");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        protected void RadioButtonPersonal_CheckedChanged(object sender, EventArgs e)
        {
            PanelBusinessLicense.Visible = false;
        }

        protected void RadioButtonBusiness_CheckedChanged(object sender, EventArgs e)
        {
            PanelBusinessLicense.Visible = true;
        }
    }
}