using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonApp
{
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public string Codename { get; set; } = string.Empty;
        //[JsonIgnore]序列化/反序列化时忽略属性
        public int Age { get; set; } = 0;
        //[JsonPropertyName("SSex")]指定映射到json字符串中的属性名
        public bool Sex { get; set; } = true;
        public List<string> Personas { get; set; } = [];
    }

    internal class Program
    {
        static Student[] _students = [
                new() { Name = "Ren Amamiya", Codename="Joker", Age = 17, Sex = true, Personas=["Arsene", "Satanael"] },
                new() { Name = "Ryuji Sakamoto", Codename="Skull", Age = 17, Sex = true, Personas=["Captain Kidd"] },
                new() { Name = "Morgana", Codename="Mona", Age = 1, Sex = true, Personas=["Zorro"] },
                new() { Name = "Ann Takamaki", Codename="Panther", Age = 17, Sex = false, Personas=["Carmen"] },
            ];
        static string _filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Students.txt";

        static void Main(string[] args)
        {
            #region 对象序列化为Json字符串
            using (StreamWriter writer = new(_filepath))
            {
                foreach (Student student in _students)
                {
                    string serialize = JsonSerializer.Serialize(student);
                    writer.WriteLine(serialize);
                }
            }
            #endregion

            #region 反序列化Json字符串为对象
            List<Student?> students2 = [];
            using (StreamReader reader = new(_filepath))
            {
                while (!reader.EndOfStream)
                {
                    string? str = reader.ReadLine();
                    Student? student = JsonSerializer.Deserialize<Student>(str!);
                    students2.Add(student);
                }
            }
            #endregion

            #region JsonElement、JsonNode、JsonDocument
            string s = "{\"Name\":\"Haru Okumura\",\"Codename\":\"Noir\",\"Age\":18,\"Sex\":false,\"Personas\":[\"Milady\"]}";
            Student? stu = JsonSerializer.Deserialize<Student>(s);

            JsonNode? node = JsonNode.Parse(s); //字符串转JsonNode
            string? name = node?["Name"]?.ToString();
            node = JsonSerializer.SerializeToNode(stu)!.Root; //对象转JsonNode
            string? persona = node!["Personas"]!.AsArray()[0]?.ToString();

            JsonElement element = JsonSerializer.SerializeToElement(stu);   //对象转JsonElement
            name = element.GetProperty("Name").ToString();
            string? codename = element.GetProperty("Codename").ToString();

            JsonDocument document = JsonSerializer.SerializeToDocument(stu);
            #endregion
        }
    }
}
