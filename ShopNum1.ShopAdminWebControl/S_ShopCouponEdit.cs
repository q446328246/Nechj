using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopCouponEdit : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private CheckBox CheckBoxIsShow;
        private DropDownList DropDownListType;
        private FileUpload FileUploadImgPath;
        private Image InputImgPath;
        private Label LabelTitle;
        private Panel PanelShowImage;
        private TextBox TextBoxCouponName;
        private TextBox TextBoxEndTime;
        private TextBox TextBoxSaleTitle;
        private TextBox TextBoxStartTime;
        private TextBox TexteditorContent;
        private HtmlInputHidden hid_Area;
        private HtmlInputHidden hid_AreaCode;
        private HtmlInputHidden htmlInputHidden_2;
        private string skinFilename = "S_ShopCouponEdit.ascx";

        public S_ShopCouponEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindType()
        {
            DataTable table = ((Shop_CouponType_Action) LogicFactory.CreateShop_CouponType_Action()).search(-1, 1);
            DropDownListType.Items.Clear();
            DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
            foreach (DataRow row in table.Rows)
            {
                DropDownListType.Items.Add(new ListItem(row["Name"].ToString(), row["id"].ToString()));
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                BindData();
            }
            else
            {
                method_1();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopCoupon.aspx");
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

        public void GetDataInfo()
        {
            DataTable couponInfoById =
                ((Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action()).GetCouponInfoById(
                    Page.Request.QueryString["guid"]);
            if ((couponInfoById != null) && (couponInfoById.Rows.Count > 0))
            {
                TextBoxSaleTitle.Text = couponInfoById.Rows[0]["SaleTitle"].ToString();
                TextBoxCouponName.Text = couponInfoById.Rows[0]["CouponName"].ToString();
                DropDownListType.SelectedValue = couponInfoById.Rows[0]["Type"].ToString();
                if (couponInfoById.Rows[0]["IsShow"].ToString() == "1")
                {
                    CheckBoxIsShow.Checked = true;
                }
                else
                {
                    CheckBoxIsShow.Checked = false;
                }
                TextBoxStartTime.Text = couponInfoById.Rows[0]["StartTime"].ToString();
                TextBoxEndTime.Text = couponInfoById.Rows[0]["EndTime"].ToString();
                TexteditorContent.Text = couponInfoById.Rows[0]["Content"].ToString();
                PanelShowImage.Visible = true;
                InputImgPath.ImageUrl = couponInfoById.Rows[0]["ImgPath"].ToString();
                htmlInputHidden_2.Value = couponInfoById.Rows[0]["ImgPath"].ToString();
                hid_Area.Value = couponInfoById.Rows[0]["AdressName"] + "|" +
                                 couponInfoById.Rows[0]["AdressCode"];
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            TextBoxSaleTitle = (TextBox) skin.FindControl("TextBoxSaleTitle");
            TextBoxCouponName = (TextBox) skin.FindControl("TextBoxCouponName");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            CheckBoxIsShow = (CheckBox) skin.FindControl("CheckBoxIsShow");
            TextBoxStartTime = (TextBox) skin.FindControl("TextBoxStartTime");
            TextBoxEndTime = (TextBox) skin.FindControl("TextBoxEndTime");
            FileUploadImgPath = (FileUpload) skin.FindControl("FileUploadImgPath");
            TexteditorContent = (TextBox) skin.FindControl("TexteditorContent");
            hid_Area = (HtmlInputHidden) skin.FindControl("hid_Area");
            hid_AreaCode = (HtmlInputHidden) skin.FindControl("hid_AreaCode");
            htmlInputHidden_2 = (HtmlInputHidden) skin.FindControl("hid_Image");
            PanelShowImage = (Panel) skin.FindControl("PanelShowImage");
            InputImgPath = (Image) skin.FindControl("InputImgPath");
            BindType();
            if (Page.Request.QueryString["guid"] != null)
            {
                LabelTitle.Text = "编辑优惠券";
                GetDataInfo();
            }
            else
            {
                LabelTitle.Text = "添加优惠券";
            }
        }

        protected void BindData()
        {
            if (hid_Area.Value.IndexOf('|') == -1)
            {
                MessageBox.Show("请选择地区");
            }
            else
            {
                var action = (Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action();
                var coupon = new ShopNum1_Shop_Coupon
                {
                    AdressCode = hid_Area.Value.Split(new[] {'|'})[1],
                    AdressName = hid_Area.Value.Split(new[] {'|'})[0],
                    Content = TexteditorContent.Text,
                    CouponName = TextBoxCouponName.Text.Trim(),
                    EndTime = Convert.ToDateTime(TextBoxEndTime.Text.Trim()),
                    Guid = new Guid(Page.Request.QueryString["guid"])
                };
                if (FileUploadImgPath.HasFile)
                {
                    coupon.ImgPath = FileUpload(FileUploadImgPath, Guid.NewGuid().ToString());
                }
                else
                {
                    coupon.ImgPath = htmlInputHidden_2.Value;
                }
                if (CheckBoxIsShow.Checked)
                {
                    coupon.IsShow = 1;
                }
                else
                {
                    coupon.IsShow = 0;
                }
                coupon.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                coupon.ModifyUser = base.MemLoginID;
                coupon.SaleTitle = TextBoxSaleTitle.Text.Trim();
                coupon.ShopName = ShopName(base.MemLoginID);
                coupon.StartTime = Convert.ToDateTime(TextBoxStartTime.Text.Trim());
                coupon.Type = Convert.ToInt32(DropDownListType.SelectedValue);
                try
                {
                    if (action.UpdateCoupon1(coupon) > 0)
                    {
                        MessageBox.Show("编辑成功！");
                    }
                    else
                    {
                        MessageBox.Show("编辑失败！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("编辑失败！");
                }
            }
        }

        protected void method_1()
        {
            if (hid_Area.Value.IndexOf('|') == -1)
            {
                MessageBox.Show("请选择地区");
            }
            else
            {
                var action = (Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action();
                var coupon = new ShopNum1_Shop_Coupon
                {
                    AdressCode = hid_Area.Value.Split(new[] {'|'})[1],
                    AdressName = hid_Area.Value.Split(new[] {'|'})[0],
                    BrowserCount = 0,
                    Content = TexteditorContent.Text,
                    CouponName = TextBoxCouponName.Text.Trim(),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    CreateUser = base.MemLoginID,
                    DownloadCount = 0,
                    EndTime = Convert.ToDateTime(TextBoxEndTime.Text.Trim()),
                    Guid = Guid.NewGuid(),
                    ImgPath = FileUpload(FileUploadImgPath, Guid.NewGuid().ToString())
                };
                if (ShopSettings.GetValue("AddCouponIsAudit") == "1")
                {
                    coupon.IsAudit = 0;
                }
                else
                {
                    coupon.IsAudit = 1;
                }
                coupon.IsDeleted = 0;
                coupon.IsEffective = 1;
                coupon.IsHot = 0;
                coupon.IsNew = 1;
                coupon.IsRecommend = 0;
                if (CheckBoxIsShow.Checked)
                {
                    coupon.IsShow = 1;
                }
                else
                {
                    coupon.IsShow = 0;
                }
                coupon.MemLoginID = base.MemLoginID;
                coupon.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                coupon.ModifyUser = base.MemLoginID;
                coupon.SaleTitle = TextBoxSaleTitle.Text.Trim();
                coupon.ShopName = ShopName(base.MemLoginID);
                coupon.StartTime = Convert.ToDateTime(TextBoxStartTime.Text.Trim());
                coupon.Type = Convert.ToInt32(DropDownListType.SelectedValue);
                coupon.UseCount = 0;
                try
                {
                    if (action.Add(coupon) > 0)
                    {
                        Page.Response.Redirect("S_ShopCoupon.aspx");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败！");
                }
            }
        }

        public string ShopName(string memloginID)
        {
            string str = string.Empty;
            DataTable table =
                ((Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action()).CheckMemLoginID(memloginID);
            if ((table.Rows.Count > 0) && (table.Rows.Count < 2))
            {
                str = table.Rows[0]["ShopName"].ToString();
            }
            return str;
        }
    }
}