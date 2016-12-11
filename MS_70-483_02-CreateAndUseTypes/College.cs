using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class College
    {
        public ICollection<Student> Students { get; private set; }
        private static int numStudents = 0;

        public static int NumStudents { get { return numStudents; } }

        // use an Indexer Property to access the students
        public Student this[int index]
        {
            get { return Students.ElementAt(index); }
        }

        public College(int numberOfStudents) //use constructor to create sample students
        {
            Students = new List<Student>(numberOfStudents);
            for (int id = 0; id < numberOfStudents; ++id)
            {
                Students.Add(new Student(id, "01-01-2000"));
                ++numStudents;
            }
        }

    }

}

