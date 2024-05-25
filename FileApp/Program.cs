
namespace FileApp
{
    class Program
    {
        public static void Main()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filepath = path + @"\test.data";
            FileStream file = new(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            const int num = 10;
            for (int i = 0; i < num; i++)
            {
                file.WriteByte((byte)i);
            }
            file.Position = 0;
            for (int i = 0; i < num; i++)
            {
                Console.Write(file.ReadByte() + " ");
            }

            filepath = path + @"\test.txt";
            StreamWriter writer = new(filepath, true);
            for (int i = 0;i < num; i++)
            {
                writer.WriteLine(i);
            }
            writer.Close();
            StreamReader reader = new(filepath);
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
            reader.Close();
        }
    }
}