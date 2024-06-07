#define TestMyThread

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

        static void TestCopyImg()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dirPath = desktopPath + @"\SMV图片\程序1_模拟相机1";
            if (!Directory.Exists(dirPath))
                return;
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            FileSystemInfo[] fsi = dir.GetFileSystemInfos();
            foreach (FileSystemInfo info in fsi)
            {
                if (info is FileInfo)
                    File.Copy(info.FullName, $"{desktopPath}\\{info.Name}");
            }
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
            Console.WriteLine(num);
            return 0;
        }
        
        static object obj = new();

        static List<int> list = [];

        static void ListAddThread()
        {
            while (true)
            {
                lock (obj)
                {
                    if (list.Count < 100)
                    {
                        int last = list.Count > 0 ? list.Last() : 0;
                        list.Add(last + 1);
                        Console.WriteLine($"{Thread.CurrentThread.Name}添加: {last + 1}");
                    }
                    else
                        break;
                }
                Thread.Sleep(1);
            }
        }

        static int GetRetVal()
        {
            int ret = 0;
            for (int i=0; i<100; i++)
            {
                ret += i;
                Thread.Sleep(0);
            }
            return ret;
        }

        static void Main(string[] args)
        {
#if TestThread
            ThreadStart startThread = new ThreadStart(TestThread);  //无参方法线程
            //startThread += TestThread2;
            Thread thread = new Thread(startThread);
            //thread.IsBackground = true;
            thread.Start(); //Thread默认为前台线程，主线程等待执行完毕后才结束

            Console.WriteLine("主线程处理");
            Thread.Sleep(3000);

            Console.WriteLine("子线程加入主线程");
            thread.Join();

            Console.WriteLine("主线程结束");

            //Thread thread = new Thread(TestCopyImg);
            //thread.Start();
            //Console.WriteLine("Waiting...");
#endif

#if TestParameterizedThread
            //Thread threadParam = new Thread(new ParameterizedThreadStart(TestThreadParam)); //带参方法线程
            //threadParam.IsBackground = true;    //主线程执行完毕自动结束后台线程
            //threadParam.Start(2000);
#endif

#if TestThreadPool
            ThreadPool.QueueUserWorkItem(TestThreadParam, 2000);
            Thread.Sleep(5000);
#endif

#if TestTask
            //Task task = new Task(TestThread);
            //task.Start();

            //Task<int> task2 = new(TestTask, 6);
            //task2.Start();

            //Task.Run(() => { Console.WriteLine("Task Run"); });

            Action<object> action = (obj) =>
            {
                Console.WriteLine($"obj={obj}, TaskId={Task.CurrentId}, ThreadId={Thread.CurrentThread.ManagedThreadId}");
            };

            Task t1 = new Task(action, "t1");
            t1.Start();
            Console.WriteLine($"t1 has been launched. (Main thread Id={Thread.CurrentThread.ManagedThreadId})");
            t1.Wait();

            Task t2 = Task.Factory.StartNew(action, "t2");
            t2.Wait();

            Task t3 = Task.Run(() =>
            {
                Console.WriteLine($"obj=t3, TaskId={Task.CurrentId}, ThreadId={Thread.CurrentThread.ManagedThreadId}");
            });
            t3.Wait();

            Task t4 = new Task(action, "t4");
            t4.RunSynchronously();
            t4.Wait();

            Task<int> t5 = Task.Run(() => { return 0; });
            t5.Wait();
            Console.WriteLine($"t5 returns: {t5.Result}");

#endif

#if TestMyThread

            #region Thread
            //Thread t1 = new Thread(ListAddThread);
            //Thread t2 = new Thread(ListAddThread);
            //t1.Name = "线程1";
            //t2.Name = "线程2";
            //t1.Start();
            //t2.Start();
            //t1.Join();
            //t2.Join();
            #endregion
            #region Task
            //Task ts1 = new Task(ListAddThread);
            //Task ts2 = new Task(ListAddThread);
            //ts1.Start();
            //ts2.Start();
            //ts1.Wait();
            //ts2.Wait();
            #endregion
            //for (int i = 0;i < list.Count; i++)
            //{
            //    Console.Write($"{list[i]} ");
            //}
            //Console.WriteLine();
            #region Task<TResult>
            Task<int> task = Task.Run(GetRetVal);
            int ret = task.Result;
            Console.WriteLine(ret);
            #endregion
#endif
        }
    }
}
