using System;

//多态
namespace PolymorphismApplication
{
    abstract class Shape
	{
		abstract public int Area();
	}

	class Rectangle: Shape
	{
		private int m_nLength;
		private int m_nWidth;
		private static int m_nStaticNum;

		public int Length
		{
			get => m_nLength;
			set => m_nLength = value;
		}

		public int Width
		{
			get => m_nWidth;
			set => m_nWidth = value;
		}

		public static int StaticNum
		{
			get => m_nStaticNum;
			set => m_nStaticNum = value;
		}

		public Rectangle(int nL = 0, int nW = 0)
		{
			m_nLength = nL;
			m_nWidth = nW;
		}

		public override int Area() => m_nLength * m_nWidth;
    }

	class RectangleTest
	{
		public static void Main(string[] args)
		{
			Shape rect = new Rectangle(10, 8);
			int nArea = rect.Area();
			Console.WriteLine("面积：{0}", nArea);
			Console.ReadKey();
		}
	}

}
