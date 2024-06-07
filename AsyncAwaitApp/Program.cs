namespace AsyncAwaitApp
{
    internal class Program
    {
        static async void TestAsync()
        {
            await Task.Run(() => { Console.WriteLine("Async!"); });
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
