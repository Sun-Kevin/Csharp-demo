using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class Building
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string BuildingCol(string fromDate, string endDate)
        {
            string wherePart = "(type='esf' OR type='rent') AND (PropertyType=1 OR PropertyType=2)  AND(roomid='' OR roomid IS NULL)";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Buil(string fromDate, string endDate)
        {
            string wherePart = "(type='esf' OR type='rent') AND (PropertyType=1 OR PropertyType=2)  AND(roomid='' OR roomid IS NULL)";

            return Common.NewUser(fromDate, endDate, wherePart);
        }
    }
}
