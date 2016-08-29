using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    public class Student : ICloneable
    {
        //C#6新特性，快速属性赋默认值
        public string Name { get; set; } = "sunkai";
        public int? Id { get; set; } = 1;
        public string Sex { get; set; } = "male";

        public Student stud;

         Student() { }
         Student(string name)
        {
            this.Name = name;
        }
        public static Student instance()
        {
            return new Student();
        }
        ~Student()
        {
            Console.WriteLine("disposed");
            using (StreamWriter sw = new StreamWriter("D:\\text.txt",true))
            {
                sw.WriteLine($"{DateTime.Now}调用析构函数");
                sw.Flush();
            }
        }

        public object Clone()
        {
            Student s = new Student();
            s.Name = this.Name;
            s.Id = this.Id;
            s.Sex = this.Sex;
            s.stud = new Student { Sex = this.stud.Sex };

            return s;
        }
    }
}
