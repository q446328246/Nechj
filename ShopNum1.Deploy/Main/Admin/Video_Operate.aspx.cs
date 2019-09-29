using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Video_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                BindCategory();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "视频编辑页";
                    GetEditInfo();
                }
                else
                {
                    GetOrderID();
                }
            }
        }

        protected void Add()
        {
            var video = new ShopNum1_Video
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text.Trim(),
                    ImgAdd = TextBoxImg.Text.Trim(),
                    VideoAdd = TextBoxAddress.Text.Trim(),
                    KeyWords = TextBoxKeyWords.Text.Trim(),
                    Content = base.Server.HtmlEncode(FCKeditorRemark.Text.Replace("'", "''"))
                };
            if (CheckBoxRecommend.Checked)
            {
                video.IsRecommend = 1;
            }
            else
            {
                video.IsRecommend = 0;
            }
            video.CategoryID = int.Parse(DropDownListCategoryID.SelectedValue);
            video.OrderID = Convert.ToInt32(TextBoxOrderId.Text.Trim());
            video.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            video.CreateUser = base.ShopNum1LoginID;
            video.ModifyUser = base.ShopNum1LoginID;
            video.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            video.Description = TextBoxDescription.Text;
            video.KeyWordsSeo = TextBoxKeywordSeo.Text;
            video.BroadcastCount = 0;
            var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
            if (action.Add(video) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Video_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                ClearControl();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void AddSubCategory(DataTable dataTable)
        {
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
            foreach (DataRow row in dataTable.Rows)
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
                DropDownListCategoryID.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    AddSubCategory(table);
                }
            }
        }

        protected void BindCategory()
        {
            var item = new ListItem
                {
                    Text = "-请选择-",
                    Value = "-1"
                };
            DropDownListCategoryID.Items.Add(item);
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
            foreach (DataRow row in action.Search(0, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListCategoryID.Items.Add(item2);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubCategory(dataTable);
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (BottonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "更新" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Video_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else if (BottonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Video_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxImg.Text = string.Empty;
            TextBoxKeyWords.Text = string.Empty;
            TextBoxOrderId.Text = string.Empty;
            FCKeditorRemark.Text = string.Empty;
        }

        protected void Edit()
        {
            var video = new ShopNum1_Video
                {
                    Title = TextBoxTitle.Text.Trim(),
                    ImgAdd = TextBoxImg.Text.Trim(),
                    VideoAdd = TextBoxAddress.Text.Trim(),
                    KeyWords = TextBoxKeyWords.Text.Trim(),
                    Content = base.Server.HtmlEncode(FCKeditorRemark.Text.Replace("'", "''"))
                };
            if (CheckBoxRecommend.Checked)
            {
                video.IsRecommend = 1;
            }
            else
            {
                video.IsRecommend = 0;
            }
            video.CategoryID = int.Parse(DropDownListCategoryID.SelectedValue);
            video.OrderID = Convert.ToInt32(TextBoxOrderId.Text.Trim());
            video.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            video.CreateUser = base.ShopNum1LoginID;
            video.ModifyUser = base.ShopNum1LoginID;
            video.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            video.Description = TextBoxDescription.Text;
            video.KeyWordsSeo = TextBoxKeywordSeo.Text;
            var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
            if (action.UpDateVideo(hiddenFieldGuid.Value, video) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Video_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("Video_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable videoByGuid =
                ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).GetVideoByGuid(
                    hiddenFieldGuid.Value);
            TextBoxTitle.Text = videoByGuid.Rows[0]["Title"].ToString();
            TextBoxImg.Text = videoByGuid.Rows[0]["ImgAdd"].ToString();
            TextBoxAddress.Text = videoByGuid.Rows[0]["VideoAdd"].ToString();
            if (videoByGuid.Rows[0]["IsRecommend"].ToString() == "1")
            {
                CheckBoxRecommend.Checked = true;
            }
            else
            {
                CheckBoxRecommend.Checked = false;
            }
            DropDownListCategoryID.SelectedValue = videoByGuid.Rows[0]["CategoryID"].ToString();
            TextBoxKeyWords.Text = videoByGuid.Rows[0]["KeyWords"].ToString();
            FCKeditorRemark.Text = base.Server.HtmlDecode(videoByGuid.Rows[0]["Content"].ToString());
            TextBoxOrderId.Text = videoByGuid.Rows[0]["OrderId"].ToString();
            ImageSingleImage.ImageUrl = videoByGuid.Rows[0]["ImgAdd"].ToString();
            TextBoxKeywordSeo.Text = videoByGuid.Rows[0]["KeyWordsSeo"].ToString();
            TextBoxDescription.Text = videoByGuid.Rows[0]["Description"].ToString();
            BottonConfirm.Text = "更新";
            BottonConfirm.ToolTip = "Update";
        }

        protected void GetOrderID()
        {
            var action1 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            string columnName = "OrderID";
            string tableName = "ShopNum1_Video";
            TextBoxOrderId.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }
    }
}