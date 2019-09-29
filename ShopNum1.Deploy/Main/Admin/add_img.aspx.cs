using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class add_img : PageBase, IRequiresSessionState
    {
        protected string strSapce = "　　";

        public string ImageSpec { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindImageCategory();
                BindImageType();
                BindCheckBoxListImageSpec("Product");
            }
        }

        protected void Add(string fileName)
        {
            var image = new ShopNum1_Image
                {
                    Guid = Guid.NewGuid(),
                    Name = textBoxName.Text.Trim(),
                    ImageType = DropDownListImageType.SelectedValue,
                    ImagePath = fileName,
                    Description = textBoxDescription.Text.Trim(),
                    UseTimes = 0,
                    CreateUser = "admin",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
            var action = (ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action();
            if (action.Add(image, DropDownListImgCategory2.SelectedValue) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),"name", "<script>alert('添加成功');window.parent.location.reload();</script>");
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo1");
            }
        }

        protected void BindCheckBoxListImageSpec(string strType)
        {
            CheckBoxListImageSpec.Items.Clear();
            CheckBoxListImageSpec.Visible = true;
            string str = "Skin_Default";
            ImageSpec = "Themes/" + str + "/ImageSpec.xml";
            //using (
            //    IEnumerator enumerator =
            //        XmlOperator.GetXmlData(base.Server.MapPath("../" + this.ImageSpec), "ImageSpec").Tables[0].Rows
            //                                                                                                  .GetEnumerator
            //            ())
            //{
            IEnumerator enumerator =
                XmlOperator.GetXmlData(base.Server.MapPath("../" + ImageSpec), "ImageSpec").Tables[0].Rows.GetEnumerator
                    ();
            while (enumerator.MoveNext())
            {
                var current = (DataRow) enumerator.Current;
                var item = new ListItem();
                if (strType == "Product")
                {
                    if (current["name"].ToString().Trim() == "Product")
                    {
                        item.Text = current["Width"].ToString().Trim() + "*" + current["Height"].ToString().Trim();
                        item.Value = current["Width"].ToString().Trim() + "*" + current["Height"].ToString().Trim();
                        CheckBoxListImageSpec.Items.Add(item);
                    }
                }
                else
                {
                    if (strType == "Brand")
                    {
                        if (current["name"].ToString().Trim() == "Brand")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "GuidBuy")
                    {
                        if (current["name"].ToString().Trim() == "GuidBuy")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "Pack")
                    {
                        if (current["name"].ToString().Trim() == "Pack")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "BlessCard")
                    {
                        if (current["name"].ToString().Trim() == "BlessCard")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "Logo")
                    {
                        if (current["name"].ToString().Trim() == "Logo")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "Article")
                    {
                        if (current["name"].ToString().Trim() == "Article")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "Control")
                    {
                        if (current["name"].ToString().Trim() == "Control")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (strType == "Video")
                    {
                        if (current["name"].ToString().Trim() == "Video")
                        {
                            item.Text = current["Width"].ToString().Trim() + "*" +
                                        current["Height"].ToString().Trim();
                            item.Value = current["Width"].ToString().Trim() + "*" +
                                         current["Height"].ToString().Trim();
                            CheckBoxListImageSpec.Items.Add(item);
                        }
                        continue;
                    }
                    if (((strType == "Advertisement") || (strType == "Icon")) &&
                        ((current["name"].ToString().Trim() == "Icon") ||
                         (current["name"].ToString().Trim() == "Advertisement")))
                    {
                        goto Label_0836;
                    }
                }
            }
            goto Label_085C;
            Label_0836:
            CheckBoxListImageSpec.Visible = false;
            //}
            Label_085C:
            if (CheckBoxListImageSpec.Items.Count > 0)
            {
                CheckBoxListImageSpec.Items[0].Selected = true;
            }
        }

        protected void BindImageCategory()
        {
            DropDownListImgCategory2.Items.Clear();
            var item = new ListItem
                {
                    Text = "选择分类",
                    Value = "0"
                };
            DropDownListImgCategory2.Items.Add(item);
            var action = (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListImgCategory2.Items.Add(item2);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_5(table);
                }
            }
        }

        protected void BindImageType()
        {
            DropDownListImageType.Items.Clear();
            DropDownListImageType.Items.Add(new ListItem("商品图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4941"));
            DropDownListImageType.Items.Add(new ListItem("品牌图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4942"));
            DropDownListImageType.Items.Add(new ListItem("导购图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4943"));
            DropDownListImageType.Items.Add(new ListItem("包装图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4944"));
            DropDownListImageType.Items.Add(new ListItem("贺卡图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4945"));
            DropDownListImageType.Items.Add(new ListItem("Logo图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4947"));
            DropDownListImageType.Items.Add(new ListItem("资讯图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4948"));
            DropDownListImageType.Items.Add(new ListItem("控件图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4950"));
            DropDownListImageType.Items.Add(new ListItem("视频图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4951"));
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFile)
            {
                string contentType = FileUploadImage.PostedFile.ContentType;
                if (((((contentType == "image/bmp") || (contentType == "image/png")) ||
                      ((contentType == "image/gif") || (contentType == "image/pjpeg"))) ||
                     ((contentType == "image/x-png") || (contentType == "image/pjpeg"))) ||
                    (contentType == "image/jpeg"))
                {
                    string fileName = Operator.FilterString(FileUploadImage.PostedFile.FileName);
                    var random = new Random();
                    string str16 = (10 + random.Next(70)).ToString();
                    Thread.Sleep(20);
                    string str12 = DateTime.Now.ToString("yyyyMMddHHmmss") + str16;
                    var info = new FileInfo(fileName);
                    string str4 = str12 + info.Extension;
                    string path = base.Server.MapPath("~/ImgUpload/" + str4);
                    string str11 = "~/ImgUpload/" + str4;
                    if (!File.Exists(path))
                    {
                        try
                        {
                            string str5;
                            string str7;
                            switch (ShopSettings.GetValue("IfSetWaterMark"))
                            {
                                case "0":
                                    FileUploadImage.SaveAs(path);
                                    break;

                                case "1":
                                    {
                                        str5 = base.Server.MapPath("~/ImgUpload/O_" + str4);
                                        FileUploadImage.SaveAs(str5);
                                        string addText = ShopSettings.GetValue("WaterMarkWords");
                                        str7 = ShopSettings.GetValue("WordsWaterMarkPosition");
                                        string fontType = ShopSettings.GetValue("WaterMarkWordsFont");
                                        float fontSize =
                                            Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
                                        string fontColor = ShopSettings.GetValue("WaterMarkWordsColor");
                                        ImageOperator.CreateWater(str5, path, addText, str7, fontType, fontSize,
                                                                  fontColor);
                                        File.Delete(str5);
                                        break;
                                    }
                                case "2":
                                    {
                                        str5 = base.Server.MapPath("~/ImgUpload/O_" + str4);
                                        FileUploadImage.SaveAs(str5);
                                        string waterSourcePath = ShopSettings.GetValue("WaterMarkOriginalImge");
                                        waterSourcePath = base.Server.MapPath("~/ImgUpload/" + waterSourcePath);
                                        str7 = ShopSettings.GetValue("WaterMarkImagePosition");
                                        ImageOperator.CreateWaterPic(str5, path, waterSourcePath, str7);
                                        File.Delete(str5);
                                        break;
                                    }
                            }
                            Add(str11);
                            string str13 = "s_" + str12 + info.Extension;
                            string thumbnailPath = base.Server.MapPath("~/ImgUpload/" + str13);
                            for (int i = 0; i < CheckBoxListImageSpec.Items.Count; i++)
                            {
                                if (!CheckBoxListImageSpec.Items[i].Selected)
                                {
                                    goto Label_0329;
                                }
                                string[] strArray = CheckBoxListImageSpec.Items[i].Value.Split(new[] {'*'});
                                int width = Convert.ToInt32(strArray[0]);
                                int height = Convert.ToInt32(strArray[1]);
                                ImageOperator.CreateThumbnailAuto(path, thumbnailPath, width, height);
                            }
                            return;
                            Label_0329:
                            File.Copy(path, thumbnailPath);
                        }
                        catch (Exception)
                        {
                            MessageShow.Visible = true;
                            MessageShow.ShowMessage("UpdateNo1");
                        }
                    }
                    else
                    {
                        MessageShow.Visible = true;
                        MessageShow.ShowMessage("UpdateNo2");
                    }
                }
                else
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("UpdateNo3");
                }
            }
            else
            {
                MessageBox.Show("请上传图片！");
            }
        }

        protected void butExit_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.HasFile)
            {
                string contentType = FileUploadImage.PostedFile.ContentType;
                if (((((contentType == "image/bmp") || (contentType == "image/png")) ||
                      ((contentType == "image/gif") || (contentType == "image/pjpeg"))) ||
                     ((contentType == "image/x-png") || (contentType == "image/pjpeg"))) ||
                    (contentType == "image/jpeg"))
                {
                    string fileName = Operator.FilterString(FileUploadImage.PostedFile.FileName);
                    var random = new Random();
                    string str16 = (10 + random.Next(70)).ToString();
                    Thread.Sleep(20);
                    string str12 = DateTime.Now.ToString("yyyyMMddHHmmss") + str16;
                    var info = new FileInfo(fileName);
                    string str4 = str12 + info.Extension;
                    string path = base.Server.MapPath("~/ImgUpload/" + str4);
                    string str11 = "~/ImgUpload/" + str4;
                    if (!File.Exists(path))
                    {
                        try
                        {
                            string str5;
                            string str7;
                            switch (ShopSettings.GetValue("IfSetWaterMark"))
                            {
                                case "0":
                                    FileUploadImage.SaveAs(path);
                                    break;

                                case "1":
                                    {
                                        str5 = base.Server.MapPath("~/ImgUpload/O_" + str4);
                                        FileUploadImage.SaveAs(str5);
                                        string addText = ShopSettings.GetValue("WaterMarkWords");
                                        str7 = ShopSettings.GetValue("WordsWaterMarkPosition");
                                        string fontType = ShopSettings.GetValue("WaterMarkWordsFont");
                                        float fontSize =
                                            Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
                                        string fontColor = ShopSettings.GetValue("WaterMarkWordsColor");
                                        ImageOperator.CreateWater(str5, path, addText, str7, fontType, fontSize,
                                                                  fontColor);
                                        File.Delete(str5);
                                        break;
                                    }
                                case "2":
                                    {
                                        str5 = base.Server.MapPath("~/ImgUpload/O_" + str4);
                                        FileUploadImage.SaveAs(str5);
                                        string waterSourcePath = ShopSettings.GetValue("WaterMarkOriginalImge");
                                        waterSourcePath = base.Server.MapPath("~/ImgUpload/" + waterSourcePath);
                                        str7 = ShopSettings.GetValue("WaterMarkImagePosition");
                                        ImageOperator.CreateWaterPic(str5, path, waterSourcePath, str7);
                                        File.Delete(str5);
                                        break;
                                    }
                            }
                            Add(str11);
                            string str13 = "s_" + str12 + info.Extension;
                            string thumbnailPath = base.Server.MapPath("~/ImgUpload/" + str13);
                            for (int i = 0; i < CheckBoxListImageSpec.Items.Count; i++)
                            {
                                if (!CheckBoxListImageSpec.Items[i].Selected)
                                {
                                    goto Label_0329;
                                }
                                string[] strArray = CheckBoxListImageSpec.Items[i].Value.Split(new[] {'*'});
                                int width = Convert.ToInt32(strArray[0]);
                                int height = Convert.ToInt32(strArray[1]);
                                ImageOperator.CreateThumbnailAuto(path, thumbnailPath, width, height);
                            }
                            return;
                            Label_0329:
                            File.Copy(path, thumbnailPath);
                        }
                        catch (Exception)
                        {
                            MessageShow.Visible = true;
                            MessageShow.ShowMessage("UpdateNo1");
                        }
                    }
                    else
                    {
                        MessageShow.Visible = true;
                        MessageShow.ShowMessage("UpdateNo2");
                    }
                }
                else
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("UpdateNo3");
                }
            }
            else
            {
                MessageBox.Show("请上传图片！");
            }
        }

        protected void DropDownListImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownListImageType.SelectedItem.Text)
            {
                case "商品图片":
                    BindCheckBoxListImageSpec("Product");
                    break;

                case "品牌图片":
                    BindCheckBoxListImageSpec("Brand");
                    break;

                case "导购图片":
                    BindCheckBoxListImageSpec("GuidBuy");
                    break;

                case "包装图片":
                    BindCheckBoxListImageSpec("Pack");
                    break;

                case "贺卡图片":
                    BindCheckBoxListImageSpec("BlessCard");
                    break;

                case "Logo图片":
                    BindCheckBoxListImageSpec("Logo");
                    break;

                case "资讯图片":
                    BindCheckBoxListImageSpec("Article");
                    break;

                case "控件图片":
                    BindCheckBoxListImageSpec("Control");
                    break;

                case "视频图片":
                    BindCheckBoxListImageSpec("Video");
                    break;

                case "广告图片":
                    BindCheckBoxListImageSpec("Advertisement");
                    break;

                case "小图标":
                    BindCheckBoxListImageSpec("Icon");
                    break;
            }
        }

        private void method_5(DataTable dt)
        {
            var action = (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListImgCategory2.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_5(table);
                }
            }
        }
    }
}