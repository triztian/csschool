using System;
using System.Collections.Generic;
using System.Text;

using School;

namespace Util
{
    class Console
    {
        private const string Message = "Input was not a number";

        public static string Ask(string question)
        {
            System.Console.Write( question );
            return System.Console.ReadLine();
        }

        public static int AskInt(string question)
        { 
            System.Console.Write( question );

            int result = 0;
            if ( Int32.TryParse( System.Console.ReadLine(), out result ) ) {
                return result;
            }

            throw new FormatException( Message );
        }

        public static SchoolType AskSchool(string prompt)
        {
            var nSchoolType = -1;
            do 
            {
                nSchoolType = AskInt(prompt);
            } while(!Enum.IsDefined(typeof(SchoolType), nSchoolType));

            return (SchoolType)nSchoolType;
        }

        public static Student ReadStudent() 
        {
            var student = new Student();

            student.ID = Student.Count;

            student.Name = Util.Console.Ask("Student Name: ");

            student.Grade = Util.Console.AskInt("Student Grade: ");

            student.SchoolType = (SchoolType) Util.Console.AskSchool("School Attended: \n0 - Public \n1 - Private \n2 - Foreign \n"); 

            student.Birthday = Util.Console.Ask("Student Birthday: ");

            student.Address = Util.Console.Ask("Student Address: ");

            student.Phone =  Util.Console.AskInt("Student Phone: "); 

            Student.Count++;

            return student;
        }
    }
}