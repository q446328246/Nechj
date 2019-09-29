using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ControlData_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var data = new ShopNum1_ControlData
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text,
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    GroupID = int.Parse(TextBoxGroupID.Text),
                    DataType = int.Parse(DropDownListDataType.SelectedValue),
                    Href = TextBoxHref.Text,
                    Price = 0M
                };
            if (DropDownListDataType.SelectedValue == "2")
            {
                data.Image = TextBoxControlImg.Text;
                data.Price = 0M;
            }
            else if (DropDownListDataType.SelectedValue == "3")
            {
                data.Image = TextBoxProductImg.Text;
                data.Price = decimal.Parse(TextBoxPrice.Text);
            }
            else if (DropDownListDataType.SelectedValue == "4")
            {
                data.Image = TextBoxFlashImage.Text;
            }
            if (CheckBoxMore.Checked)
            {
                string title = data.Title;
                data.Title = title + "|" + TextBoxTitle1.Text + "|" + TextBoxTitle2.Text;
                title = data.Href;
                data.Href = title + "|" + TextBoxHref1.Text + "|" + TextBoxHref2.Text;
            }
            data.IsShow = int.Parse(DropDownListIsShow.SelectedValue);
            data.ControlGuid = HiddenFieldControlGuid.Value;
            data.CreateUser = base.ShopNum1LoginID;
            data.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            data.ModifyUser = base.ShopNum1LoginID;
            data.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var action = (ShopNum1_ControlData_Action) LogicFactory.CreateShopNum1_ControlData_Action();
            if (action.Insert(data) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + LabelTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ControlData_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("ControlData_List.aspx?guid=" + HiddenFieldControlGuid.Value.Replace("'", ""));
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void BottonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ControlData_List.aspx?guid=" + HiddenFieldControlGuid.Value.Replace("'", ""));
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (BottonConfirm.ToolTip == "Update")
            {
                Edit();
            }
            else if (BottonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void CheckBoxMore_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxMore.Checked)
            {
                PanelMore.Visible = true;
            }
            else
            {
                PanelMore.Visible = false;
            }
        }

        protected void DropDownListDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDataType.SelectedValue == "1")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = false;
                PanelFlash.Visible = false;
            }
            if (DropDownListDataType.SelectedValue == "2")
            {
                PanelImg.Visible = true;
                PanelProduct.Visible = false;
                PanelFlash.Visible = false;
            }
            if (DropDownListDataType.SelectedValue == "3")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = true;
                PanelFlash.Visible = false;
            }
            if (DropDownListDataType.SelectedValue == "4")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = false;
                PanelFlash.Visible = true;
            }
        }

        protected void Edit()
        {
            var data = new ShopNum1_ControlData
                {
                    Guid = new Guid(hiddenFieldGuid.Value.Replace("'", "")),
                    Title = TextBoxTitle.Text,
                    OrderID = int.Parse(TextBoxOrderID.Text),
                    GroupID = int.Parse(TextBoxGroupID.Text),
                    DataType = int.Parse(DropDownListDataType.SelectedValue),
                    Href = TextBoxHref.Text,
                    Price = 0M
                };
            if (DropDownListDataType.SelectedValue == "2")
            {
                data.Image = TextBoxControlImg.Text;
            }
            else if (DropDownListDataType.SelectedValue == "3")
            {
                data.Image = TextBoxProductImg.Text;
                data.Price = decimal.Parse(TextBoxPrice.Text);
            }
            else if (DropDownListDataType.SelectedValue == "4")
            {
                data.Image = TextBoxFlashImage.Text;
            }
            if (CheckBoxMore.Checked)
            {
                string title = data.Title;
                data.Title = title + "| " + TextBoxTitle1.Text + "| " + TextBoxTitle2.Text;
                title = data.Href;
                data.Href = title + "| " + TextBoxHref1.Text + "| " + TextBoxHref2.Text;
            }
            data.IsShow = int.Parse(DropDownListIsShow.SelectedValue);
            data.ModifyUser = base.ShopNum1LoginID;
            data.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var action = (ShopNum1_ControlData_Action) LogicFactory.CreateShopNum1_ControlData_Action();
            if (action.Update(data) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + LabelTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ControlData_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("ControlData_List.aspx?guid=" + HiddenFieldControlGuid.Value.Replace("'", ""));
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_ControlData_Action) LogicFactory.CreateShopNum1_ControlData_Action()).GetEditInfo(
                    hiddenFieldGuid.Value);
            string str = editInfo.Rows[0]["Title"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            TextBoxGroupID.Text = editInfo.Rows[0]["GroupID"].ToString();
            DropDownListDataType.SelectedValue = editInfo.Rows[0]["DataType"].ToString();
            DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
            string str2 = editInfo.Rows[0]["Href"].ToString();
            if (str.Contains("|") || str2.Contains("|"))
            {
                CheckBoxMore.Checked = true;
                CheckBoxMore_CheckedChanged(null, null);
                TextBoxTitle.Text = str.Split(new[] {'|'})[0];
                TextBoxTitle1.Text = str.Split(new[] {'|'})[1];
                TextBoxTitle2.Text = str.Split(new[] {'|'})[2];
                TextBoxHref.Text = str2.Split(new[] {'|'})[0];
                TextBoxHref1.Text = str2.Split(new[] {'|'})[1];
                TextBoxHref2.Text = str2.Split(new[] {'|'})[2];
            }
            else
            {
                TextBoxTitle.Text = str;
                TextBoxHref.Text = str2;
            }
            if (DropDownListDataType.SelectedValue == "1")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = false;
                PanelFlash.Visible = false;
            }
            if (DropDownListDataType.SelectedValue == "2")
            {
                PanelImg.Visible = true;
                PanelProduct.Visible = false;
                PanelFlash.Visible = false;
                TextBoxControlImg.Text = editInfo.Rows[0]["Image"].ToString();
                ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"];
            }
            if (DropDownListDataType.SelectedValue == "3")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = true;
                PanelFlash.Visible = false;
                TextBoxProductImg.Text = editInfo.Rows[0]["Image"].ToString();
                ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"];
                TextBoxPrice.Text = editInfo.Rows[0]["Price"].ToString();
            }
            if (DropDownListDataType.SelectedValue == "4")
            {
                PanelImg.Visible = false;
                PanelProduct.Visible = false;
                PanelFlash.Visible = true;
                TextBoxFlashImage.Text = editInfo.Rows[0]["Image"].ToString();
                ImgControlImg.Src = "~/ImgUpload/" + editInfo.Rows[0]["Image"];
            }
            BottonConfirm.Text = "更新";
            BottonConfirm.ToolTip = "Update";
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_ControlData";
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            HiddenFieldControlGuid.Value = (base.Request.QueryString["ControlGuid"] == null)
                                               ? "0"
                                               : base.Request.QueryString["ControlGuid"];
            if (!Page.IsPostBack)
            {
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "【 编辑模块数据 】";
                    GetEditInfo();
                }
            }
        }
    }
}