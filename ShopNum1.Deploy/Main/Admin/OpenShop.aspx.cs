using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OpenShop : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                HiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                            ? "0"
                                            : base.Request.QueryString["guid"];
                GetMemberName();
                DropDownListShopCategoryCode1Bind();
                DropDownListRegionCode1Bind();
                GetShopRank();
            }
        }

        protected void Add()
        {
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            action.UpdateMemberType(HiddenFieldGuid.Value, 2);
            var info = new ShopNum1_ShopInfo();
            SetShopCategoryCode();
            SetShopRegionCode();
            info.ShopCategoryID = HiddenFieldCode.Value.Trim();
            string str = FileUpload(FileUploadCardImage, "IdentityCard");
            string str2 = "";
            info.ShopName = TextBoxShopName.Text;
            info.SalesRange = DropDownListRegionCode1.SelectedItem.Text + "," +
                              DropDownListRegionCode2.SelectedItem.Text + "," +
                              DropDownListRegionCode3.SelectedItem.Text;
            info.AddressValue = DropDownListRegionCode1.SelectedItem.Text + "," +
                                DropDownListRegionCode2.SelectedItem.Text + "," +
                                DropDownListRegionCode3.SelectedItem.Text;
            info.AddressCode = DropDownListRegionCode1.SelectedValue.Split(new[] { '/' })[0] + "," +
                               DropDownListRegionCode2.SelectedValue.Split(new[] { '/' })[0] + "," +
                               DropDownListRegionCode3.SelectedValue.Split(new[] { '/' })[0];
            info.Banner = "~/Shop/ShopAdmin/images/logodfwe.jpg";
            info.CollectCount = 0;
            info.ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            info.OpenTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            info.ModifyUser = LabelMemLoginID.Text;
            info.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            info.ShopRank = new Guid(DropDownListLv.SelectedValue);
            if (RadioButtonGr.Checked)
            {
                info.ShopType = 0;
            }
            else if (RadioButtonQy.Checked)
            {
                info.ShopType = 1;
            }
            info.Tel = TextBoxTel.Text.Trim();
            info.Phone = TextBoxPhone.Text.Trim();
            info.MainGoods = TextBoxMainGoods.Text.Trim();
            if (GetDropDownListShopCategoryCodeName() == "-1")
            {
                info.ShopCategory = "";
            }
            else
            {
                info.ShopCategory = GetDropDownListShopCategoryCodeName();
            }
            info.OrderID = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ShopInfo");
            info.MemLoginID = LabelMemLoginID.Text;
            info.IsAudit = 1;
            info.IsDeleted = 0;
            info.Name = LabelMemLoginID.Text;
            info.IdentityCard = TextBoxIdentityCard.Text;
            info.Address = TextBoxdetailAddress.Text;
            info.CardImage = str;
            info.TemplateType = "";
            info.RegistrationNum = "";
            info.CompanName = "";
            info.LegalPerson = "";
            info.RegisteredCapital = 0M;
            info.BusinessTerm = "";
            info.BusinessScope = "";
            info.BusinessLicense = str2;
            info.CompanIsAudit = -1;
            info.IdentityIsAudit = -1;
            info.Latitude = "";
            info.Longitude = "";
            try
            {
                info.ShopID = int.Parse(ShopSettings.GetValue("InitialShopID"));
            }
            catch
            {
                info.ShopID = 0x2710;
            }
            int shopIdMax = action.GetShopIdMax();
            if (shopIdMax >= info.ShopID)
            {
                info.ShopID = shopIdMax + 1;
            }
            info.ShopUrl = ShopSettings.GetValue("PersonShopUrl") + info.ShopID.ToString();
            if (action.RegistShopMember(info) > 0)
            {
                ShopSettings.GetValue("ApplyOpenShopIsEmail");
                string shopGuid = action.GetShopGuid(LabelMemLoginID.Text);
                base.Response.Redirect("UpdateShopURL.aspx?guid='" + shopGuid + "'&type=openshop");
            }
            else
            {
                MessageBox.Show("提交失败!");
            }
        }

        protected void BindRegionCategory(string RegionCategory)
        {
            int num;
            if (RegionCategory.Length >= 3)
            {
                for (num = 0; num < DropDownListRegionCode1.Items.Count; num++)
                {
                    if (DropDownListRegionCode1.Items[num].Value.StartsWith(RegionCategory.Substring(0, 3) + "/"))
                    {
                        DropDownListRegionCode1.SelectedValue = DropDownListRegionCode1.Items[num].Value;
                        break;
                    }
                }
                DropDownListRegionCode1_SelectedIndexChanged(null, null);
            }
            if (RegionCategory.Length >= 6)
            {
                num = 0;
                while (num < DropDownListRegionCode2.Items.Count)
                {
                    if (DropDownListRegionCode2.Items[num].Value.StartsWith(RegionCategory.Substring(0, 6) + "/"))
                    {
                        DropDownListRegionCode2.SelectedValue = DropDownListRegionCode2.Items[num].Value;
                        break;
                    }
                    num++;
                }
                DropDownListRegionCode2_SelectedIndexChanged(null, null);
            }
            if (RegionCategory.Length >= 9)
            {
                for (num = 0; num < DropDownListRegionCode3.Items.Count; num++)
                {
                    if (DropDownListRegionCode3.Items[num].Value.StartsWith(RegionCategory + "/"))
                    {
                        DropDownListRegionCode3.SelectedValue = DropDownListRegionCode3.Items[num].Value;
                        break;
                    }
                }
            }
        }

        protected void BindShopCategory(string ShopCategoryCode)
        {
            int num;
            if (ShopCategoryCode.Length >= 3)
            {
                for (num = 0; num < DropDownListShopCategoryCode1.Items.Count; num++)
                {
                    if (DropDownListShopCategoryCode1.Items[num].Value.StartsWith(ShopCategoryCode.Substring(0, 3) + "/"))
                    {
                        DropDownListShopCategoryCode1.SelectedValue = DropDownListShopCategoryCode1.Items[num].Value;
                        break;
                    }
                }
                DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
            }
            if (ShopCategoryCode.Length >= 6)
            {
                num = 0;
                while (num < DropDownListShopCategoryCode2.Items.Count)
                {
                    if (DropDownListShopCategoryCode2.Items[num].Value.StartsWith(ShopCategoryCode.Substring(0, 6) + "/"))
                    {
                        DropDownListShopCategoryCode2.SelectedValue = DropDownListShopCategoryCode2.Items[num].Value;
                        break;
                    }
                    num++;
                }
                DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
            }
            if (ShopCategoryCode.Length >= 9)
            {
                for (num = 0; num < DropDownListShopCategoryCode3.Items.Count; num++)
                {
                    if (DropDownListShopCategoryCode3.Items[num].Value.StartsWith(ShopCategoryCode.Substring(0, 9) + "/"))
                    {
                        DropDownListShopCategoryCode3.SelectedValue = DropDownListShopCategoryCode3.Items[num].Value;
                        break;
                    }
                }
            }
        }

        public void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_ShopInfo",
                                                                "  AND  ShopName='" + TextBoxShopName.Text.Trim() + "'")))
            {
                MessageBox.Show("店铺名称已经存在！");
            }
            else if (
                !string.IsNullOrEmpty(Common.Common.GetNameById("IdentityCard", "ShopNum1_ShopInfo",
                                                                "  AND  IdentityCard='" +
                                                                TextBoxIdentityCard.Text.Trim() + "'")))
            {
                MessageBox.Show("身份证已经存在！");
            }
            else
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "添加店铺成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "OpenShop.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                Add();
            }
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode1.SelectedValue.Split(new[] { '/' })[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                                   table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            DataTable table =
                ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(0, 0);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                               table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode2.SelectedValue.Split(new[] { '/' })[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                                   table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode2.Items.Clear();
            DropDownListShopCategoryCode2.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode1.SelectedValue.Split(new[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode1Bind()
        {
            DropDownListShopCategoryCode1.Items.Clear();
            DropDownListShopCategoryCode1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list =
                ((ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListShopCategoryCode1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                     list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode3.Items.Clear();
            DropDownListShopCategoryCode3.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode2.SelectedValue.Split(new[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string path = "~/ImgUpload/ShopCertification";
                string str3 = path + "/" + ImageName + LabelMemLoginID.Text + info.Extension;
                switch (ControlName.PostedFile.ContentType)
                {
                    case "image/bmp":
                    case "image/gif":
                    case "image/jpeg":
                    case "image/x-png":
                    case "image/png":
                    case "image/jpg":
                        try
                        {
                            if (!Directory.Exists(Page.Server.MapPath(path)))
                            {
                                Directory.CreateDirectory(Page.Server.MapPath(path));
                                ControlName.PostedFile.SaveAs(Page.Server.MapPath(str3));
                                return (ImageName + LabelMemLoginID.Text + info.Extension);
                            }
                            if (File.Exists(Page.Server.MapPath(str3)))
                            {
                                File.Delete(Page.Server.MapPath(str3));
                            }
                            ControlName.PostedFile.SaveAs(Page.Server.MapPath(str3));
                            return (ImageName + LabelMemLoginID.Text + info.Extension);
                        }
                        catch
                        {
                            MessageBox.Show("上传出错啦！");
                            return "0";
                        }
                }
                MessageBox.Show("图片格式不正确！");
                return "0";
            }
            return "0";
        }

        public string GetDropDownListShopCategoryCodeName()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                return (DropDownListShopCategoryCode1.SelectedItem.Text + "/" +
                        DropDownListShopCategoryCode2.SelectedItem.Text + "/" +
                        DropDownListShopCategoryCode3.SelectedItem.Text);
            }
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                return (DropDownListShopCategoryCode1.SelectedItem.Text + "/" +
                        DropDownListShopCategoryCode2.SelectedItem.Text);
            }
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode1.SelectedItem.Text;
            }
            return "-1";
        }

        public void GetMemberName()
        {
            LabelMemLoginID.Text =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemLoginIDByGuid(
                    HiddenFieldGuid.Value);
        }

        public void GetShopRank()
        {
            DataTable table = ((Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action()).Search(0);
            DropDownListLv.Items.Clear();
            DropDownListLv.Items.Add(new ListItem("-请选择-", "-1"));
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    DropDownListLv.Items.Add(new ListItem(row["Name"].ToString(), row["Guid"].ToString()));
                }
            }
        }

        private string method_5(string string_4)
        {
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.CheckShopName(string_4) > 0)
            {
                return "1";
            }
            return "0";
        }



        protected void RadioButtonGr_CheckedChanged(object sender, EventArgs e)
        {
            PanelBusinessLicense.Visible = false;
        }

        protected void RadioButtonQy_CheckedChanged(object sender, EventArgs e)
        {
            PanelBusinessLicense.Visible = true;
        }

        public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle,
                                        string emailTemplentGuid, string emailBody)
        {
            var action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            var memberEmailExec = new ShopNum1_MemberEmailExec
                {
                    ExtireTime = DateTime.Now.AddHours(24.0),
                    Email = Email,
                    Emailkey = Emailkey,
                    Guid = Guid.NewGuid(),
                    Isinvalid = 0,
                    MemberID = MemLoginID,
                    Phone = Phone,
                    Type = 0
                };
            if (action.MemberEmailInsert(memberEmailExec) > 0)
            {
                new SendEmail().Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
            }
        }

        public void SetShopCategoryCode()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode3.SelectedValue.Split(new[] { '/' })[0];
            }
            else if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode2.SelectedValue.Split(new[] { '/' })[0];
            }
            else if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode1.SelectedValue.Split(new[] { '/' })[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }

        public void SetShopRegionCode()
        {
            if ((Page.Request["OpenShop$ctl00$DropDownListRegionCode3"] != null) &&
                (Page.Request["OpenShop$ctl00$DropDownListRegionCode3"] != "-1"))
            {
                HiddenFieldRegionCode.Value =
                    Page.Request["OpenShop$ctl00$DropDownListRegionCode3"].Split(new[] { '/' })[0];
                HiddenFieldRegion.Value = Page.Request["HiddenRegion1"] + Page.Request["HiddenRegion2"] +
                                          Page.Request["HiddenRegion3"];
            }
            else if ((Page.Request["OpenShop$ctl00$DropDownListRegionCode2"] != null) &&
                     (Page.Request["OpenShop$ctl00$DropDownListRegionCode2"] != "-1"))
            {
                HiddenFieldRegionCode.Value =
                    Page.Request["OpenShop$ctl00$DropDownListRegionCode2"].Split(new[] { '/' })[0];
                HiddenFieldRegion.Value = Page.Request["HiddenRegion1"] + Page.Request["HiddenRegion2"];
            }
            else if ((Page.Request["OpenShop$ctl00$DropDownListRegionCode1"] != null) &&
                     (Page.Request["OpenShop$ctl00$DropDownListRegionCode1"] != "-1"))
            {
                HiddenFieldRegionCode.Value =
                    Page.Request["OpenShop$ctl00$DropDownListRegionCode1"].Split(new[] { '/' })[0];
                HiddenFieldRegion.Value = Page.Request["HiddenRegion1"];
            }
            else
            {
                HiddenFieldRegion.Value = "-1";
            }
        }
    }
}