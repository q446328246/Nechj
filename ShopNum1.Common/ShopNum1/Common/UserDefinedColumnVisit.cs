using System;
using System.Collections.Generic;
using System.Text;

namespace ShopNum1.Common.ShopNum1.Common
{
    public class UserDefinedColumnVisit
    {
        public UserDefinedColumnVisit()
        {
            visitColumns.Add("0", "9A68E6BF-D276-4E72-A367-03CDEFC70460");
            visitColumns.Add("1", "D7935E73-9799-4874-999E-EF6A5F87FB81");
            visitColumns.Add("2", "80855E34-A641-4802-9CA4-857C6840C303");
            visitColumns.Add("3", "F58FFD7B-D764-406C-A51D-7761ADBD7BD2");
            visitColumns.Add("4", "C254A59F-1FC6-409F-88B5-D81993A02780");
            visitColumns.Add("5", "C254A59F-1FC6-409F-88B5-D81993A02780");
            visitColumns.Add("6", "C254A59F-1FC6-409F-88B5-D81993A02780");
            visitColumns.Add("7", "C254A59F-1FC6-409F-88B5-D81993A02780");
            visitColumns.Add("9", "E7FC6D5E-B9DA-425F-90CC-61EEBB667CDC");
            visitColumns.Add("10", "DA0511F7-D6EC-4F01-9D25-836A79D8544D");
            visitColumns.Add("11", "E1247EEF-7AB6-4BA0-93D8-D4343C7DB39B");
            

            
        }
        private Dictionary<string, string> visitColumns = new Dictionary<string, string>();

        public Dictionary<string, string> VisitColumns
        {
            get { return visitColumns; }
            set { visitColumns = value; }
        }

        

    }
}
