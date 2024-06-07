#define QueryExpression
//#define ExtensionMethod

using System.Collections;

namespace LinqApp
{
    class Student
    {
        public string Name { get; set; } = "N/A";
        public int Age { get; set; } = 1;
        public string Sex { get; set; } = "Male";
        public Student() { }
        public Student(string name, int age, string sex) { Name = name; Age = age; Sex = sex; }
    }

    internal class Program
    {
        static void PrintEnumerable(IEnumerable enumerable, string description)
        {
            Console.Write($"{description}: ");
            foreach (var item in enumerable)
                Console.Write($"{item} ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
#if ExtensionMethod
            int[] nums1 = [1, 4, 9, 7, 9, 6, 2, 8, 3, 7, 1] ;
            int[] nums2 = [3, 4, 5, 1, 8, 8, 0];

            Console.Write("nums1: ");
            Array.ForEach(nums1, x=>Console.Write($"{x} "));
            Console.WriteLine();

            Console.Write("nums2: ");
            Array.ForEach(nums2, x => Console.Write($"{x} "));
            Console.WriteLine();


            //查询语法
            IEnumerable<int> list1 = from int x in nums1
                                     where (x & 1) == 0
                                     orderby (x)
                                     select x;
            //方法语法
            IEnumerable<int> list2 = nums1.Where(x => (x & 1) == 0).OrderByDescending(x => x);   //按值本身的大小排序

            PrintEnumerable(list1, "list1");

            #region
            int num = 0;
            num = nums1.FirstOrDefault(x => x == 5); //第一个符合条件的值，如果没有则返回默认值
            Console.WriteLine($"FirstOrDefault(x => x == 5): {num}");

            num = nums1.Last(x => x%3 == 0); //最后一个符合条件的值
            Console.WriteLine($"Last(x => x%3 == 0): {num}");

            num = nums1.Single(x => x == 6); //唯一符合条件的值
            Console.WriteLine($"Single(x => x == 6): {num}");

            bool flag = nums1.Any(x => x == 0);
            Console.WriteLine($"Any(x => x == 0): {flag}");
            #endregion

            #region
            IEnumerable<int> list3 = nums1.Distinct();   //去重
            PrintEnumerable(list3, "Distinct");

            list3 = nums1.Intersect(nums2);   //交集
            PrintEnumerable(list3, "Intersect");

            list3 = nums1.Except(nums2);   //差集
            PrintEnumerable(list3, "Except");

            list3 = nums1.Union(nums2);    //并集，Concat连接
            PrintEnumerable(list3, "Union");

            list3 = nums1.Take(5);
            PrintEnumerable(list3, "Take5");

            list3 = nums1.TakeWhile(x=>x<5);
            PrintEnumerable(list3, "TakeWhile<5");

            IEnumerable<string> list4 = nums1.Zip(nums2, (x, y) => string.Format($"x={x},y={y}")) ;
            PrintEnumerable(list4, "Zip");

            ArrayList arr = [123, 456, 7, 89];
            IEnumerable<int> arr2 = arr.Cast<int>();    //非泛型转换为泛型
            PrintEnumerable(arr2, "arr2");

            #endregion

#endif

#if QueryExpression

            List<Student> students = new List<Student>() { 
                new Student("Joker", 17, "Male"),
                new Student("Skull", 17, "Male"),
                new Student("Panther", 17, "Female"),
                new Student("Fox", 18, "Male"),
                new Student("Queen", 18, "Female")
            };

            IEnumerable<string> selected = students.Where(x=>x.Age == 17 && x.Sex == "Male").Select(x=>x.Name);
            PrintEnumerable(selected, "Male Freshmen");

            selected = from Student student in students
                       where student.Age == 18 && student.Sex =="Female"
                       select student.Name;
            PrintEnumerable(selected, "Female Sophomore");

            IEnumerable<IGrouping<string, Student>> group = from Student student in students 
                                                            orderby (student.Age)
                                                            group student by student.Sex into g
                                                            select g;
            foreach(IGrouping<string, Student> g in group)
            {
                Console.Write($"Group {g.Key}: ");
                foreach (Student student in g)
                {
                    Console.Write($"{student.Name} ");
                }
                Console.WriteLine();
            }
#endif
        }
    }
}
