namespace DelegateApplication
{
    public class Sum
    {
        public static int Sum0(int a, int b) => a + b;
        public static int Sum1(int a, int b) => a + b + 1;
        public static int Sum2(int a, int b) => a + b + 2;

        public static void Print1(int a, int b) => Console.WriteLine(a + b);
        public static void Print2(int a, int b) => Console.WriteLine(a + b + 1);
        public static void Print3(int a, int b) => Console.WriteLine(a + b + 2);
    }

    internal class Program
    {
        public delegate int SumDelegate(int a, int b);
        public delegate void PrintDelegate(int a, int b);
        static void Main(string[] args)
        {
            SumDelegate sums = Sum.Sum0; //= new SumDelegate(Sum.Sum0);
            sums += Sum.Sum1;
            sums += Sum.Sum2;
            int res = sums(1, 2);   //5，有返回值时取最后一个返回值
            Console.WriteLine(res);

            PrintDelegate prints = Sum.Print1;
            prints += Sum.Print2;
            prints += Sum.Print3;
            prints(1, 2);   //3 4 5

            SumDelegate anonySum = delegate(int a, int b) { return a + b - 1; };   //匿名方法
            res = anonySum(1, 2);
            Console.WriteLine(res);
            PrintDelegate anonyPrint = (a, b) => Console.Write(a + b - 1);  //lambda表达式创建匿名方法委托实例
            anonyPrint(1, 2);
        }
    }
}