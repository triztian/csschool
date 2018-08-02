namespace School
{
    enum SchoolType
    { Public = 0, Private = 1, Foreign = 2 }

    class Member
    {
        public string Name;
        public string Address;

        protected int phone;
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    class Student : Member
    {
        static public int Count = 0;

        public int ID;
        public int Grade;
        public string Birthday;
        public SchoolType SchoolType;

        public Student() { }

        public Student(int id, string name, int grade, string birthday, string address, int phone)
        {
            ID = id;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            Phone = phone;
        }
    }

    class Teacher : Member
    {
        public string Subject;
    }

}