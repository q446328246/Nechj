using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopInfoList_Manage : PageBase, IRequiresSessionState
    {
        protected void BindDropDownListShopEnsure()
        {
            DropDownListShopEnsure.Items.Clear();
            DropDownListShopEnsure.Items.Add(new ListItem("-全部-", "-1"));
            DataTable shopEnsureList =
                ((Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action()).GetShopEnsureList("");
            if ((shopEnsureList != null) && (shopEnsureList.Rows.Count > 0))
            {
                for (int i = 0; i < shopEnsureList.Rows.Count; i++)
                {
                    var item = new ListItem
                        {
                            Text = shopEnsureList.Rows[i]["Name"].ToString(),
                            Value = shopEnsureList.Rows[i]["ID"].ToString()
                        };
                    DropDownListShopEnsure.Items.Add(item);
                }
            }
        }

        protected void BindDropDownListShopRank()
        {
            DropDownListShopRank.Items.Clear();
            DropDownListShopRank.Items.Add(new ListItem("-全部-", "-1"));
            DataTable shopRank = ((Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action()).GetShopRank();
            if ((shopRank != null) && (shopRank.Rows.Count > 0))
            {
                for (int i = 0; i < shopRank.Rows.Count; i++)
                {
                    var item = new ListItem
                        {
                            Text = shopRank.Rows[i]["Name"].ToString(),
                            Value = shopRank.Rows[i]["Guid"].ToString()
                        };
                    DropDownListShopRank.Items.Add(item);
                }
            }
        }

        protected void BindDropDownListShopReputation()
        {
            DropDownListShopReputation.Items.Clear();
            DropDownListShopReputation.Items.Add(new ListItem("-全部-", "-1"));
            DataTable table = ((Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action()).Search("", -1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var item = new ListItem
                        {
                            Text = table.Rows[i]["Name"].ToString(),
                            Value = table.Rows[i]["minScore"] + "/" + table.Rows[i]["maxScore"]
                        };
                    DropDownListShopReputation.Items.Add(item);
                }
            }
        }

        protected void ButtonChangeOrderID_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ChangeOrder.aspx?guid=" + CheckGuid.Value + "&back=shop");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (CheckGuid.Value.IndexOf(",") != -1)
            {
                MessageBox.Show("一次只能选择一条记录操作！");
            }
            else
            {
                var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
                var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                DataTable shopInfoByGuid = action.GetShopInfoByGuid(CheckGuid.Value);
                string str = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
                string str2 = shopInfoByGuid.Rows[0]["ShopID"].ToString();
                string str3 = shopInfoByGuid.Rows[0]["MemLoginID"].ToString();
                string path = "~/Shop/Shop/" + Convert.ToDateTime(str).ToString("yyyy/MM/dd").Replace('-', '/') +
                              "/Shop" + str2;
                string str5 = "~/ImgUpload/" + Convert.ToDateTime(str).ToString("yyyy/MM/dd").Replace('-', '/') +
                              "/Shop" + str2;
                method_6(base.Server.MapPath(str5));
                method_6(base.Server.MapPath(path));
                action2.UpdateMemberType(CheckGuid.Value.Replace("'",""), 1);
                if (action.Delete(CheckGuid.Value, "'" + str3 + "'") > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "管理员删除店铺担保数据",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ShopInfoList_Manage.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    BindData();
                    Session["AdminLoginCookie"] = "admin";
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guid = button.CommandArgument;
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable shopInfoByGuid = action.GetShopInfoByGuid(guid);
            string str2 = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
            string str3 = shopInfoByGuid.Rows[0]["ShopID"].ToString();
            string str4 = shopInfoByGuid.Rows[0]["MemLoginID"].ToString();
            string path = "~/Shop/Shop/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" +
                          str3;
            string str6 = "~/ImgUpload/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" +
                          str3;
            method_6(base.Server.MapPath(str6));
            method_6(base.Server.MapPath(path));
            action2.UpdateMemberType(guid, 1);
            if (action.Delete(guid, "'" + str4 + "'") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopInfoList_Manage.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
                Session["AdminLoginCookie"] = "admin";
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonManagerShop_Click(object sender, EventArgs e)
        {
            DataTable memberInfoByGuid =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetMemberInfoByGuid(
                    CheckGuid.Value);
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                if (HttpSecureCookie.Decode(cookie).Values["MemberType"] == "2")
                {
                    base.Response.Write(
                        "<script>alert(\"当前已有管理的店铺，请退出后再管理该店铺！\");window.opener=null;window.open('','_self');window.close();</script>");
                    base.Response.End();
                    return;
                }
            }
            var cookie3 = new HttpCookie("MemberLoginCookie");
            cookie3.Values.Add("Name", memberInfoByGuid.Rows[0]["Name"].ToString());
            cookie3.Values.Add("MemLoginID", memberInfoByGuid.Rows[0]["MemLoginID"].ToString());
            cookie3.Values.Add("MemberType", memberInfoByGuid.Rows[0]["MemberType"].ToString());
            if (memberInfoByGuid.Rows[0]["MemberType"].ToString() == "2")
            {
                DataTable shopRankByMemLoginID =
                    ((Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetShopRankByMemLoginID(
                        memberInfoByGuid.Rows[0]["MemLoginID"].ToString());
                if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                {
                    cookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                }
                HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                Page.Response.AppendCookie(cookie4);
                Page.Response.Redirect("http://" + ShopSettings.siteDomain + "/shop/shopadmin/s_index.aspx");
            }
            else
            {
                base.Response.Write(
                    "<script type='text/javascript'>alert(\"店铺已过期或者已关闭!\");window.opener=null;window.open('','_self');window.close();</script>");
                base.Response.End();
            }
        }

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            string str2;
            string selectedValue = DropDownListOperate.SelectedValue;
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            switch (selectedValue)
            {
                case "2":
                    if ((action.UpdateShopState(CheckGuid.Value, "IsExpires", "1") > 0) &&
                        (action.UpdateMemberType(CheckGuid.Value, 1) > 0))
                    {
                        BindData();
                        MessageShow.ShowMessage("Audit2Yes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("Audit2No");
                        MessageShow.Visible = true;
                    }
                    break;

                case "11":
                    if ((action.UpdateShopState(CheckGuid.Value, "IsExpires", "0") > 0) &&
                        (action.UpdateMemberType(CheckGuid.Value, 2) > 0))
                    {
                        BindData();
                        MessageShow.ShowMessage("Audit2Yes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("Audit2No");
                        MessageShow.Visible = true;
                    }
                    break;

                case "3":
                    if ((action.UpdateShopState(CheckGuid.Value, "IsClose", "1") > 0) &&
                        (action.UpdateMemberType(CheckGuid.Value, 2) > 0))
                    {
                        BindData();
                        MessageShow.ShowMessage("Audit2Yes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("Audit2No");
                        MessageShow.Visible = true;
                    }
                    break;

                case "12":
                    if ((action.UpdateShopState(CheckGuid.Value, "IsClose", "0") > 0) &&
                        (action.UpdateMemberType(CheckGuid.Value, 2) > 0))
                    {
                        BindData();
                        MessageShow.ShowMessage("Audit2Yes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("Audit2No");
                        MessageShow.Visible = true;
                    }
                    break;
            }
            if ((selectedValue == "5") || (selectedValue == "8"))
            {
                if (selectedValue == "5")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsRecommend", selectedValue) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "6") || (selectedValue == "9"))
            {
                if (selectedValue == "6")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsVisits ", selectedValue) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "7") || (selectedValue == "10"))
            {
                if (selectedValue == "7")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsHot", selectedValue) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "26") || (selectedValue == "27"))
            {
                if (selectedValue == "26")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";

                }
                //UpdateShopMemberState
                
                if (action.UpdateShopMemberState(CheckGuid.Value, selectedValue) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }

            if ((selectedValue == "15") || (selectedValue == "17"))
            {
                if (selectedValue == "15")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IdentityIsAudit", selectedValue) > 0)
                {
                    BindData();
                    action.UpdateShopState(CheckGuid.Value, "IdentityAuditTime", DateTime.Now.ToString());
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "16") || (selectedValue == "18"))
            {
                if (selectedValue == "16")
                {
                    selectedValue = "1";
                }
                else
                {
                    selectedValue = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "CompanIsAudit", selectedValue) > 0)
                {
                    BindData();
                    action.UpdateShopState(CheckGuid.Value, "CompanAuditTime", DateTime.Now.ToString());
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "19") || (selectedValue == "20"))
            {
                str2 = "0";
                if (selectedValue == "19")
                {
                    str2 = "1";
                }
                else
                {
                    str2 = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsIntegralShop", str2) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "21") || (selectedValue == "22"))
            {
                str2 = "0";
                if (selectedValue == "21")
                {
                    str2 = "1";
                }
                else
                {
                    str2 = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsWeixin", str2) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            if ((selectedValue == "23") || (selectedValue == "24"))
            {
                str2 = "0";
                if (selectedValue == "23")
                {
                    str2 = "1";
                }
                else
                {
                    str2 = "0";
                }
                if (action.UpdateShopState(CheckGuid.Value, "IsShowMap", str2) > 0)
                {
                    BindData();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            DropDownListOperate.SelectedValue = "-1";
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopInfo_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonShopPayMent_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ManagerShopPayMent.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonUpataShopURL_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UpdateShopURL.aspx?guid=" + CheckGuid.Value + "&type=List");
        }

        protected void ButtonUpdateCreditSum_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UpdateShopCreditSum.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonUpdateRank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UptateRank_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonWxPayMent_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SetWxInfo_V82.aspx?guid=" + CheckGuid.Value);
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]), 0);
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
                ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(0, 0);
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
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]), 0);
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
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[1]);
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
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList("0");
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
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        public string GetListImageStatus(string isshow)
        {
            if (isshow == "0")
            {
                return "images/shopNum1Admin-wrong.gif";
            }
            return "images/shopNum1Admin-right.gif";
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未通过";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            return "非法状态";
        }

        public string IsClose(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未关闭";
            }
            if (object_0.ToString() == "1")
            {
                return "已关闭";
            }
            return "非法状态";
        }

        public string IsExpires(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未过期";
            }
            if (object_0.ToString() == "1")
            {
                return "已过期";
            }
            return "非法状态";
        }

        private void BindData()
        {
            SetShopCategoryCode();
            SetShopRegionCode();
            Num1GridViewShow.DataBind();
        }

        private void method_6(string string_4)
        {
            try
            {
                if (Directory.Exists(string_4))
                {
                    foreach (string str in Directory.GetFileSystemEntries(string_4))
                    {
                        if (File.Exists(str))
                        {
                            File.Delete(str);
                        }
                        else
                        {
                            method_6(str);
                        }
                    }
                    Directory.Delete(string_4, true);
                }
            }
            catch
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                DropDownListShopCategoryCode1Bind();
                DropDownListRegionCode1Bind();
                BindDropDownListShopRank();
                BindDropDownListShopReputation();
                BindDropDownListShopEnsure();
                BindData();
                if (ShopSettings.GetValue("IsManagerShop") == "1")
                {
                    ButtonManagerShop.Visible = true;
                }
                if (ShopSettings.GetValue("PayMentType") == "2")
                {
                    ButtonShopPayMent.Visible = true;
                }
                ButtonManagerShop.Attributes.Add("onclick", "this.form.target='_blank'");
            }
        }

        public void SetShopCategoryCode()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }

        public void SetShopRegionCode()
        {
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldRegionCode.Value = "-1";
            }
        }

        public string YesOrNo(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "是";
            }
            return "否";
        }
    }
}