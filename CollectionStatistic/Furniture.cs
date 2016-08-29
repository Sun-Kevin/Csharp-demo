using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class Furniture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string FurnitureCol(string fromDate, string endDate)
        {
            string wherePart = "type in ('special','myspecial','designer','foreman')";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Fur(string fromDate, string endDate)
        {
            string wherePart = "type in ('special','myspecial','designer','foreman')";

            return Common.NewUser(fromDate, endDate, wherePart);
        }
    }
}
