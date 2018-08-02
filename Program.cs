using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace School
{   
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Import();

            var adding = true;

            while (adding)
            {
                try
                {

                    students.Add( Util.Console.CreateStudent() );

                    Console.WriteLine("Student Count: {0}", Student.Count);

                    Console.WriteLine("Add another? y/n");

                    if ( Console.ReadLine() != "y" ) 
                        adding = false;
                }
                catch (FormatException msg)
                {
                    Console.WriteLine( msg.Message );
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Adding Student, Please Try Again.");
                }
            }

            foreach ( var student in students )
            {
                Console.WriteLine( "Student Name: {0} \nBirthday: {1} \nPhone: {2} \nGrade: {3} \nAddress: {4} \nSchool Attended: {5}", 
                    student.Name, student.Birthday, student.Phone, student.Grade, student.Address, student.SchoolType );
            }

            Exports();  // print school chosen
        }

        static void Import()
        {
            var importedStudent = new Student(Student.Count, "Test", 88, "Jan", "Test-Address", 3213);
            //Console.WriteLine(importedStudent.name);
        } 

        static void Exports()
        {
            foreach (var student in students)
            {
                switch (student.SchoolType)
                {
                    case SchoolType.Public:
                        Console.WriteLine("Public");
                        break;
                    case SchoolType.Private:
                        Console.WriteLine("Private");
                        break;
                    case SchoolType.Foreign:
                        Console.WriteLine("Foreign");
                        break;
                    default:
                        Console.WriteLine("Please enter number between 0, 1, 2");
                        break;
                }
            }
        }
    }
}