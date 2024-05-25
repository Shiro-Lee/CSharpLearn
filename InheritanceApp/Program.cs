
using System.Threading.Channels;

namespace InheritanceApp
{
    interface IAnimal
    {
        public void Bark();
    }

    struct Cat : IAnimal
    {
        public int age;
        public void Bark() => Console.WriteLine("Meow!");
    }

    class Dog : IAnimal
    {
        public void Bark() => Console.WriteLine("Wanh!");
    }

    struct Location
    {
        public int X;
        public int Y;
        public int Z;
        public Location(int x, int y, int z) { (X, Y, Z) = (x, y, z); }
    }

    class Person
    {
        public string Name { get; set; } = string.Empty;
        public Person(string name) { Name = name; }
        protected void SaySth(string sth) => Console.WriteLine(sth);
    }

    class Student : Person
    {
        public int Id { get; set; }
        public new void SaySth(string sth) => Console.WriteLine(sth);
        public Student(string name) : base(name)
        {
            base.SaySth("Hello");
            SaySth($"I'm {Name}");
        }
    }

    class Program
    {
        public static void Main()
        {
            IAnimal cat = new Cat();
            IAnimal dog = new Dog();
            cat.Bark();
            dog.Bark();
            IAnimal dog2 = dog;
            Console.WriteLine($"cat2.Equals(cat): {cat.Equals(dog)}");
            Console.WriteLine($"cat2 == cat: {cat == dog}");
            Console.WriteLine($"object.Equals(cat, cat2): {object.Equals(dog, cat)}");
            Console.WriteLine($"object.ReferenceEquals(cat, cat2): {object.ReferenceEquals(dog, cat)}");
            Location loc = new Location(1, 2, 3);
            Student stu = new Student("Joker");
        }
    }
}