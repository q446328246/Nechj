using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_MessageBoard_Action : IShop_MessageBoard_Action
    {
        public DataTable SearchMessageBoardList(string replyuser, string isshow, string showcount, string messagetype)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@replyuser";
            paraValue[0] = replyuser;
            paraName[1] = "@isshow";
            paraValue[1] = isshow;
            paraName[2] = "@showcount";
            paraValue[2] = showcount;
            paraName[3] = "@messagetype";
            paraValue[3] = messagetype;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchMessageBoardList", paraName, paraValue);
        }

        public DataSet SearchMessageBoardListNew(string shopid, string type, string ordertype, string sort,
            string perpagenum, string current_page, string isreturcount,int category)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(type))
            {
                str = " AND A.MessageType='" + type + "'";
            }
            else
            {
                str = " AND 1=1";
            }
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@columnnames";
            paraValue[1] =
                "  a.Guid,a.MessageType,a.Title,a.MemLoginID AS  MemberName,a.Content,a.SendTime,a.ReplyUser,a.ReplyTime,a.ReplyContent,a.ManageReply,a.ManageTime,a.ManageID,b.Name  ";
            paraName[2] = "@searchname";
            paraValue[2] = str;
            paraName[3] = "@ordertype";
            paraValue[3] = ordertype;
            paraName[4] = "@sort";
            paraValue[4] = sort;
            paraName[5] = "@perpagenum";
            paraValue[5] = perpagenum;
            paraName[6] = "@current_page";
            paraValue[6] = current_page;
            paraName[7] = "@isreturcount";
            paraValue[7] = isreturcount;
            paraName[8] = "@category";
            paraValue[8] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchMessageBoardListNew", paraName, paraValue);
        }

        public DataTable SelectMessageBoard_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "SendTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int AddMemMessageBoard(ShopNum1_Shop_MessageBoard messageBoard)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@messagetype";
            paraValue[0] = messageBoard.MessageType.ToString();
            paraName[1] = "@tilte";
            paraValue[1] = messageBoard.Title;
            paraName[2] = "@content";
            paraValue[2] = messageBoard.Content;
            paraName[3] = "@memloginid";
            paraValue[3] = messageBoard.MemLoginID;
            paraName[4] = "@replyuser";
            paraValue[4] = messageBoard.ReplyUser;
            paraName[5] = "@isShow";
            paraValue[5] = messageBoard.IsShow.ToString();
            paraName[6] = "@category";
            paraValue[6] = messageBoard.shop_category_id.ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddMemMessageBoard", paraName, paraValue);
        }

        public int DeleteMessageBoard(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteMessageBoard", paraName, paraValue);
        }

        public int MessageBoardReply(ShopNum1_Shop_MessageBoard messageBoard)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = messageBoard.Guid.ToString();
            paraName[1] = "@replytime";
            paraValue[1] = messageBoard.ReplyTime.ToString();
            paraName[2] = "@replycontent";
            paraValue[2] = messageBoard.ReplyContent;
            return DatabaseExcetue.RunProcedure("Pro_Shop_MessageBoardReply", paraName, paraValue);
        }

        public DataTable SearchMessageBoard(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchMessageBoard", paraName, paraValue);
        }

        public DataTable SearchPhoneContent(string guid, string memLoginID)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM Agent_PhnoeContent where  1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "-1"))
            {
                str = str + " AND Guid = '" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " AND memLoginID ='" + memLoginID + "'");
        }

        public DataTable SelectMyShopMessageBoard_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_MessageBoard";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "SendTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdateMessageBoardBymanage(string guid, string managereply, string manageid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@managereply";
            paraValue[1] = managereply;
            paraName[2] = "@manageid";
            paraValue[2] = manageid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateMessageBoardBymanage", paraName, paraValue);
        }
    }
}