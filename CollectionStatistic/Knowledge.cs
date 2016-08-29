using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class Knowledge
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string KnowledgeCol(string fromDate, string endDate)
        {
            string wherePart = "type='knowledge'";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 用户排重
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Know(string fromDate, string endDate)
        {
            string wherePart = "type='knowledge'";

            return Common.NewUser(fromDate, endDate, wherePart);
        }
    }
}
