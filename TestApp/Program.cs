namespace TestApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public static Task<T> ThrowTask<T>() where T : Exception, new() { throw new T(); }

		public int AddNum(int a, int b) => a + b;

		public string CombineString(string str1, string str2) => string.Format("{0} {1}", str1, str2);

		public bool IsWeekend(DayOfWeek day) => day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
	}
}
