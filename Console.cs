using System;
using System.Collections.Generic;
using System.Text;

using School;

namespace Util
{
    class Console
    {
        private const string Message = "Input was not a number";

        static public string Ask(string question)
        {
            System.Console.Write( question );
            return System.Console.ReadLine();
        }

        static public int AskInt(string question)
        { 
            System.Console.Write( question );

            int result = 0;
            if ( Int32.TryParse( System.Console.ReadLine(), out result ) ) {
                return result;
            }

            throw new FormatException( Message );
        }

        static public int AskSchool(string answer)
        {
            var schoolFlag = true;
            int result = 0;
            while(schoolFlag)
            {
               System.Console.Write( answer ); 
                if (int.Parse(System.Console.ReadLine()) < 3)
                {
                    schoolFlag = false;
                    result = int.Parse( System.Console.ReadLine() );
                }
                return result;
            }
            return result;
        }

        public static Student CreateStudent() 
        {
            var student = new Student();

            student.ID = Student.Count;

            student.Name = Util.Console.Ask("Student Name: ");

            student.Grade = Util.Console.AskInt("Student Grade: ");

            student.SchoolType = (SchoolType) Util.Console.AskSchool("School Attended: \n0 - Public \n1 - Private \n2 - Foreign \n\t"); 

            student.Birthday = Util.Console.Ask("Student Birthday: ");

            student.Address = Util.Console.Ask("Student Address: ");

            student.Phone =  Util.Console.AskInt("Student Phone: "); 

            Student.Count++;

            return student;
        }
    }
}