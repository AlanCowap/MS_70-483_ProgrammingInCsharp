using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Student
    {
        private const String role = "Student"; //mark this as const because it's known at compile time, can't be changed.
        public readonly String dateOfBirth = "00-00-0000"; //can initialise a read only field when it is declared (or in constructor)
        public int Id { get; } //read-only property

        public Student(int id) : this(id, "00-00-0000") { } //constructor chaining

        public Student(int id, String dateOfBirth)
        {
            this.Id = id;
            this.dateOfBirth = dateOfBirth; //read only field can only be set in constructor.
        }

    }
}
