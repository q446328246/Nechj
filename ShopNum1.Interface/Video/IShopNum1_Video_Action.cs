using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Video_Action
    {
        int Add(ShopNum1_Video news);
        int Delete(string guids);

        DataTable GetVideoAll(string title, string CategoryCode, string publisher, int IsRecommend, string time1,
            string time2, int isDeleted);

        DataTable GetVideoByGuid(string guid);
        DataTable GetVideoDetail(string guid);
        DataTable GetVideoHotList(int showcount);
        DataTable GetVideoList(int showcount, string isrecommend);
        DataTable GetVideoRelativelyList(string guid, int showcount);

        DataTable SearchVideoList(string resultnum, string pagesize, string currentpage, string strType,
            string strCategory);

        int UpDateVideo(string guid, ShopNum1_Video news);
    }
}