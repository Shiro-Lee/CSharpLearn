
#define PI

namespace TestApp
{
    class Publisher
    {
        public static void SayHello() => Console.WriteLine("Hello!");
        public static void SayGoodbye() => Console.WriteLine("Goodbye!");
    }

    class Program
    {
        public delegate void DoSth();
        public event DoSth? SaySth;
        public void ExecDoSth(DoSth sth) => sth.Invoke();

        public static void Main()
        {
            Program pro = new();
            pro.SaySth += Publisher.SayHello;
            pro.SaySth += Publisher.SayGoodbye;
            pro.SaySth();
            pro.SaySth.Invoke();
            pro.ExecDoSth(pro.SaySth);
        }
    }
}