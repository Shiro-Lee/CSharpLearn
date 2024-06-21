using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Book
    {
        private string name;
        private int price;
        public Book(string name, int price = 0)
        {
            this.name = name;
            this.price = price;
        }
        public string Name { get => name; set => name = value; }
        public int Price
        {
            get { return price; }
            set { price = value >= 0 ? value : 0; }
        }
        ~Book()
        {
            Console.WriteLine("GG");
        }
    }

    struct Keyboard
    {
        public int price = 0;
        public string name = string.Empty;

        public Keyboard() { }
        public Keyboard(int p) { price = p; }
    }

    class Person
    {
        public string Name { get; set; } = "Lime";
        public int Age { get; set; } = 0;
    }

    public class Program
    {
        enum Seasons { SPRING, SUMMER, AUTUMN, WINTER }

        public void Swap(ref int a, ref int b)
        {
            (b, a) = (a, b);
        }

        public void Output(int a, int b, out int sum, out int sub)
        {
            sum = a + b;
            sub = a - b;
        }

        public static void Deal(object obj)
        {
            if (obj is int i)
            {
                Console.WriteLine(i + 1);
            }
            if (obj is string str)
            {
                Console.WriteLine(str + "!!!");
            }
            if (obj is char ch)
            {
                Console.WriteLine(ch);
            }
        }

        static void Main()
        {
            //while (true)
            //{
            //    Console.WriteLine(Console.ReadLine());
            //    break;
            //}

            //foreach (var item in Enum.GetValues(typeof(Seasons)))   // 遍历枚举
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadKey();
            //double dNum = 1.23;
            //string str = dNum.ToString("N3");
            //Console.WriteLine(str);

            //int[] nums = { 1, 2, 3, 4, 5 };
            //IEnumerable<int> sels = from num in nums where num%2==0 select num;
            //foreach (var sel in sels)
            //    Console.Write($"{sel} ");
            //Console.WriteLine();

            //int a = 1, b = 2;
            //Program pro = new Program();
            //pro.Swap(ref a, ref b);
            //pro.Output(a, b, out int sum, out int sub);
            //Console.WriteLine("sum={0}, sub={1}", sum, sub);

            #region 内插字符串
            Book book = new Book("《乌合之众》", 20);
            string str = $"Name={book.Name}, Price={book.Price}";
            Console.WriteLine(str);
            #endregion

            //#region 逐字字符串
            //str = @"123\t456\n";
            //Console.WriteLine(str);
            //#endregion

            //char[] bytes = str.ToArray();
            //foreach (char bt in bytes)
            //{
            //    Console.Write(bt);
            //}

            //Console.WriteLine();
            //dynamic dyn = new Person() { Name = "Marija", Age=17 };
            //dyn.Age += 1;
            //object obj = 5;
            //var v = "str";
            //Console.WriteLine($"dyn={dyn.Name},obj={obj},var={v}");

            //Deal(1);
            //Deal("Hell");
            //Deal('?');
            //Deal(obj);
            //Deal(dyn);
            //var person = new { Name = "Jack", Age = 16, Height = 170.5 };
            //Console.WriteLine($"Name:{person.Name}, Age:{person.Age}, Height:{person.Height}");

            //int length = 5;
            //int[] array = { 1, 2, 3, 4, 5 } ;
            //array = new int[5];
            //array = new int[] { 1, 2, 3, 4, 5 };
            //ArrayList arrayList = new ArrayList();
            //List<int> list = new List<int>();
            //LinkedList<int> linkedList = new LinkedList<int>();
            //for (int i = 0; i < length; i++)
            //{
            //    array[i] = i;
            //    arrayList.Add(i);
            //    list.Add(i);
            //    linkedList.AddLast(i);
            //}

            //string[] strArr = { "Joker", "Skull", "Panther"};
            //string str = string.Join(",", strArr);
            //string[] strArr2 = str.Split(',');

            List<string> list = new List<string>();
            string[] strArr = { "Joker", "Skull", "Panther" };
            string[] strX = new string[5];
            strArr.CopyTo(strX, 1);

            bool b = strArr.Contains("Joker");
            for (int i = 0; i < strArr.Length; i++)
            {
                list.Add(strArr[i]);
            }
            list.Clear();
            b = list.Contains("Joker");
            list = new List<string>(strArr);
            list.AddRange(strArr);
            string strJoin = string.Join(",", list.ToArray());

            #region 交错数组
            string[][][] strCrossArr = new string[2][][]
                {
                    new string[2][]
                    {
                        new string[3]
                        { "1", "2", "3" },
                        new string[1]
                        { "4" }
                    },
                    new string[][]
                    {
                        new string[]
                        { "6", "7" },
                        new string[]
                        { "8", "9" ,"0"}
                    }
                };
            string strCross = strCrossArr[0][0][0];
            #endregion

            #region 多维数组
            int[,,] nMultiArr = new int[3, 2, 3]{
                {
                    { 1, 2, 3 },
                    { 1, 2, 3 },
                },
                {
                    { 3, 4, 5 },
                    { 3, 4, 5 }
                },
                {
                    { 5, 6, 7 },
                    { 5, 6, 7 }
                }
            };
            int nMulti = nMultiArr[0, 1, 2];
            int bound1 = nMultiArr.GetUpperBound(0);
            int bound2 = nMultiArr.GetUpperBound(1);
            #endregion
        }
    }

}
