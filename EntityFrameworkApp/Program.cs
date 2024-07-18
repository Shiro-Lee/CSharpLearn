using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyModelContainer container = new MyModelContainer();
            Student student = new Student() { Name = "Lime", Age = 26, Sex = "Male" };
            container.StudentSet.Add(student);
            container.SaveChanges();
        }
    }
}
