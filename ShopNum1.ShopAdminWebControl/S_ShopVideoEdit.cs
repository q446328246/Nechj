using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopVideoEdit : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private DropDownList DropDownListCategory;
        private FileUpload FileUploadImage;
        private HiddenField HiddenFieldGuid;
        private HiddenField HiddenFieldImage;
        private Image ImageVideo;
        private Label LabelTitle;
        private Panel PanelShow;
        private TextBox TextBoxContent;
        private TextBox TextBoxDescription;
        private TextBox TextBoxKeyWords;
        private TextBox TextBoxOrderID;
        private TextBox TextBoxTitle;
        private TextBox TextBoxVideoAdd;
        private string skinFilename = "S_ShopVideoEdit.ascx";

        public S_ShopVideoEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                method_1();
            }
            else
            {
                BindData();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopVideo.aspx");
        }

        protected string FileUpload(FileUpload ControlName, string ImageName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/ReportImage";
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
            DataTable videoInfo =
                ((Shop_Video_Action) LogicFactory.CreateShop_Video_Action()).GetVideoInfo(
                    Page.Request.QueryString["guid"]);
            if ((videoInfo != null) && (videoInfo.Rows.Count > 0))
            {
                TextBoxTitle.Text = videoInfo.Rows[0]["Title"].ToString();
                DropDownListCategory.SelectedValue = videoInfo.Rows[0]["CategoryGuid"].ToString();
                TextBoxVideoAdd.Text = videoInfo.Rows[0]["VideoAdd"].ToString();
                ImageVideo.ImageUrl = videoInfo.Rows[0]["ImgAdd"].ToString();
                HiddenFieldImage.Value = videoInfo.Rows[0]["ImgAdd"].ToString();
                PanelShow.Visible = true;
                TextBoxOrderID.Text = videoInfo.Rows[0]["OrderID"].ToString();
                TextBoxKeyWords.Text = videoInfo.Rows[0]["KeyWords"].ToString();
                TextBoxDescription.Text = videoInfo.Rows[0]["Description"].ToString();
                TextBoxContent.Text = videoInfo.Rows[0]["Content"].ToString();
            }
        }

        public int GetOrderID()
        {
            try
            {
                var action = (Shop_Video_Action) LogicFactory.CreateShop_Video_Action();
                return (Convert.ToInt32(action.GetMaxOrderID(base.MemLoginID)) + 1);
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public string GetShopID()
        {
            DataTable shopIDByMemLoginID =
                Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action().GetShopIDByMemLoginID(base.MemLoginID);
            if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
            {
                return "";
            }
            return shopIDByMemLoginID.Rows[0]["ShopID"].ToString();
        }

        public void GetShopVideoCategory()
        {
            DataTable videoCategoryList =
                ((Shop_VideoCategory_Action) LogicFactory.CreateShop_VideoCategory_Action()).GetVideoCategoryList(
                    base.MemLoginID, "1");
            DropDownListCategory.Items.Clear();
            DropDownListCategory.Items.Add(new ListItem("-全部-", "-1"));
            if ((videoCategoryList != null) && (videoCategoryList.Rows.Count > 0))
            {
                foreach (DataRow row in videoCategoryList.Rows)
                {
                    DropDownListCategory.Items.Add(new ListItem(row["Name"].ToString(), row["Guid"].ToString()));
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            DropDownListCategory = (DropDownList) skin.FindControl("DropDownListCategory");
            TextBoxVideoAdd = (TextBox) skin.FindControl("TextBoxVideoAdd");
            FileUploadImage = (FileUpload) skin.FindControl("FileUploadImage");
            PanelShow = (Panel) skin.FindControl("PanelShow");
            ImageVideo = (Image) skin.FindControl("ImageVideo");
            TextBoxOrderID = (TextBox) skin.FindControl("TextBoxOrderID");
            TextBoxKeyWords = (TextBox) skin.FindControl("TextBoxKeyWords");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            HiddenFieldImage = (HiddenField) skin.FindControl("HiddenFieldImage");
            TextBoxOrderID.Text = GetOrderID().ToString();
            GetShopVideoCategory();
            if (Page.Request.QueryString["guid"] != null)
            {
                GetDataInfo();
                LabelTitle.Text = "编辑视频";
            }
            else
            {
                LabelTitle.Text = "添加视频";
            }
        }

        protected void BindData()
        {
            Exception exception;
            try
            {
                string str = Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo",
                    "   AND  MemLoginID ='" + base.MemLoginID + "'  ");
                if (!string.IsNullOrEmpty(str))
                {
                    int num = 0;
                    string str2 = Common.Common.GetNameById("MaxVedioCount", "ShopNum1_ShopRank",
                        "   AND   Guid ='" + str + "'  ");
                    if (!string.IsNullOrEmpty(str2))
                    {
                        num = Convert.ToInt32(str2);
                    }
                    int num2 = 0;
                    string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Video",
                        "   AND     MemLoginID ='" + base.MemLoginID + "'  ");
                    if (!string.IsNullOrEmpty(str3))
                    {
                        num2 = Convert.ToInt32(str3);
                    }
                    if (num2 >= num)
                    {
                        MessageBox.Show("店铺添加视频数量已经达到最大值，如要添加更多视频，请及时升级店铺等级！");
                        return;
                    }
                }
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageBox.Show(exception.Message);
                return;
            }
            var action = (Shop_Video_Action) LogicFactory.CreateShop_Video_Action();
            var video = new ShopNum1_Shop_Video
            {
                CategoryGuid = DropDownListCategory.SelectedValue,
                Content = TextBoxContent.Text.Trim(),
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                CreateUser = base.MemLoginID,
                Description = TextBoxDescription.Text.Trim(),
                Guid = Guid.NewGuid(),
                ImgAdd = FileUpload(FileUploadImage, Guid.NewGuid().ToString()),
                IsAudit = 0,
                IsRecommend = 0,
                KeyWords = TextBoxKeyWords.Text.Trim(),
                MemLoginID = base.MemLoginID,
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ModifyUser = base.MemLoginID,
                OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                ShopID = GetShopID(),
                Title = TextBoxTitle.Text.Trim(),
                VideoAdd = TextBoxVideoAdd.Text.Trim(),
                BroadcastCount = 0
            };
            try
            {
                if (action.AddVideoInfo(video) > 0)
                {
                    MessageBox.Show("添加成功！");
                    TextBoxOrderID.Text = GetOrderID().ToString();
                    DropDownListCategory.SelectedValue = "-1";
                    TextBoxContent.Text = "";
                    TextBoxDescription.Text = "";
                    TextBoxKeyWords.Text = "";
                    TextBoxTitle.Text = "";
                    TextBoxVideoAdd.Text = "";
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                MessageBox.Show("添加失败！");
            }
        }

        protected void method_1()
        {
            var action = (Shop_Video_Action) LogicFactory.CreateShop_Video_Action();
            var video = new ShopNum1_Shop_Video
            {
                CategoryGuid = DropDownListCategory.SelectedValue,
                Content = TextBoxContent.Text.Trim(),
                Description = TextBoxDescription.Text.Trim(),
                Guid = new Guid(Page.Request.QueryString["guid"])
            };
            if (FileUploadImage.HasFile)
            {
                video.ImgAdd = FileUpload(FileUploadImage, Guid.NewGuid().ToString());
            }
            else
            {
                video.ImgAdd = HiddenFieldImage.Value;
            }
            video.KeyWords = TextBoxKeyWords.Text.Trim();
            video.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            video.ModifyUser = base.MemLoginID;
            video.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
            video.Title = TextBoxTitle.Text.Trim();
            video.VideoAdd = TextBoxVideoAdd.Text.Trim();
            try
            {
                if (action.UpdateVideoInfo(video) > 0)
                {
                    MessageBox.Show("修改成功！");
                    Page.Response.Redirect("S_ShopVideo.aspx");
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
}