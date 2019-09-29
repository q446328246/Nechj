using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PageInfo_Operate : PageBase, IRequiresSessionState
    {
        private string string_4;

        protected void Page_Load(object sender, EventArgs e)
        {
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"].Replace("'", "");
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                GetFileName();
                if (hiddenFieldGuid.Value != "0")
                {
                    GetEditInfo();
                }
            }
        }

        public void Add()
        {
            var pageInfo = new PageInfo
                {
                    Guid = Guid.NewGuid().ToString(),
                    PageName = TextBoxPageName.Text,
                    FileName = DropDownListFileName.SelectedItem.Text,
                    PageNote = TextBoxPageNote.Text
                };
            var action = (ShopNum1_PageInfo_Action) LogicFactory.CreateShopNum1_PageInfo_Action();
            if (action.Add(pageInfo) > 0)
            {
                string path = base.Server.MapPath("~/Themes/Skin_Default/" + DropDownListFileName.SelectedValue);
                if (File.Exists(path))
                {
                    Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    var writer = new StreamWriter(stream, Encoding.Default);
                    writer.Write(TextBoxContent.Text);
                    writer.Close();
                    stream.Close();
                }
                if (HiddenFieldADCount.Value != "0")
                {
                    AddAD(HiddenFieldADCount.Value);
                    base.Response.Redirect("Advertisement_Operate.aspx?guid='" + HiddenFieldADGuid.Value + "'");
                }
                else
                {
                    base.Response.Redirect("PageInfo_List.aspx");
                }
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        public void AddAD(string divID)
        {
            var advertisement = new Advertisement
                {
                    Guid = Guid.NewGuid().ToString()
                };
            HiddenFieldADGuid.Value = advertisement.Guid;
            advertisement.PageName = TextBoxPageName.Text;
            advertisement.FileName = DropDownListFileName.SelectedValue;
            advertisement.DivID = divID;
            ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).Add(advertisement);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("PageInfo_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            GetEditInfo();
        }

        protected void DropDownListFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListFileName.SelectedValue != "-1")
            {
                string path = base.Server.MapPath("~/Main/Themes/Skin_Default/" + DropDownListFileName.SelectedValue);
                if (File.Exists(path))
                {
                    var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    var reader = new StreamReader(stream, Encoding.Default);
                    TextBoxContent.Text = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
            }
            else
            {
                TextBoxContent.Text = "";
            }
        }

        public void Edit()
        {
            var pageInfo = new PageInfo
                {
                    Guid = hiddenFieldGuid.Value,
                    PageName = TextBoxPageName.Text,
                    FileName = DropDownListFileName.SelectedValue,
                    PageNote = TextBoxPageNote.Text
                };
            var action = (ShopNum1_PageInfo_Action) LogicFactory.CreateShopNum1_PageInfo_Action();
            if (action.Update(pageInfo) > 0)
            {
                string path = base.Server.MapPath("~/Themes/Skin_Default/" + DropDownListFileName.SelectedValue);
                if (File.Exists(path))
                {
                    Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    var writer = new StreamWriter(stream, Encoding.Default);
                    writer.Write(TextBoxContent.Text);
                    writer.Close();
                    stream.Close();
                }
                if (HiddenFieldADCount.Value != "0")
                {
                    AddAD(HiddenFieldADCount.Value);
                    base.Response.Redirect("Advertisement_Operate.aspx?guid='" + HiddenFieldADGuid.Value + "'");
                }
                else
                {
                    base.Response.Redirect("PageInfo_List.aspx");
                }
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public string GetCallbackResult()
        {
            return GetstrAd();
        }

        public void GetEditInfo()
        {
            var action = (ShopNum1_PageInfo_Action) LogicFactory.CreateShopNum1_PageInfo_Action();
            DataRow row = action.SelectByID(hiddenFieldGuid.Value).Rows[0];
            TextBoxPageName.Text = row["pagename"].ToString();
            TextBoxPageNote.Text = row["pagenote"].ToString();
            DropDownListFileName.SelectedValue = row["filename"].ToString();
            string path = base.Server.MapPath("~/Themes/Skin_Default/" + DropDownListFileName.SelectedValue);
            if (File.Exists(path))
            {
                var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                var reader = new StreamReader(stream, Encoding.Default);
                TextBoxContent.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            LabelPageTitle.Text = "编辑广告位列表";
        }

        public void GetFileName()
        {
            string[] files = Directory.GetFiles(base.Server.MapPath("~/Main/Themes/Skin_Default/"), "*.aspx");
            DropDownListFileName.Items.Clear();
            var item = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "-1"
                };
            DropDownListFileName.Items.Add(item);
            for (int i = 0; i < files.Length; i++)
            {
                var item2 = new ListItem
                    {
                        Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
                        Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
                    };
                DropDownListFileName.Items.Add(item2);
            }
        }

        public string GetstrAd()
        {
            string str = string.Empty;
            str = "AD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return ("<div  id='" + str + "' runat='server'></div>|" + str);
        }



        public void RaiseCallbackEvent(string eventArgument)
        {
            string_4 = eventArgument;
        }
    }
}