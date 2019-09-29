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
    public partial class addpic : PageBase, IRequiresSessionState
    {
        protected string strSapce = "　　";
        public string ImageSpec { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindImageType();
                BindImageCategory();
                BindCheckBoxListImageSpec("Product");
                method_5();
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
                MessageShow.Visible = true;
                MessageShow.ShowMessage("AddYes");
                ClearContorl();
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo1");
            }
        }

        protected void BindCheckBoxListImageSpec(string strType)
        {
            this.CheckBoxListImageSpec.Items.Clear();
            this.CheckBoxListImageSpec.Visible = true;
            string str = "Skin_Default";
            string imageSpec = "Themes/" + str + "/ImageSpec.xml";
            this.ImageSpec = imageSpec;
            string xmlPath = base.Server.MapPath("../" + this.ImageSpec);
            
            DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "ImageSpec");

            foreach (DataRow dataRow in xmlData.Tables[0].Rows)
            {
                ListItem listItem = new ListItem();
                if (strType == "Product")
                {
                    if (!(dataRow["name"].ToString().Trim() == "Product"))
                    {
                        continue;
                    }
                    listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                    listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                    this.CheckBoxListImageSpec.Items.Add(listItem);
                }
                else
                {
                    if (strType == "Brand")
                    {
                        if (!(dataRow["name"].ToString().Trim() == "Brand"))
                        {
                            continue;
                        }
                        listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                        listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                        this.CheckBoxListImageSpec.Items.Add(listItem);
                    }
                    else
                    {
                        if (strType == "GuidBuy")
                        {
                            if (!(dataRow["name"].ToString().Trim() == "GuidBuy"))
                            {
                                continue;
                            }
                            listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                            listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                            this.CheckBoxListImageSpec.Items.Add(listItem);
                        }
                        else
                        {
                            if (strType == "Pack")
                            {
                                if (!(dataRow["name"].ToString().Trim() == "Pack"))
                                {
                                    continue;
                                }
                                listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                this.CheckBoxListImageSpec.Items.Add(listItem);
                            }
                            else
                            {
                                if (strType == "BlessCard")
                                {
                                    if (!(dataRow["name"].ToString().Trim() == "BlessCard"))
                                    {
                                        continue;
                                    }
                                    listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                    listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                    this.CheckBoxListImageSpec.Items.Add(listItem);
                                }
                                else
                                {
                                    if (strType == "Logo")
                                    {
                                        if (!(dataRow["name"].ToString().Trim() == "Logo"))
                                        {
                                            continue;
                                        }
                                        listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                        listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                        this.CheckBoxListImageSpec.Items.Add(listItem);
                                    }
                                    else
                                    {
                                        if (strType == "Article")
                                        {
                                            if (!(dataRow["name"].ToString().Trim() == "Article"))
                                            {
                                                continue;
                                            }
                                            listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                            listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                            this.CheckBoxListImageSpec.Items.Add(listItem);
                                        }
                                        else
                                        {
                                            if (strType == "Control")
                                            {
                                                if (!(dataRow["name"].ToString().Trim() == "Control"))
                                                {
                                                    continue;
                                                }
                                                listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                                listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                                this.CheckBoxListImageSpec.Items.Add(listItem);
                                            }
                                            else
                                            {
                                                if (strType == "Video")
                                                {
                                                    if (!(dataRow["name"].ToString().Trim() == "Video"))
                                                    {
                                                        continue;
                                                    }
                                                    listItem.Text = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                                    listItem.Value = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
                                                    this.CheckBoxListImageSpec.Items.Add(listItem);
                                                }
                                                else
                                                {
                                                    if ((!(strType == "Advertisement") && !(strType == "Icon")) || (!(dataRow["name"].ToString().Trim() == "Icon") && !(dataRow["name"].ToString().Trim() == "Advertisement")))
                                                    {
                                                        continue;
                                                    }
                                                    this.CheckBoxListImageSpec.Visible = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }

            if (this.CheckBoxListImageSpec.Items.Count > 0)
            {
                this.CheckBoxListImageSpec.Items[0].Selected = true;
            }
        }

        protected void BindImageCategory()
        {
            DropDownListImgCategory2.Items.Clear();
            var item = new ListItem
                {
                    Text = "请选择",
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
                    method_6(table);
                }
            }
        }

        protected void BindImageType()
        {
            DropDownListImageType.Items.Add(new ListItem("-请选择-", "-1"));
            DropDownListImageType.Items.Add(new ListItem("商品图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4941"));
            DropDownListImageType.Items.Add(new ListItem("品牌图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4942"));
            DropDownListImageType.Items.Add(new ListItem("导购图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4943"));
            DropDownListImageType.Items.Add(new ListItem("包装图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4944"));
            DropDownListImageType.Items.Add(new ListItem("贺卡图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4945"));
            DropDownListImageType.Items.Add(new ListItem("Logo图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4947"));
            DropDownListImageType.Items.Add(new ListItem("资讯图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4948"));
            DropDownListImageType.Items.Add(new ListItem("控件图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4950"));
            DropDownListImageType.Items.Add(new ListItem("视频图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4951"));
            DropDownListImageType.Items.Add(new ListItem("广告图片", "b0f6e545-cd10-4e83-8c96-2c1e143e4952"));
            DropDownListImageType.Items.Add(new ListItem("小图标", "b0f6e545-cd10-4e83-8c96-2c1e143e4953"));
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string str2;
            string str3;
            Random random;
            string str4;
            string str5;
            FileInfo info;
            string str6;
            string str7;
            string str8;
            string str9;
            string str10;
            int num2;
            string[] strArray;
            int num3;
            int num4;
            string str11;
            string str12;
            string str13;
            string str14;
            string str15;
            float num5;
            string str16;
            if (base.Request.QueryString["id"] == null)
            {
                if (FileUploadImage.HasFile)
                {
                    switch (FileUploadImage.PostedFile.ContentType)
                    {
                        case "image/bmp":
                        case "image/png":
                        case "image/gif":
                        case "image/pjpeg":
                        case "image/x-png":
                        case "image/jpeg":
                            {
                                str3 = Operator.FilterString(FileUploadImage.PostedFile.FileName);
                                random = new Random();
                                int num = 10 + random.Next(70);
                                str4 = num.ToString();
                                Thread.Sleep(20);
                                str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + str4;
                                info = new FileInfo(str3);
                                str6 = str5 + info.Extension;
                                str7 = base.Server.MapPath("~/ImgUpload/" + str6);
                                str2 = "~/ImgUpload/" + str6;
                                if (!File.Exists(str7))
                                {
                                    try
                                    {
                                        str8 = ShopSettings.GetValue("IfSetWaterMark");
                                        if (DropDownListImageType.SelectedValue ==
                                            "b0f6e545-cd10-4e83-8c96-2c1e143e4947")
                                        {
                                            str8 = "0";
                                        }
                                        if (str8 == "0")
                                        {
                                            FileUploadImage.SaveAs(str7);
                                        }
                                        else if (str8 == "1")
                                        {
                                            str11 = base.Server.MapPath("~/ImgUpload/O_" + str6);
                                            FileUploadImage.SaveAs(str11);
                                            str14 = ShopSettings.GetValue("WaterMarkWords");
                                            str13 = ShopSettings.GetValue("WordsWaterMarkPosition");
                                            str15 = ShopSettings.GetValue("WaterMarkWordsFont");
                                            num5 = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
                                            str16 = ShopSettings.GetValue("WaterMarkWordsColor");
                                            ImageOperator.CreateWater(str11, str7, str14, str13, str15, num5, str16);
                                            File.Delete(str11);
                                        }
                                        else if (str8 == "2")
                                        {
                                            str11 = base.Server.MapPath("~/ImgUpload/O_" + str6);
                                            FileUploadImage.SaveAs(str11);
                                            str12 = ShopSettings.GetValue("WaterMarkOriginalImge");
                                            str12 = base.Server.MapPath(str12);
                                            str13 = ShopSettings.GetValue("WaterMarkImagePosition");
                                            ImageOperator.CreateWaterPic(str11, str7, str12, str13);
                                            File.Delete(str11);
                                        }
                                        Add(str2);
                                        str9 = "s_" + str5 + info.Extension;
                                        str10 = base.Server.MapPath("~/ImgUpload/" + str9);
                                        for (num2 = 0; num2 < CheckBoxListImageSpec.Items.Count; num2++)
                                        {
                                            if (!CheckBoxListImageSpec.Items[num2].Selected)
                                            {
                                                goto Label_0369;
                                            }
                                            strArray = CheckBoxListImageSpec.Items[num2].Value.Split(new[] {'*'});
                                            num3 = Convert.ToInt32(strArray[0]);
                                            num4 = Convert.ToInt32(strArray[1]);
                                            ImageOperator.CreateThumbnailAuto(str7, str10, num3, num4);
                                        }
                                        return;
                                        Label_0369:
                                        File.Copy(str7, str10);
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
                                return;
                            }
                    }
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("UpdateNo3");
                }
                else
                {
                    MessageBox.Show("请上传图片！");
                }
                return;
            }
            str2 = string.Empty;
            if (FileUploadImage.HasFile)
            {
                switch (FileUploadImage.PostedFile.ContentType)
                {
                    case "image/bmp":
                    case "image/png":
                    case "image/gif":
                    case "image/pjpeg":
                    case "image/x-png":
                    case "image/jpeg":
                        str3 = Operator.FilterString(FileUploadImage.PostedFile.FileName);
                        random = new Random();
                        str4 = (10 + random.Next(70)).ToString();
                        Thread.Sleep(20);
                        str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + str4;
                        info = new FileInfo(str3);
                        str6 = str5 + info.Extension;
                        str7 = base.Server.MapPath("~/ImgUpload/" + str6);
                        str2 = "~/ImgUpload/" + str6;
                        if (!File.Exists(str7))
                        {
                            try
                            {
                                str8 = ShopSettings.GetValue("IfSetWaterMark");
                                if (DropDownListImageType.SelectedValue == "b0f6e545-cd10-4e83-8c96-2c1e143e4947")
                                {
                                    str8 = "0";
                                }
                                if (str8 == "0")
                                {
                                    FileUploadImage.SaveAs(str7);
                                }
                                else if (str8 == "1")
                                {
                                    str11 = base.Server.MapPath("~/ImgUpload/O_" + str6);
                                    FileUploadImage.SaveAs(str11);
                                    str14 = ShopSettings.GetValue("WaterMarkWords");
                                    str13 = ShopSettings.GetValue("WordsWaterMarkPosition");
                                    str15 = ShopSettings.GetValue("WaterMarkWordsFont");
                                    num5 = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
                                    str16 = ShopSettings.GetValue("WaterMarkWordsColor");
                                    ImageOperator.CreateWater(str11, str7, str14, str13, str15, num5, str16);
                                    File.Delete(str11);
                                }
                                else if (str8 == "2")
                                {
                                    str11 = base.Server.MapPath("~/ImgUpload/O_" + str6);
                                    FileUploadImage.SaveAs(str11);
                                    str12 = ShopSettings.GetValue("WaterMarkOriginalImge");
                                    str12 = base.Server.MapPath("~/ImgUpload/" + str12);
                                    str13 = ShopSettings.GetValue("WaterMarkImagePosition");
                                    ImageOperator.CreateWaterPic(str11, str7, str12, str13);
                                    File.Delete(str11);
                                }
                                str9 = "s_" + str5 + info.Extension;
                                str10 = base.Server.MapPath("~/ImgUpload/" + str9);
                                for (num2 = 0; num2 < CheckBoxListImageSpec.Items.Count; num2++)
                                {
                                    if (!CheckBoxListImageSpec.Items[num2].Selected)
                                    {
                                        goto Label_073C;
                                    }
                                    strArray = CheckBoxListImageSpec.Items[num2].Value.Split(new[] {'*'});
                                    num3 = Convert.ToInt32(strArray[0]);
                                    num4 = Convert.ToInt32(strArray[1]);
                                    ImageOperator.CreateThumbnailAuto(str7, str10, num3, num4);
                                }
                                goto Label_07FE;
                                Label_073C:
                                File.Copy(str7, str10);
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
                        goto Label_07FE;
                }
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo3");
            }
            else
            {
                var action = (ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action();
                str2 = action.Search("'" + base.Request.QueryString["id"] + "'").Rows[0]["ImagePath"].ToString();
            }
            Label_07FE:
            Update(base.Request.QueryString["id"], str2);
        }

        protected void ClearContorl()
        {
            textBoxName.Text = "";
            textBoxDescription.Text = "";
        }

        protected void DropDownListImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>loadwindow2(800,600);</script>", false);
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

        private void method_5()
        {
            if (base.Request.QueryString["id"] != null)
            {
                DataTable table =
                    ((ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action()).Search("'" +
                                                                                                base.Request.QueryString
                                                                                                    ["id"] + "'");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DropDownListImageType.SelectedValue = table.Rows[0]["ImageType"].ToString();
                    textBoxName.Text = table.Rows[0]["Name"].ToString();
                    DropDownListImgCategory2.SelectedValue = table.Rows[0]["ImageCategoryID"].ToString();
                    textBoxDescription.Text = table.Rows[0]["Description"].ToString();
                    Image1.Visible = true;
                    Image1.ImageUrl = table.Rows[0]["ImagePath"].ToString();
                }
            }
        }

        private void method_6(DataTable dt)
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
                    method_6(table);
                }
            }
        }


        protected void Update(string guid, string fileName)
        {
            var image = new ShopNum1_Image
                {
                    Guid = new Guid(guid),
                    Name = textBoxName.Text.Trim(),
                    ImageType = DropDownListImageType.SelectedValue,
                    ImagePath = fileName,
                    Description = textBoxDescription.Text.Trim(),
                    UseTimes = 0,
                    CreateUser = "admin",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0,
                    ImageCategoryID = Convert.ToInt32(DropDownListImgCategory2.SelectedValue)
                };
            var action = (ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action();
            if (action.Update(image) > 0)
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("EditYes");
                ClearContorl();
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo1");
            }
        }
    }
}