
namespace TestApp
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int x) { val = x; }
    }

    public class Program
	{
        public static int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (p1, p2) => p1[0] == p2[0] ? p1[1] - p2[1] : p2[0] - p1[0]);
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (people[j][1] < j)
                        (people[j], people[j - 1]) = (people[j - 1], people[j]);
                    else
                        break;
                }
            }
            return people;
        }

        public static int[][] DiagonalSort(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            List<List<int>> lists = new(m + n - 1);
            for (int i = 0; i < m + n - 1; i++)
                lists.Add(new List<int>());
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    lists[j - i + m - 1].Add(mat[i][j]);
            foreach (List<int> list in lists)
                list.Sort();
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    mat[i][j] = lists[j - i + m - 1][^1];
                    lists[j - i + m - 1].RemoveAt(lists[j - i + m - 1].Count - 1);
                }
            return mat;
        }

        public static int MaximumValue(string[] strs)
        {
            int max = 0;
            foreach (string str in strs)
            {
                bool isLetter = false;
                foreach (char ch in str)
                {
                    if (char.IsLetter(ch))
                        isLetter = true;
                    break;
                }
                max = Math.Max(max, isLetter ? str.Length : int.Parse(str));
            }
            return max;
        }

        static void Main(string[] args)
		{
            //int[][] people = [[9, 0], [7, 0], [1, 9], [3, 0], [2, 7], [5, 3], [6, 0], [3, 4], [6, 2], [5, 2]];
            //ReconstructQueue(people);

            //int[][] mat = [[3, 3, 1, 1], [2, 2, 1, 2], [1, 1, 1, 2]];
            //DiagonalSort(mat);

            //string[] strs = ["3glko", "1"];
            //MaximumValue(strs);

            //Console.WriteLine("Hello, World!");
        }

		public static Task<T> ThrowTask<T>() where T : Exception, new() { throw new T(); }

		public int AddNum(int a, int b) => a + b;

		public string CombineString(string str1, string str2) => string.Format("{0} {1}", str1, str2);

		public bool IsWeekend(DayOfWeek day) => day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
	}
}
