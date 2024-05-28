namespace MultiThreadingApp
{
    internal class Program
    {
        static void TestThread()
        {
            int interval = 1000;
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine($"系统当前时间A:{DateTime.Now:HH:mm:ss}");
                Thread.Sleep( interval );
            }
        }

        static void TestThread2()
        {
            Console.WriteLine("测试子线程.");
        }

        static void TestThreadParam(object? param)
        {
            int.TryParse(param?.ToString(), out int interval);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"系统当前时间B:{DateTime.Now:HH:mm:ss}");
                Thread.Sleep(interval);
            }
        }

        static int TestTask(object? num)
        {
            return (int)num;
        }

        static void Main(string[] args)
        {
            ThreadStart startThread = new ThreadStart(TestThread);
            startThread += TestThread2;
            Thread thread = new Thread(startThread);
            thread.Start(); //Thread默认为前台线程，主线程等待执行完毕后才结束

            Thread threadParam = new Thread(new ParameterizedThreadStart(TestThreadParam));
            threadParam.IsBackground = true;    //主线程执行完毕自动结束后台线程
            threadParam.Start(2000);

            Task task = new Task(TestThread);
            task.Start();

            Task<int> task2 = new Task<int>(TestTask, 6);
            task2.Start();

            Task.Run(() => { Console.WriteLine("Task Run"); });

            Thread.Sleep(5000);
        }
    }
}
