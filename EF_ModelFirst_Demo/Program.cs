using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ModelFirstDemoDBContext context = new ModelFirstDemoDBContext())
            {
                Console.WriteLine("Enter the new student first name: ");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter the new student last name: ");
                var lastName = Console.ReadLine();

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    StudentID = 1,
                    EnrollmentDate = DateTime.Now.ToString()
                };

                context.Students.Add(student);
                context.SaveChanges();

                var currentStudents = from d in context.Students
                                      orderby d.FirstName select d;

                Console.WriteLine("List of students in database:");
                foreach(var std in currentStudents)
                {
                    Console.WriteLine($"{std.FirstName} {std.LastName}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
