using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.QRCode;
using ShopNum1.QRCode.Codec;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using Image = System.Web.UI.WebControls.Image;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopInfo_Settings : BaseShopWebControl
    {
        private Button button_0;
        private Button button_1;
        private HiddenField hiddenField_0;
        private HiddenField hiddenField_1;
        private HiddenField hiddenField_2;
        private HtmlAnchor htmlAnchor_0;
        private HtmlInputHidden htmlInputHidden_0;
        private HtmlInputHidden htmlInputHidden_1;
        private HtmlInputHidden htmlInputHidden_2;
        private Image image_0;
        private Image image_1;
        private Image image_2;
        private Image image_3;
        private Image image_4;
        private Label label_0;
        private Label label_1;
        private Repeater repeater_0;
        private string skinFilename = "S_ShopInfo_Settings.ascx";
        private string string_1;
        private string string_2;
        private TextBox textBox_0;
        private TextBox textBox_1;
        private TextBox textBox_10;
        private TextBox textBox_11;
        private TextBox textBox_2;
        private TextBox textBox_3;
        private TextBox textBox_4;
        private TextBox textBox_5;
        private TextBox textBox_6;
        private TextBox textBox_7;
        private TextBox textBox_8;
        private TextBox textBox_9;
        //private Label LabelReferral;

        public S_ShopInfo_Settings()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string imageSpec { get; set; }

        protected string ShopID { get; set; }

        public string StrPath { get; set; }

        protected void button_0_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void button_1_Click(object sender, EventArgs e)
        {
            CreateTwoDimension();
        }

        public void CreateChartImage(string saveImagePath, string URL, int Totalwidth, int Totalheight)
        {

            if (!string.IsNullOrEmpty(URL))
            {
                QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
                string a = "NUMERIC";
                if (a == "Byte")
                {
                    qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                }
                else
                {
                    if (a == "AlphaNumeric")
                    {
                        qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                    }
                    else
                    {
                        if (a == "Numeric")
                        {
                            qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                        }
                    }
                }

                try
                {
                    qRCodeEncoder.QRCodeScale=5;
                }
                catch (Exception)
                {
                    return;
                }
                try
                {
                    int qRCodeVersion = (int)Convert.ToInt16(7);
                    qRCodeEncoder.QRCodeVersion=qRCodeVersion;
                }
                catch (Exception)
                {
                    return;
                }
                string a2 = "H";
                if (a2 == "L")
                {
                    qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                }
                else
                {
                    if (a2 == "M")
                    {
                        qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    }
                    else
                    {
                        if (a2 == "Q")
                        {
                            qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                        }
                        else
                        {
                            if (a2 == "H")
                            {
                                qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                            }
                        }
                    }
                }
                new MemoryStream();
                System.Drawing.Image image = qRCodeEncoder.Encode(URL, Encoding.UTF8);
                Bitmap bitmap = new Bitmap(Totalwidth, Totalheight);
                Graphics graphics = Graphics.FromImage(bitmap);
                SolidBrush solidBrush = new SolidBrush(Color.White);
                graphics.DrawImage(image, 1, 1);
                if (File.Exists(this.Page.Server.MapPath(saveImagePath)))
                {
                    bitmap.Save(this.Page.Server.MapPath(saveImagePath));
                    solidBrush.Dispose();
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        public void CreateTwoDimension()
        {
            string uRL = string.Empty;
            uRL = GetUrl();
            try
            {
                new ChartImage();
                string path = "~/Shop/Shop/" + string_2.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                              string_1 + "/Themes/Skin_Default/images";
                if (!Directory.Exists(Page.Server.MapPath(path)))
                {
                    Directory.CreateDirectory(Page.Server.MapPath(path));
                }
                CreateChartImage(path + "/qrcode.png", uRL, 230, 230);
                image_0.ImageUrl = path + "/qrcode.png";
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(StrPath));
                DataRow row = set.Tables["Setting"].Rows[0];
                row["TwoCode"] = image_0.ImageUrl;
                set.AcceptChanges();
                set.WriteXml(Page.Server.MapPath(StrPath));
                MessageBox.Show("生成成功！");
            }
            catch
            {
                MessageBox.Show("生成失败！");
            }
        }

        public void GetBaoz()
        {
            DataTable table =
                ((Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action()).SearchShopEnsureListNew(base.MemLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                repeater_0.DataSource = table.DefaultView;
                repeater_0.DataBind();
            }
        }

        public string GetUrl()
        {
            DataTable shopIDByMemLoginID =
                Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action().GetShopIDByMemLoginID(base.MemLoginID);
            string str = string.Empty;
            string str2 = string.Empty;
            if (shopIDByMemLoginID.Rows.Count > 0)
            {
                str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
                str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
            }
            if (base.MemLoginID.ToUpper() != "C0000001".ToUpper())
            {
                return ("http://" + str + str2 + "/?category=9");
            }
            else
            {
                return ("http://" + str + str2 );
            }
           
        }

        protected override void InitializeSkin(Control skin)
        {
            htmlAnchor_0 = (HtmlAnchor) skin.FindControl("currLink");
            label_1 = (Label) skin.FindControl("LabelCurrLink");
            textBox_10 = (TextBox) skin.FindControl("TextBoxPhone");
            textBox_11 = (TextBox) skin.FindControl("TextBoxTel");
            hiddenField_0 = (HiddenField) skin.FindControl("HiddenFieldLogo");
            hiddenField_1 = (HiddenField) skin.FindControl("HiddenFieldBackGround");
            hiddenField_2 = (HiddenField) skin.FindControl("HiddenFieldSign");
            repeater_0 = (Repeater) skin.FindControl("RepeaterBaoz");
            textBox_1 = (TextBox) skin.FindControl("TextBoxName");
            textBox_0 = (TextBox) skin.FindControl("TextBoxShopName");
            textBox_2 = (TextBox) skin.FindControl("TextBoxMainGoods");
            textBox_3 = (TextBox) skin.FindControl("TextBoxLogo");
            textBox_4 = (TextBox) skin.FindControl("TextBoxBackGround");
            textBox_5 = (TextBox) skin.FindControl("TextBoxSign");
            textBox_6 = (TextBox) skin.FindControl("TextBoxIdentityCard");
            textBox_7 = (TextBox) skin.FindControl("TextBoxAdress");
            textBox_8 = (TextBox) skin.FindControl("TextBoxMemo");
            textBox_9 = (TextBox) skin.FindControl("TextBoxShopIntroduce");
            //LabelReferral = (Label)skin.FindControl("LabelReferral");
            button_0 = (Button) skin.FindControl("ButtonSave");
            button_0.Click += button_0_Click;
            htmlInputHidden_0 = (HtmlInputHidden) skin.FindControl("hid_Area");
            button_1 = (Button) skin.FindControl("ButtonUpdateTwo");
            button_1.Click += button_1_Click;
            image_0 = (Image) skin.FindControl("twoImage");
            image_1 = (Image) skin.FindControl("ImageMyLogo");
            image_2 = (Image) skin.FindControl("ImageBoxBackGround");
            image_3 = (Image) skin.FindControl("ImageSign");
            image_4 = (Image) skin.FindControl("ImageShopRank");
            label_0 = (Label) skin.FindControl("LabelShopRank");
            htmlInputHidden_1 = (HtmlInputHidden) skin.FindControl("HiddenShopName");
            htmlInputHidden_2 = (HtmlInputHidden) skin.FindControl("HiddenIdentityValue");
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            var action2 = (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataTable memLoginInfo = action.GetMemLoginInfo(base.MemLoginID);
            string_1 = action2.GetShopIDByMemLoginID(base.MemLoginID).Rows[0]["ShopID"].ToString();
            string_2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            imageSpec = "~/Shop/Shop/" + string_2.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                        string_1 + "/Site_Settings.xml";
            StrPath = imageSpec;
            image_0.ImageUrl = "~/Shop/Shop/" + string_2.Replace("-", "/") + "/" +
                               ShopSettings.GetValue("PersonShopUrl") + string_1 +
                               "/Themes/Skin_Default/images/qrcode.png";
            label_1.Text = GetUrl();
            htmlAnchor_0.HRef = GetUrl();
            GetBaoz();
            method_1();
        }

        protected void BindData()
        {
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath(StrPath));
            DataRow row = set.Tables["Setting"].Rows[0];
            row["ShopLogo"] = hiddenField_0.Value;
            row["ShopScroll"] = hiddenField_1.Value;
            set.AcceptChanges();
            set.WriteXml(Page.Server.MapPath(StrPath));
            var shopInfo = new ShopNum1_ShopInfo
            {
                Name = textBox_1.Text.Trim(),
                ShopName = textBox_0.Text.Trim(),
                MainGoods = textBox_2.Text.Trim(),
                Banner = hiddenField_2.Value,
                IdentityCard = textBox_6.Text.Trim(),
                Address = textBox_7.Text.Trim(),
                Memo = textBox_8.Text.Trim(),
                ShopIntroduce = textBox_9.Text.Trim(),
                MemLoginID = base.MemLoginID,
                Tel = textBox_11.Text.Trim(),
                Phone = textBox_10.Text.Trim()
            };
            if (htmlInputHidden_0.Value.IndexOf('|') > -1)
            {
                shopInfo.AddressCode = htmlInputHidden_0.Value.Split(new[] {'|'})[1];
                shopInfo.AddressValue = htmlInputHidden_0.Value.Split(new[] {'|'})[0];
            }
            try
            {
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                if (action.UpdateShop(shopInfo) > 0)
                {
                    MessageBox.Show("店铺更新成功！");
                }
                else
                {
                    MessageBox.Show("店铺更新失败！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("店铺更新失败！");
            }
        }

        protected void method_1()
        {
            DataTable dataInfoByMemLoginID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetDataInfoByMemLoginID(
                    base.MemLoginID);
            if ((dataInfoByMemLoginID != null) && (dataInfoByMemLoginID.Rows.Count > 0))     
            {
                htmlInputHidden_1.Value = dataInfoByMemLoginID.Rows[0]["ShopName"].ToString();
                textBox_0.Text = dataInfoByMemLoginID.Rows[0]["ShopName"].ToString();
                textBox_1.Text = dataInfoByMemLoginID.Rows[0]["Name"].ToString();
                textBox_2.Text = dataInfoByMemLoginID.Rows[0]["MainGoods"].ToString();
                textBox_6.Text = dataInfoByMemLoginID.Rows[0]["IdentityCard"].ToString();
                htmlInputHidden_2.Value = dataInfoByMemLoginID.Rows[0]["IdentityCard"].ToString();
                textBox_7.Text = dataInfoByMemLoginID.Rows[0]["Address"].ToString();
                textBox_8.Text = dataInfoByMemLoginID.Rows[0]["Memo"].ToString();
                textBox_9.Text = dataInfoByMemLoginID.Rows[0]["ShopIntroduce"].ToString();
                //LabelReferral.Text = dataInfoByMemLoginID.Rows[0]["Referral"].ToString();
                htmlInputHidden_0.Value = dataInfoByMemLoginID.Rows[0]["AddressValue"] + "|" +
                                          dataInfoByMemLoginID.Rows[0]["AddressCode"];
                image_3.ImageUrl = dataInfoByMemLoginID.Rows[0]["Banner"].ToString();
                textBox_5.Text = dataInfoByMemLoginID.Rows[0]["Banner"].ToString();
                hiddenField_2.Value = dataInfoByMemLoginID.Rows[0]["Banner"].ToString();
                textBox_10.Text = dataInfoByMemLoginID.Rows[0]["Phone"].ToString();
                textBox_11.Text = dataInfoByMemLoginID.Rows[0]["Tel"].ToString();
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(imageSpec));
                DataRow row = set.Tables["Setting"].Rows[0];
                image_1.ImageUrl = row["ShopLogo"].ToString();
                textBox_3.Text = row["ShopLogo"].ToString();
                hiddenField_0.Value = row["ShopLogo"].ToString();
                image_2.ImageUrl = row["ShopScroll"].ToString();
                textBox_4.Text = row["ShopScroll"].ToString();
                hiddenField_1.Value = row["ShopScroll"].ToString();
                
                DataTable shopRankByGuid =
                    ((Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action()).GetShopRankByGuid("'" +
                                                                                                 dataInfoByMemLoginID
                                                                                                     .Rows[0]["ShopRank"
                                                                                                     ] + "'");
                if ((shopRankByGuid != null) && (shopRankByGuid.Rows.Count > 0))
                {
                    label_0.Text = shopRankByGuid.Rows[0]["Name"].ToString();
                    image_4.ImageUrl = shopRankByGuid.Rows[0]["Pic"].ToString();
                }
            }
        }
    }
}