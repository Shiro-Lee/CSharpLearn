#define TestHashtable

using System.Collections;

namespace CollectionApp
{
    class Student: IComparable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "N/A";
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int CompareTo(Student? other)
        {
            return this.Id.CompareTo(other?.Id);
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }

    class StudentCompare : IComparer<Student>
    {
        public int Compare(Student stu1, Student stu2)
        {
            return stu1.Id.CompareTo(stu2?.Id);
            throw new NotImplementedException();
        }
    }


    class Program
    {
        public static void Main()
        {
            #region List
#if TestList
            List<Student> students = new() { new Student(1, "Joker"), new Student(3, "Panther"), new Student(2, "Skull") };
            students.Add(new Student(4, "Fox"));
            students.Add(new Student(5, "Queen"));
            students.Add(new Student(0, "Mona"));
            //students.Sort();
            //students.Sort(new StudentCompare());
            students.Sort();
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Count: {students.Count}");
            Console.WriteLine($"Capacity: {students.Capacity}");
#endif
            #endregion

            #region Hashtable
#if TestHashtable
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Joker");
            hashtable.Add(0, "Mona");
            hashtable.Add(2, "Skull");
            foreach (var item in hashtable)
            {
                Console.WriteLine(item);
            }
            foreach (var item in hashtable.Keys)
            {
                Console.WriteLine(item);
            }
            foreach (var item in hashtable.Values)
            {
                Console.WriteLine(item);
            }
#endif
#endregion

#if TestDictionary
            #region Dictionary
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Joker");
            dict.Add(0, "Mona");
            dict.Add(2, "Skull");
            foreach(var item in dict)
            {
                Console.WriteLine($"{item}: Key={item.Key}, Value={item.Value}");
            }
            #endregion
#endif
        }
    }
}