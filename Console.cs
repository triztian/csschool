using System;
using System.Collections.Generic;
using System.Text;

using School;

namespace Util
{
    class Console
    {
        /// <summary>
        /// Ask for a string input.
        /// </summary>
        public static string Ask(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }

        /// <summary>
        /// Ask for an `Int32` value.
        /// </summary>
        public static int AskInt(string question)
        { 
            System.Console.Write(question);

            int result = 0;
            if ( Int32.TryParse(System.Console.ReadLine(), out result) ) {
                return result;
            }

            throw new FormatException("input was not a number");
        }

         /// <summary>
         /// Asks for an int option based on a limited set of options, 0-based.
         /// If the input answer is not a number, less than 0 or greater than
         /// the number of options, the user will be asked again.
         /// </summary>
        public static int AskIntOptions(string prompt, params string[] options)
        {
            System.Console.WriteLine(prompt);

            int result;
            do
            {
                for (var i = 0; i < options.Length; i++)
                {
                    System.Console.WriteLine($"\t{i} - {options[i]}");
                }

                System.Console.Write("> ");

            } while (!Int32.TryParse(System.Console.ReadLine(), out result) || result > options.Length || result < 0);

            return result;
        }

        /// <summary>
        /// Ask for the school type that was attended by the student.
        /// </summary>
        public static SchoolType AskSchool(string prompt)
        {
            // NOTE: Alternate way of validating 
            // var nSchoolType = -1;
            // do 
            // {
            //     nSchoolType = AskInt(prompt);
            // } while(!Enum.IsDefined(typeof(SchoolType), nSchoolType));

            return (SchoolType)AskIntOptions(prompt, Enum.GetNames(typeof(SchoolType)));
        }

        public static Student ReadStudent() 
        {
            var student = new Student();

            student.ID = Student.Count;

            student.Name = Util.Console.Ask("Student Name: ");

            student.Grade = Util.Console.AskInt("Student Grade: ");

            student.SchoolType = Util.Console.AskSchool("School Attended: "); 

            student.Birthday = Util.Console.Ask("Student Birthday: ");

            student.Address = Util.Console.Ask("Student Address: ");

            student.Phone =  Util.Console.AskInt("Student Phone: "); 

            Student.Count++;

            return student;
        }
    }
}