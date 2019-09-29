using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ImageCategory_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
        {
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                var child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim(),
                        SelectAction = TreeNodeSelectAction.Select
                    };
                child.Expand();
                fatherNode.ChildNodes.Add(child);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    AddSubProductCategory(child, table);
                }
            }
        }

        protected void AddSubProductCategoryInData(int newId, DataTable dataTable, DataTable dataTableImg)
        {
            bool flag = false;
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            var action2 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row2;
                flag = false;
                //using ()
                //{
                IEnumerator enumerator = dataTableImg.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var current = (DataRow)enumerator.Current;
                    if (dataTable.Rows[i]["Name"].ToString() == current["Name"].ToString())
                    {
                        goto Label_0080;
                    }
                }
                goto Label_009C;
            Label_0080:
                flag = true;
            //}
            Label_009C:
                row2 = dataTable.Rows[i];
                Convert.ToInt32(row2["ID"]);
                string name = row2["Name"].ToString();
                string description = row2["Description"].ToString();
                string fatherID = row2["FatherID"].ToString();
                int num2 = Convert.ToInt32(row2["CategoryLevel"]);
                string user = base.ShopNum1LoginID;
                string s = action.GetMaxID().ToString();
                if (!flag)
                {
                    action.Insert(name, description, num2.ToString(), newId.ToString(), "null", user);
                }
                else
                {
                    DataTable idByName = action.GetIdByName(name, fatherID);
                    s = ((idByName == null) || (idByName.Rows.Count <= 0)) ? s : idByName.Rows[0]["ID"].ToString();
                }
                DataTable table2 = action2.Search(Convert.ToInt32(row2["ID"].ToString().Trim()), 0);
                if (table2.Rows.Count > 0)
                {
                    DataTable table3 = action.Search(Convert.ToInt32(row2["ID"].ToString().Trim()));
                    AddSubProductCategoryInData(int.Parse(s), table2, table3);
                }
            }
        }

        protected void BindProductCategory()
        {
            DataTable table =
                ((ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action()).Search(0);
            Num1GridViewShow.DataSource = table.DefaultView;
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ImageCategory_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            if (action.DeleteType(CheckGuid.Value) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "批量删除成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ImageCategory_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindProductCategory();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            string str = "";
            if (base.Request.Cookies["AdminLoginCookie"] != null)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                str = HttpSecureCookie.Decode(cookie).Values["Guid"];
            }
            var button = (LinkButton)sender;
            if (button.CommandArgument == "1")
            {
                MessageShow.ShowMessage("默认分类禁止删除！");
                MessageShow.Visible = true;
            }
            else
            {
                string str2 = "'" + button.CommandArgument + "'";
                if (str2.Replace("'", " ").ToUpper() == str)
                {
                    MessageBox.Show("自己不能删除自己!");
                }
                else
                {
                    var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
                    if (action.Delete(str2) > 0)
                    {
                        HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "删除成功",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "ImageCategory_List.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(operateLog);
                        BindProductCategory();
                        MessageShow.ShowMessage("DelYes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("DelNo");
                        MessageShow.Visible = true;
                    }
                }
            }
        }

        protected void Page_Changing(object sender, GridViewPageEventArgs e)
        {
            Num1GridViewShow.PageIndex = e.NewPageIndex;
            BindProductCategory();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindProductCategory();
            }
        }
    }
}