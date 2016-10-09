using System;
using System.Collections.Generic;
using System.Data;
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

            var con = System.Configuration.ConfigurationManager.ConnectionStrings["myfang_r"].ConnectionString;
            var cities = @"阿坝州
,阿拉尔
,阿拉善盟
,阿里
,安达
,安吉
,安康
,安宁
,安庆
,安丘
,安顺
,安溪
,安阳
,澳门
,巴彦
,巴彦淖尔
,巴中
,巴州
,霸州
,白城
,白山
,白银
,百色
,蚌埠
,包头
,宝鸡
,宝应
,保山
,北海
,本溪
,毕节
,璧山
,宾县
,宾阳
,亳州
,博尔塔拉
,博罗
,沧州
,昌都
,昌乐
,昌黎
,昌邑
,长岛
,长丰
,长葛
,长乐
,长清
,长寿
,长兴
,长治
,常宁
,常熟
,巢湖
,朝阳
,潮州
,郴州
,承德
,池州
,赤峰
,崇州
,崇左
,滁州
,楚雄
,淳安
,慈溪
,达州
,大理
,大同
,大兴安岭
,大邑
,大足
,丹东
,儋州
,当涂
,当阳
,德宏
,德化
,德惠
,德清
,德阳
,德州
,登封
,邓州
,迪庆
,垫江
,定西
,定州
,东方
,东港
,东海
,东台
,东营
,都江堰
,峨眉山
,鄂尔多斯
,鄂州
,恩平
,恩施
,法库
,繁昌
,肥城
,肥东
,肥西
,丰城
,丰都
,丰县
,凤城
,奉化
,奉节
,涪陵
,福安
,福清
,抚顺
,抚州
,阜宁
,阜新
,阜阳
,富阳
,甘南
,甘孜
,赣州
,高碑店
,高淳
,高陵
,高密
,高邮
,公主岭
,巩义
,固原
,固镇
,广安
,广饶
,广元
,贵港
,果洛
,哈密
,海安
,海北
,海城
,海东
,海拉尔
,海林
,海门
,海宁
,海西
,海盐
,海阳
,邯郸
,汉南
,汉中
,合川
,和田
,河池
,河源
,菏泽
,贺州
,鹤壁
,鹤岗
,鹤山
,黑河
,横县
,衡阳
,红河
,呼伦贝尔
,湖州
,葫芦岛
,户县
,桦甸
,怀化
,怀仁
,怀远
,淮北
,淮南
,黄冈
,黄南
,黄山
,惠安
,惠东
,霍邱
,鸡西
,吉安
,即墨
,济宁
,济阳
,济源
,蓟州
,冀州
,佳木斯
,嘉峪关
,简阳
,建德
,江都
,江津
,姜堰
,胶南
,胶州
,焦作
,揭阳
,金昌
,金湖
,金坛
,金堂
,锦州
,进贤
,晋城
,晋中
,晋州
,京山
,荆门
,荆州
,景德镇
,靖安
,靖江
,酒泉
,句容
,喀什
,开封
,开平
,开县
,开阳
,康平
,克拉玛依
,克孜勒苏
,库尔勒
,奎屯
,拉萨
,来宾
,莱芜
,莱西
,莱阳
,莱州
,兰考
,蓝田
,老河口
,乐清
,乐山
,乐亭
,耒阳
,醴陵
,丽江
,丽水
,溧阳
,连江
,连云港
,凉山
,梁平
,辽阳
,辽源
,辽中
,聊城
,林芝
,临安
,临沧
,临汾
,临海
,临清
,临朐
,临夏
,临猗
,临沂
,浏阳
,柳州
,六安
,六盘水
,龙海
,龙口
,龙门
,龙岩
,陇南
,娄底
,庐江
,泸州
,吕梁
,栾川
,滦南
,滦县
,罗定
,罗源
,洛宁
,漯河
,马鞍山
,茂名
,眉山
,梅州
,孟津
,绵阳
,闽清
,牡丹江
,内江
,那曲
,南安
,南充
,南平
,南阳
,宁德
,宁海
,宁乡
,农安
,怒江
,攀枝花
,盘锦
,沛县
,彭州
,蓬莱
,邳州
,平顶山
,平度
,平湖
,平凉
,平山
,平潭
,平阴
,萍乡
,莆田
,濮阳
,普洱
,普兰店
,普宁
,七台河
,栖霞
,齐齐哈尔
,綦江
,启东
,迁安
,迁西
,潜江
,黔东南
,黔江
,黔南
,黔西南
,钦州
,青龙
,青州
,清徐
,清远
,清镇
,邛崃
,曲靖
,衢州
,泉港
,泉山
,任丘
,日喀则
,日照
,荣昌
,如东
,如皋
,汝阳
,汝州
,瑞安
,瑞金
,三河
,三门峡
,三明
,三沙
,山南
,汕头
,汕尾
,商河
,商洛
,商丘
,上饶
,上虞
,尚志
,韶关
,韶山
,邵阳
,绍兴
,深州
,神农架
,十堰
,石狮
,石柱
,石嘴山
,寿光
,沭阳
,双鸭山
,顺德
,朔州
,四平
,松原
,嵩县
,宿迁
,宿州
,睢宁
,绥化
,随州
,台安
,台山
,台州
,太仓
,泰安
,泰兴
,滕州
,天门
,天水
,铁岭
,通化
,通辽
,桐城
,桐庐
,桐乡
,铜川
,铜梁
,铜陵
,铜仁
,铜山
,潼南
,图木舒克
,吐鲁番
,瓦房店
,万宁
,万州
,望城
,渭南
,温岭
,文安
,文山
,乌海
,乌兰察布
,巫山
,无极
,吴江
,吴忠
,芜湖
,梧州
,五常
,五河
,五家渠
,五指山
,武安
,武隆
,武威
,舞钢
,西双版纳
,锡林郭勒盟
,锡林浩特
,仙桃
,咸宁
,湘西
,湘乡
,襄阳
,象山
,孝感
,忻州
,辛集
,新安
,新丰
,新建
,新津
,新乐
,新密
,新民
,新泰
,新乡
,新沂
,新余
,新郑
,信阳
,兴安盟
,兴化
,邢台
,修文
,许昌
,宣城
,雅安
,鄢陵
,延安
,延边
,盐城
,偃师
,阳春
,阳江
,阳曲
,阳泉
,伊川
,伊春
,依兰
,仪征
,宜宾
,宜城
,宜春
,宜都
,宜良
,宜兴
,宜阳
,益阳
,鹰潭
,荥阳
,营口
,邕宁
,永安
,永城
,永川
,永春
,永登
,永泰
,永州
,攸县
,余姚
,榆林
,榆树
,榆中
,禹州
,玉环
,玉林
,玉山
,玉树
,玉田
,玉溪
,元氏
,岳阳
,云浮
,云阳
,运城
,枣阳
,枣庄
,湛江
,张北
,张家港
,张家界
,张家口
,张掖
,章丘
,招远
,昭通
,赵县
,肇东
,肇庆
,肇源
,肇州
,镇海
,镇江
,枝江
,中牟
,中卫
,忠县
,钟祥
,舟山
,周口
,周至
,株洲
,诸城
,诸暨
,驻马店
,庄河
,资阳
,淄博
,自贡
,邹城
,邹平
,遵化
,遵义
";
            var arr = cities.Split(',').ToList();
            DataTable table = new System.Data.DataTable();
            SoufunLab.Framework.Data.SlDatabase.Fill(con, "select cityname from CityConfigure", table);
            //arr.ForEach(c =>
            //{
            var t = table.AsEnumerable().ToList();
                t.ForEach(r =>
                {
                    arr.ForEach(c =>
                    {
                        if (r[0].ToString() == c)
                            t.Remove(r);
                    });
                 
                });
            //});
            foreach (var i in t)
                Console.Write(i[0].ToString() + ",");

            Console.ReadKey(true);
        }
        static void StartStatistic(string seeddate)
        {
            var keyDate = DateTime.Parse(seeddate);//date of Friday
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
