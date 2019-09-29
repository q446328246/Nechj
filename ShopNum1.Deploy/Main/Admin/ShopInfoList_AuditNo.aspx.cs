using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopInfoList_AuditNo : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.DeleteMore(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除审核未通过店铺",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopInfoList_AuditNo.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guid = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataTable shopInfoByGuid = action.GetShopInfoByGuid(guid);
            string str2 = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
            string str3 = shopInfoByGuid.Rows[0]["ShopID"].ToString();
            string path = "~/Shop/Shop/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/" +
                          ShopSettings.GetValue("PersonShopUrl") + str3;
            string str5 = "~/ImgUpload/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/" +
                          ShopSettings.GetValue("PersonShopUrl") + str3;
            method_6(base.Server.MapPath(str5));
            method_6(base.Server.MapPath(path));
            if (action.Delete(guid) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除审核未通过店铺",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopInfoList_AuditNo.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopInfo_AuditOperate.aspx?guid=" + CheckGuid.Value);
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        private void method_6(string string_4)
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