using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("input date here(format:yyyy-MM-dd hh:mm:ss):");
            //var input = Console.ReadLine();
            //Console.WriteLine();
            var keyDate = DateTime.Parse("2016/07/22 00:00:00");//date of Friday
            Console.WriteLine("keyDate=" + keyDate);
            while (true)
            {
                var date = DateTime.Now;
                if (date > keyDate)
                {
                    //date = DateTime.Parse("2016-04-08 00:01:00");
                    var fromDate = "2016-07-22 00:00:00";//date.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
                    var endDate = "2016-07-29 00:00:00";// date.ToString("yyyy-MM-dd 00:00:00");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("commencing statistic between " + fromDate + " and " + endDate + " at " + DateTime.Now + "\n Please wait...");
                    Program.RunStatisticAndSend(fromDate, endDate);
                    Console.WriteLine("completed and send via email at " + DateTime.Now);
                    break;
                }
                else
                {
                    var timeSpan = keyDate - date;
                    Console.WriteLine("Program will run again in " + timeSpan);
                    Thread.Sleep(timeSpan);
                }
            }
            Console.ReadKey(true);
        }

        static void RunStatisticAndSend(string fromDate, string endDate)
        {
            var body = new StringBuilder();
            body.Append("<style type=\"text/css\">table{border-collapse:collapse;}td{border:1px solid;padding:1px;text-align:center;}</style>");
            body.Append("<table>");
            body.Append("<tr><td></td><td>新增收藏量</td><td>用户ID量</td></tr>");
            string collectionCount = string.Empty;
            string IDCount = string.Empty;

            #region newhouse
            collectionCount = NewHouse.Project(fromDate, endDate);
            IDCount = NewHouse.NewUser_Pro(fromDate, endDate);
            body.Append("<tr><td>新房楼盘</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = NewHouse.HouseResource(fromDate, endDate);
            IDCount = NewHouse.NewUser_Hou(fromDate, endDate);
            body.Append("<tr><td>新房房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = NewHouse.DwellingType(fromDate, endDate);
            IDCount = NewHouse.NewUser_Dw(fromDate, endDate);
            body.Append("<tr><td>新房户型</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            IDCount = NewHouse.Total(fromDate, endDate);
            body.Append("<tr><td>新房排重</td><td>-</td><td>" + IDCount + "</td></tr>");
            #endregion

            #region secondhand
            collectionCount = SecondHand.EHouseResource(fromDate, endDate);
            IDCount = SecondHand.NewUser_E(fromDate, endDate);
            body.Append("<tr><td>二手房电商房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = SecondHand.RegHouseResource(fromDate, endDate);
            IDCount = SecondHand.NewUser_R(fromDate, endDate);
            body.Append("<tr><td>二手房普通房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = SecondHand.HouseResource(fromDate, endDate);
            IDCount = SecondHand.NewUser_H(fromDate, endDate);
            body.Append("<tr><td>二手房房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = SecondHand.Neighborhood(fromDate, endDate);
            IDCount = SecondHand.NewUser_N(fromDate, endDate);
            body.Append("<tr><td>二手房小区</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            IDCount = SecondHand.Total(fromDate, endDate);
            body.Append("<tr><td>二手房排重</td><td>-</td><td>" + IDCount + "</td></tr>");
            #endregion

            #region rent
            collectionCount = Rent.EHouseResource(fromDate, endDate);
            IDCount = Rent.NewUser_E(fromDate, endDate);
            body.Append("<tr><td>租房电商房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            collectionCount = Rent.RegHouseResource(fromDate, endDate);
            IDCount = Rent.NewUser_R(fromDate, endDate);
            body.Append("<tr><td>租房普通房源</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");

            IDCount = Rent.Total(fromDate, endDate);
            body.Append("<tr><td>租房排重</td><td>-</td><td>" + IDCount + "</td></tr>");
            #endregion

            #region knowledge
            collectionCount = Knowledge.KnowledgeCol(fromDate, endDate);
            IDCount = Knowledge.NewUser_Know(fromDate, endDate);
            body.Append("<tr><td>知识</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");
            #endregion

            #region furniture
            collectionCount = Furniture.FurnitureCol(fromDate, endDate);
            IDCount = Furniture.NewUser_Fur(fromDate, endDate);
            body.Append("<tr><td>家居装修</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");
            #endregion

            #region building
            collectionCount = Building.BuildingCol(fromDate, endDate);
            IDCount = Building.NewUser_Buil(fromDate, endDate);
            body.Append("<tr><td>写字楼商铺</td><td>" + collectionCount + "</td><td>" + IDCount + "</td></tr>");
            #endregion

            body.Append("</table>");

            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("sunkai.bj@fang.com");
                    mail.To.Add("liuna-bj@fang.com");
                    mail.To.Add("licheng.bj@fang.com");
                    mail.CC.Add("liuliwei@fang.com");
                    mail.CC.Add("zhanghao@fang.com");
                    mail.CC.Add("jiangjie@fang.com");
                    mail.Bcc.Add("sketernally@qq.com");
                    //mail.To.Add("524436986@qq.com");
                    mail.Body = body.ToString();
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.Subject = "本周(" + DateTime.Parse(fromDate).ToString("MM.dd") + "-"
                        + DateTime.Parse(endDate).AddDays(-1).ToString("MM.dd") + ")收藏数据";
                    mail.IsBodyHtml = true;

                    var smtp = new SmtpClient("mail.fang.com");
                    smtp.Credentials = new NetworkCredential("sunkai.bj@fang.com", "5b5951ef");
                    smtp.Send(mail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\n" + e.Source + "\n\n" + e.InnerException);
                Console.ReadKey(true);
            }
        }
    }
}
