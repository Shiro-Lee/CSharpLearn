namespace EventApplication
{
    public delegate void GreetingPeople(string name);
    internal class Program
    {
        public event GreetingPeople? GreetEvent;    //先声明委托
        public static void Main(string[] args)
        {
            Program program = new Program();

            program.GreetEvent += Greet.GreetChinese;
            program.GreetEvent.Invoke("杰克");
            program.GreetEvent -= Greet.GreetChinese;

            program.GreetEvent += Greet.GreetEnglish;
            program.GreetEvent.Invoke("Jack");
            program.GreetEvent -= Greet.GreetEnglish;
        }
    }

    public class Greet
    {
        public static void GreetChinese(string name)
        {
            Console.WriteLine("你好，{0}！", name);
        }

        public static void GreetEnglish(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}