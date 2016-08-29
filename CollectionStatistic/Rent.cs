using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class Rent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string EHouseResource(string fromDate, string endDate)
        {
            string wherePart = "type='rent' AND esfsubtype='ds' AND(roomid='' OR roomid IS NULL) ";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string RegHouseResource(string fromDate, string endDate)
        {
            string wherePart = "type='rent' AND esfsubtype!='ds' AND(roomid='' OR roomid IS NULL) ";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_E(string fromDate, string endDate)
        {
            string wherePart = "type='rent' AND esfsubtype='ds' AND(roomid='' OR roomid IS NULL) ";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_R(string fromDate, string endDate)
        {
            string wherePart = "type='rent' AND esfsubtype!='ds' AND(roomid='' OR roomid IS NULL) ";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string Total(string fromDate, string endDate)
        {
            string wherePart = "type='rent' AND (roomid='' OR roomid IS NULL) ";

            return Common.NewUser(fromDate, endDate, wherePart);
        }
    }
}
