using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ZtcGoods_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            if (action.UpdateState(CheckGuid.Value, 0) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "�ر�ֱͨ����Ʒ�ɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ZtcGoods_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("�رճɹ���");
                BindGrid();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ��ֱͨ����Ʒ�ɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ZtcGoods_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                action.Delete(CheckGuid.Value);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            catch (Exception)
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonOpen_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            if (action.UpdateState(CheckGuid.Value, 1) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����ֱͨ����Ʒ�ɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ZtcGoods_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("����ɹ���");
                BindGrid();
            }
        }
    }
}