//泛型

namespace GenericApp
{
    //泛型类
    class MyGenericArray<T> where T:new()   //含无参构造方法约束
    {
        private T[] _array;

        public MyGenericArray(int size) => _array = new T[size];


        public T GetAt(int index) => _array[index];

        public void SetAt(int index, T value) => _array[index] = value;

        public T this[int index] { get => _array[index]; set => _array[index] = value; }

        public void Resize(int n) => _array = new T[n];

        public void Print() {
            foreach (var item in _array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        //泛型委托
        delegate T Calc<T>(T a, T b) where T:struct;    //值类型约束
        public static int AddNum(int a, int b) => a + b;
        public static int MulNum(int a, int b) => a * b;

        //泛型方法
        public static void Swap<T>(ref T a, ref T b) => (b, a) = (a, b);

        static void Main(string[] args)
        {
            #region 泛型类
            MyGenericArray<int> myArray = new MyGenericArray<int>(10);
            for (int i = 0; i<10; i++)
            {
                myArray[i] = i;
            }
            myArray.Print();
            #endregion

            #region 泛型方法
            int nA = 0, nB = 1;
            char chA = '0', chB = '1';
            string strA = "0", strB = "1";
            Swap<int>(ref nA, ref nB);
            Swap<char>(ref chA, ref chB);
            Swap<string>(ref strA, ref strB);
            #endregion

            #region 泛型委托
            Calc<int> calcAdd = new Calc<int>(AddNum);
            Calc<int> calcMul = new Calc<int>(MulNum);
            calcAdd += calcMul;
            int num = calcAdd(2, 5);
            Console.WriteLine(num);
            #endregion

        }
    }
}
