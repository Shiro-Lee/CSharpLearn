#define InsertionSort

namespace SortApp
{
    internal class Program
    {
        static int[] Nums { get; set; } = [9, 1, 0, 4, 6, 5, 8, 3, 2, 7];

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        static void SelctionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int index = i;
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[j] < nums[index])
                        index = j;
                if (index != i)
                    (nums[i], nums[index]) = (nums[index], nums[i]);
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        static void BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j+1] < nums[j])
                    {
                        (nums[j+1], nums[j]) = (nums[j], nums[j+1]);
                        flag = true;
                    }
                }
                if (!flag)  //没有发生交换，提前结束
                    break;
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        static void InsertionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if ((nums[j] < nums[j-1]))
                        (nums[j], nums[j-1]) = (nums[j-1], nums[j]);
                }
            }
        }

        static void Main(string[] args)
        {
#if SelctionSort
            SelctionSort(Nums);
#endif

#if BubbleSort
            BubbleSort(Nums);
#endif

#if InsertionSort
            InsertionSort(Nums);
#endif

            Array.ForEach(Nums, Console.Write);
            Console.WriteLine();
        }
    }
}
