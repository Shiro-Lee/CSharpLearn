using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//数组
namespace ArrayApplication
{
	class MyArray
	{

		//多维数组
		static void MultiArray()
		{
			int[,] arr = new int[2, 3];
			int rank = arr.Rank;
			Console.WriteLine("多维数组维数为{0}", rank);
			int n = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[i, j] = n++;
				}
			}
			foreach (int num in arr)
			{
				Console.Write(num + " ");
			}
		}

		//数组平均值
		static double GetArrayAverage(int[] arr)
		{
			double res = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				res += arr[i];
			}
			return res / arr.Length;
		}

		//参数数组
		static int AddElements(params int[] arr)
		{
			int sum = 0;
			foreach (int i in arr)
			{
				sum += i;
			}
			return sum;
		}

		//逆转数组
		static void ArrayReverse(int[] arr)
		{
			Array.Reverse(arr);
			Console.Write("逆转数组：");
			foreach (int i in arr)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}

		//排序数组
		static void ArraySort(int[] arr)
		{
			Array.Sort(arr);
			Console.Write("排序数组：");
			foreach (int i in arr)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}

		static void BubbleSort(int[] arr)
		{
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - i - 1; j++)
				{
                    if (arr[j+1] > arr[j])
                    {
						int temp = arr[j];
						arr[j] = arr[j+1];
						arr[j+1] = temp;
                    }
                }
            }
        }

		static void Main(string[] args)
		{
			int[] arr = { 7, 4, 6, 5, 9, 8, 1, 0, 2, 3 };
			BubbleSort(arr);
			Console.WriteLine(arr.ToList<int>());
            Console.ReadKey();
        }
	}
}
