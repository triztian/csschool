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

            do 
            {
                try
                {
                    students.Add( Util.Console.ReadStudent() );

                    Console.WriteLine("Student Count: {0}", Student.Count);

                    Console.WriteLine("Add another? y/n");
                }
                catch (FormatException msg)
                {
                    Console.WriteLine( msg.Message );
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Adding Student, Please Try Again.");
                }
            } while(Console.ReadLine() == "y");

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
            // TODO: Properly define what "Exports" does ...
            foreach (var student in students)
            {
                Console.WriteLine("--- \n {0}", student.SchoolType.ToString());
            }
        }
    }
}