using System.Xml;
using System.Xml.Serialization;

namespace XmlApp
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Sex { get; set; } = string.Empty;
        public int Salary { get; set; } = 0;
    }

    internal class Program
    {
        static Employee[] _employees = [
            new() { Name = "Lime",  Age = 17, Sex = "Male", Salary = 9000 },
            new() { Name = "Alice",  Age = 17, Sex = "Female", Salary = 8500 },
            new() { Name = "Meow",  Age = 3, Sex = "Male", Salary = -1000 },
        ];
        static string _filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Employees.xml";

        static void WriteXml()
        {
            //创建xml文档
            XmlDocument xmldoc = new();

            //加入xml声明
            XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(xmldec);

            //创建注释节点
            XmlNode comment = xmldoc.CreateComment("这是一个注释");
            xmldoc.AppendChild(comment);

            //加入一个根元素
            XmlElement employees = xmldoc.CreateElement("Employees");
            xmldoc.AppendChild(employees);

            //根元素加入一些子元素
            for (int i = 0; i < _employees.Length; i++)
            {
                //创建子节点并设置节点属性
                XmlElement employee = xmldoc.CreateElement("Employee" + i);
                employee.SetAttribute("Name", _employees[i].Name);

                //创建孙节点
                XmlElement age = xmldoc.CreateElement("Age");
                age.InnerText = _employees[i].Age.ToString();
                employee.AppendChild(age);

                XmlElement sex = xmldoc.CreateElement("Sex");
                sex.InnerText = _employees[i].Sex;
                employee.AppendChild(sex);

                XmlElement salary = xmldoc.CreateElement("Salary");
                salary.InnerText = _employees[i].Salary.ToString(); //new Random().Next(3000, 10000).ToString();
                employee.AppendChild(salary);

                employees.AppendChild(employee);
            }
            //xmldoc.Save(_filepath);
            using (StreamWriter sw = new(_filepath))
            {
                xmldoc.Save(sw);
                Console.WriteLine("写入文件:" + _filepath);
            }
        }

        static void ReadXml()
        {
            XmlDocument xmldoc = new();
            List<Employee> employees = [];
            //xmldoc.Load(_filepath);
            using (StreamReader sr = new(_filepath)) 
            {
                Console.WriteLine("从文件读取:" + _filepath);
                xmldoc.Load(sr);
                XmlNode node = xmldoc.SelectSingleNode("Employees")!;
                foreach (XmlNode n in node.ChildNodes)
                {
                    Employee employee = new();
                    employee.Name = n.Attributes!["Name"]!.Value;//n.Attributes!["Name"]!.ToString()!;
                    employee.Age = int.Parse(n["Age"]!.InnerText);
                    employee.Sex = n["Sex"]!.InnerText;
                    employee.Salary = int.Parse(n["Salary"]!.InnerText);
                    employees.Add(employee);
                    Console.WriteLine($"Name:{employee.Name}, Age:{employee.Age}, Sex:{employee.Sex}, Salary:{employee.Salary}");
                }
            }
        }

        static void SerializeXml()
        {
            try
            {
                string str;
                XmlSerializer serializer = new(typeof(Employee[]));

                #region 序列化为Xml字符串
                using (StringWriter sw = new())
                {
                    serializer.Serialize(sw, _employees/*[0]*/);
                    str = sw.ToString();
                }
                #endregion

                #region Xml字符串反序列化为对象
                using (StringReader sr = new(str)) 
                {
                    Employee[]? employees = serializer.Deserialize(sr) as Employee[];
                }
                #endregion
            }
            catch (Exception)
            {
                Console.WriteLine("转换异常");
                throw;
            }
        }

        static void Main(string[] args)
        {
            WriteXml();
            ReadXml();
            SerializeXml();
        }
    }
}
