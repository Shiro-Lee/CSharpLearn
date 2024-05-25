using System;
using System.Runtime.Remoting.Messaging;

//继承类实现接口
namespace InheritanceApplication
{
    //基类
    class Shape
	{
		protected int _width;
		protected int _height;

		public int Width { get => _width; set => _width = value; }
		public int Height { get => _height; set => _height = value; }
	}

	//接口
	public interface PaintCost
	{
		int GetCost(int nArea);
	}

	class Rectangle : Shape, PaintCost
	{
		public int GetArea() => _width * _height;
		public int GetCost(int nArea) => nArea * 70;
	}

	class RectangleTest
	{
		static void Main(string[] args)
		{
			Rectangle rect = new Rectangle();
			rect.Width = 5;
			rect.Height = 6;
			int nArea = rect.GetArea();
			int nCost = rect.GetCost(nArea);
			Console.WriteLine("总面积：{0}", nArea);
			Console.WriteLine("油漆总成本：{0}", nCost);
			Console.ReadKey();
		}
	}

}
