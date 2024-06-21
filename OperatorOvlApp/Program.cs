using System;

//运算符重载
namespace OperatorOvlApplication
{
	class Box
	{
		private double dLength;
		private double dWidth;
		private double dHeight;

		public Box(){}

		public Box(double dL, double dW, double dH)
		{
			dLength = dL;
			dWidth = dW;
			dHeight = dH;
		}

		public double GetVolume()
		{
			return dLength * dWidth * dHeight;
		}

		public static Box operator +(Box a, Box b)
		{
            Box c = new Box
            {
                dLength = a.dLength + b.dLength,
                dWidth = a.dWidth + b.dWidth,
                dHeight = a.dHeight + b.dHeight
            };
            return c;
		}

		public static bool operator ==(Box a, Box b)
		{
			if (a.dLength == b.dLength && a.dWidth == b.dWidth && a.dHeight == b.dHeight)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(Box a, Box b)
		{
			if (a.dLength != b.dLength || a.dWidth != b.dWidth || a.dHeight != b.dHeight)
			{
				return true;
			}
			return false;
		}

		public static bool operator <(Box a, Box b)
		{
			if (a.dLength < b.dLength && a.dWidth < b.dWidth && a.dHeight < b.dHeight)
			{
				return true;
			}
			return false;
		}

		public static bool operator >(Box a, Box b)
		{
			if (a.dLength > b.dLength && a.dWidth > b.dWidth && a.dHeight > b.dHeight)
			{
				return true;
			}
			return false;
		}

		public static bool operator <=(Box a, Box b)
		{
			if (a.dLength <= b.dLength && a.dWidth <= b.dWidth && a.dHeight <= b.dHeight)
			{
				return true;
			}
			return false;
		}

		public static bool operator >=(Box a, Box b)
		{
			if (a.dLength >= b.dLength && a.dWidth >= b.dWidth && a.dHeight >= b.dHeight)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("Length:{0}, Width:{1}, Height:{2}", dLength, dWidth, dHeight);
		}

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

	class Program
	{
		static void Main()
		{
			Box a = new Box(1, 2, 3);
			Box b = new Box(4, 5, 6);
			Console.WriteLine(a == b);
			Console.WriteLine(a != b);
			Console.WriteLine(a > b);
			Console.WriteLine(a < b);
			Console.WriteLine(a >= b);
			Console.WriteLine(a <= b);
			Console.WriteLine(a + b);
			Console.ReadLine();
		}
	}
}
