using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_AddSupply : BaseMemberWebControl
    {
        private Button ButtonGoBack;
        private Button ButtonTj;
        private FileUpload FileUploadImage;
        private HtmlInputHidden HiddenAddressCode;
        private HtmlInputHidden HiddenFieldRegionCode;
        private HtmlInputHidden HiddenFieldSupplyDemandCategory;
        private HtmlInputHidden HiddenGuid;
        private HtmlInputHidden HiddenImage;
        private Image ImageGq;
        private Label LabelTitle;
        private Panel PanelIsShow;
        private RadioButton RadioButtonGong;
        private RadioButton RadioButtonQiu;
        private TextBox TextBoxContactName;
        private TextBox TextBoxDescription;
        private TextBox TextBoxEmail;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxOtherContactWay;
        private TextBox TextBoxTel;
        private TextBox TextBoxTitle;
        private TextBox TextBoxValidTime;
        private TextBox TexteditorContent;
        private string skinFilename = "M_AddSupply.ascx";

        public M_AddSupply()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void Add()
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            var supplyDemand = new ShopNum1_SupplyDemand
            {
                AddressCode = HiddenFieldRegionCode.Value.Split(new[] {'|'})[1],
                AddressValue = AreaChineseName(HiddenFieldRegionCode.Value),
                CategoryCode = HiddenFieldSupplyDemandCategory.Value.Split(new[] {'|'})[1],
                CategoryName = CategoryChineseName(HiddenFieldSupplyDemandCategory.Value),
                ContactName = TextBoxContactName.Text.Trim(),
                Content = TexteditorContent.Text,
                Description = TextBoxDescription.Text.Trim(),
                Email = TextBoxEmail.Text.Trim()
            };
            string str = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
            if ((str != "1") && (str != "0"))
            {
                supplyDemand.Image = str;
            }
            else
            {
                supplyDemand.Image = "";
            }
            if (ShopSettings.GetValue("SupplyDemandIsAudit") == "0")
            {
                supplyDemand.IsAudit = 3;
            }
            else
            {
                supplyDemand.IsAudit = 0;
            }
            supplyDemand.IsRecommend = 0;
            supplyDemand.Keywords = TextBoxKeywords.Text.Trim();
            supplyDemand.MemberID = base.MemLoginID;
            supplyDemand.OrderID = GetMaxOrderID();
            supplyDemand.OtherContactWay = TextBoxOtherContactWay.Text.Trim();
            supplyDemand.ReleaseTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            supplyDemand.Tel = TextBoxTel.Text.Trim();
            supplyDemand.Title = TextBoxTitle.Text.Trim();
            if (RadioButtonGong.Checked)
            {
                supplyDemand.TradeType = 0;
            }
            else if (RadioButtonQiu.Checked)
            {
                supplyDemand.TradeType = 1;
            }
            supplyDemand.ValidTime = TextBoxValidTime.Text.Trim();
            try
            {
                if (action.Add(supplyDemand) > 0)
                {
                    MessageBox.Show("供求信息发布成功！");
                    Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("供求信息发布失败！");
            }
        }

        public string AreaChineseName(string strCode)
        {
            string str = string.Empty;
            if (strCode.IndexOf('|') != -1)
            {
                str = strCode.Split(new[] {'|'})[1];
            }
            var action = (ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action();
            string code = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str6 = string.Empty;
            string str7 = string.Empty;
            if (str.Length == 9)
            {
                code = str.Substring(0, 3);
                str3 = str.Substring(0, 6);
                str4 = str.Substring(0, 9);
            }
            else if (str.Length == 6)
            {
                code = str.Substring(0, 3);
                str3 = str.Substring(0, 6);
            }
            else if (str.Length == 3)
            {
                code = str.Substring(0, 3);
            }
            if (code != string.Empty)
            {
                DataTable regionByCode = action.GetRegionByCode(code);
                if ((regionByCode != null) && (regionByCode.Rows.Count > 0))
                {
                    str5 = regionByCode.Rows[0]["Name"].ToString();
                }
            }
            if (str3 != string.Empty)
            {
                DataTable table2 = action.GetRegionByCode(str3);
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    str6 = table2.Rows[0]["Name"].ToString();
                }
            }
            if (str4 != string.Empty)
            {
                DataTable table = action.GetRegionByCode(str4);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    str7 = table.Rows[0]["Name"].ToString();
                }
            }
            string str8 = string.Empty;
            if (str5 != string.Empty)
            {
                if (str8 == string.Empty)
                {
                    str8 = str5;
                }
                else
                {
                    str8 = str8 + " " + str5;
                }
            }
            if (str6 != string.Empty)
            {
                if (str8 == string.Empty)
                {
                    str8 = str8 + str6;
                }
                else
                {
                    str8 = str8 + " " + str6;
                }
            }
            if (!(str7 != string.Empty))
            {
                return str8;
            }
            if (str8 == string.Empty)
            {
                return (str8 + str7);
            }
            return (str8 + " " + str7);
        }

        private void ButtonTj_Click(object sender, EventArgs e)
        {
            if (HiddenGuid.Value == "0")
            {
                Add();
            }
            else
            {
                Edit(Page.Request.QueryString["ID"]);
            }
        }

        private void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_MySupply.aspx");
        }

        public string CategoryChineseName(string strCode)
        {
            string str = string.Empty;
            if (strCode.IndexOf('|') > -1)
            {
                str = strCode.Split(new[] {'|'})[1];
            }
            var action =
                (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            string code = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str6 = string.Empty;
            string str7 = string.Empty;
            if (str.Length == 9)
            {
                code = str.Substring(0, 3);
                str3 = str.Substring(0, 6);
                str4 = str.Substring(0, 9);
            }
            else if (str.Length == 6)
            {
                code = str.Substring(0, 3);
                str3 = str.Substring(0, 6);
            }
            else if (str.Length == 3)
            {
                code = str.Substring(0, 3);
            }
            if (code != string.Empty)
            {
                DataTable dataByCode = action.GetDataByCode(code);
                if ((dataByCode != null) && (dataByCode.Rows.Count > 0))
                {
                    str5 = dataByCode.Rows[0]["Name"].ToString();
                }
            }
            if (str3 != string.Empty)
            {
                DataTable table2 = action.GetDataByCode(str3);
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    str6 = table2.Rows[0]["Name"].ToString();
                }
            }
            if (str4 != string.Empty)
            {
                DataTable table = action.GetDataByCode(str4);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    str7 = table.Rows[0]["Name"].ToString();
                }
            }
            string str8 = string.Empty;
            if (str5 != string.Empty)
            {
                if (str8 == string.Empty)
                {
                    str8 = str5;
                }
                else
                {
                    str8 = str8 + "/" + str5;
                }
            }
            if (str6 != string.Empty)
            {
                if (str8 == string.Empty)
                {
                    str8 = str8 + str6;
                }
                else
                {
                    str8 = str8 + "/" + str6;
                }
            }
            if (!(str7 != string.Empty))
            {
                return str8;
            }
            if (str8 == string.Empty)
            {
                return (str8 + str7);
            }
            return (str8 + "/" + str7);
        }

        public void Clear()
        {
            TextBoxTitle.Text = "";
            TextBoxKeywords.Text = "";
            TextBoxTel.Text = "";
            TextBoxEmail.Text = "";
            TextBoxOtherContactWay.Text = "";
            TextBoxContactName.Text = "";
            TextBoxValidTime.Text = "";
            TextBoxDescription.Text = "";
            TexteditorContent.Text = "";
        }

        public void Edit(string ID)
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            var supplyDemand = new ShopNum1_SupplyDemand
            {
                AddressCode = HiddenFieldRegionCode.Value.Split(new[] {'|'})[1],
                AddressValue = AreaChineseName(HiddenFieldRegionCode.Value),
                CategoryCode = HiddenFieldSupplyDemandCategory.Value.Split(new[] {'|'})[1],
                CategoryName = CategoryChineseName(HiddenFieldSupplyDemandCategory.Value),
                ContactName = TextBoxContactName.Text.Trim(),
                Content = TexteditorContent.Text,
                Description = TextBoxDescription.Text.Trim(),
                Email = TextBoxEmail.Text.Trim(),
                ID = Convert.ToInt32(ID)
            };
            if (FileUploadImage.HasFile)
            {
                string str = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
                if ((str != "1") && (str != "0"))
                {
                    supplyDemand.Image = str;
                }
                else
                {
                    supplyDemand.Image = HiddenImage.Value;
                }
            }
            else
            {
                supplyDemand.Image = HiddenImage.Value;
            }
            supplyDemand.Keywords = TextBoxKeywords.Text.Trim();
            supplyDemand.OtherContactWay = TextBoxOtherContactWay.Text.Trim();
            supplyDemand.Tel = TextBoxTel.Text.Trim();
            supplyDemand.Title = TextBoxTitle.Text.Trim();
            if (RadioButtonGong.Checked)
            {
                supplyDemand.TradeType = 0;
            }
            else if (RadioButtonQiu.Checked)
            {
                supplyDemand.TradeType = 1;
            }
            supplyDemand.ValidTime = TextBoxValidTime.Text.Trim();
            try
            {
                if (action.Update(supplyDemand) > 0)
                {
                    Page.Response.Redirect("M_MySupply.aspx");
                }
                else
                {
                    MessageBox.Show("编辑失败！");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("编辑失败！" + exception.Message);
            }
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/ShopCertification";
                string filepath = str2 + "/" + ImageName + info.Extension;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                {
                    return filepath;
                }
                MessageBox.Show(retstr);
                return "0";
            }
            return "1";
        }

        public void GetInfo(string ID)
        {
            DataTable table =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action()).SearchByID(
                    ID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                HiddenGuid.Value = table.Rows[0]["CategoryCode"].ToString();
                HiddenAddressCode.Value = table.Rows[0]["AddressCode"].ToString();
                TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
                if (table.Rows[0]["TradeType"].ToString() == "0")
                {
                    RadioButtonGong.Checked = true;
                }
                else if (table.Rows[0]["TradeType"].ToString() == "1")
                {
                    RadioButtonQiu.Checked = true;
                }
                TextBoxTel.Text = table.Rows[0]["Tel"].ToString();
                TextBoxEmail.Text = table.Rows[0]["Email"].ToString();
                TextBoxOtherContactWay.Text = table.Rows[0]["OtherContactWay"].ToString();
                TextBoxContactName.Text = table.Rows[0]["ContactName"].ToString();
                TextBoxValidTime.Text = table.Rows[0]["ValidTime"].ToString();
                TextBoxKeywords.Text = table.Rows[0]["Keywords"].ToString();
                TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
                TexteditorContent.Text = table.Rows[0]["Content"].ToString();
                HiddenImage.Value = table.Rows[0]["Image"].ToString();
                ImageGq.ImageUrl = table.Rows[0]["Image"].ToString();
                if ((table.Rows[0]["IsAudit"].ToString() != "2") && !(table.Rows[0]["IsAudit"].ToString() == "3"))
                {
                }
            }
        }

        public int GetMaxOrderID()
        {
            int num = 0;
            string str = Common.Common.GetNameById("MAX(OrderID)", "ShopNum1_SupplyDemand", "  AND  1=1  ");
            if (!string.IsNullOrEmpty(str))
            {
                num = Convert.ToInt32(str) + 1;
            }
            return num;
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            RadioButtonGong = (RadioButton) skin.FindControl("RadioButtonGong");
            RadioButtonQiu = (RadioButton) skin.FindControl("RadioButtonQiu");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            TextBoxTel = (TextBox) skin.FindControl("TextBoxTel");
            TextBoxEmail = (TextBox) skin.FindControl("TextBoxEmail");
            TextBoxOtherContactWay = (TextBox) skin.FindControl("TextBoxOtherContactWay");
            TextBoxContactName = (TextBox) skin.FindControl("TextBoxContactName");
            TextBoxValidTime = (TextBox) skin.FindControl("TextBoxValidTime");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            FileUploadImage = (FileUpload) skin.FindControl("FileUploadImage");
            TexteditorContent = (TextBox) skin.FindControl("TexteditorContent");
            ButtonGoBack = (Button) skin.FindControl("ButtonGoBack");
            ButtonGoBack.Click += ButtonGoBack_Click;
            HiddenFieldSupplyDemandCategory = (HtmlInputHidden) skin.FindControl("HiddenFieldSupplyDemandCategory");
            HiddenFieldRegionCode = (HtmlInputHidden) skin.FindControl("HiddenFieldRegionCode");
            HiddenGuid = (HtmlInputHidden) skin.FindControl("HiddenGuid");
            HiddenAddressCode = (HtmlInputHidden) skin.FindControl("HiddenAddressCode");
            HiddenImage = (HtmlInputHidden) skin.FindControl("HiddenImage");
            ImageGq = (Image) skin.FindControl("ImageGq");
            ButtonTj = (Button) skin.FindControl("ButtonTj");
            ButtonTj.Click += ButtonTj_Click;
            PanelIsShow = (Panel) skin.FindControl("PanelIsShow");
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            if (Page.Request.QueryString["ID"] != null)
            {
                HiddenGuid.Value = Page.Request.QueryString["ID"];
                GetInfo(Page.Request.QueryString["ID"]);
                PanelIsShow.Visible = true;
                LabelTitle.Text = "编辑供求信息";
            }
            else
            {
                HiddenGuid.Value = "0";
                LabelTitle.Text = "发布供求信息";
            }
        }
    }
}