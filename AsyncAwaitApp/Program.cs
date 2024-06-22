#define TestCancellationToken

namespace AsyncAwaitApp
{
    internal class Program
    {
		static async Task TestAsync()
		{
			await Task.Delay(4000);
			Console.Out.WriteLine("Async!");
		}

		static async Task<int> TestAsyncResult()
        {
            int result = await Task.Run(() => { 
                Thread.Sleep(4000);
                Console.WriteLine("AsyncResult!");
                return 0;
            });
			return result;
        }

		static async Task<string> TestAsyncException()
		{
			try
			{
				//async void方法抛出的异常无法被捕获，只能用返回Task或Task<TResult>的async方法
				await Task.Run(() => {
					int num = new Random().Next(1, 100);
					if (num % 2 == 1)
						throw new Exception();
					}
				);
				return "Pass";
			}
			catch (Exception)
			{
				return "Fail";
			}
		}

		static void Main(string[] args)
		{
#if TestAsyncResult
			Task<int> task = TestAsyncResult();
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Hello, World!");
				Thread.Sleep(1000);
				if (task.IsCompleted)
					break;
			}
			Console.WriteLine($"Task completed, result={task.Result}");
#endif

#if TestAsync
			Task task = TestAsync();
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Hello, World!");
				Thread.Sleep(1000);
				if (task.IsCompleted)
					break;
			}
			Console.WriteLine("Task completed");
#endif

#if TestAsyncException
			Task<string> task = TestAsyncException();
			Console.Out.WriteLine(task.Result);
#endif

#if TestCancellationToken
			CancellationTokenSource source = new CancellationTokenSource();
			Task<int> task = Task.Run(async ()=>
			{
				await Task.Delay(500, source.Token);
				await Console.Out.WriteLineAsync("Not cancelled!");
				return 0;
			});
			source.Cancel();
			Thread.Sleep(1000);
			Console.WriteLine($"Task Status: {task.Status}");
			if (task.Status == TaskStatus.RanToCompletion)
				Console.WriteLine($"Task Result: {task.Result}");
			source.Dispose();

#endif
		}
	}
}
