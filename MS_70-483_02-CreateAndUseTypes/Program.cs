using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_02_CreateAndUseTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MS 70-483 #2 Create And Use Types");
            Program demo = new Program();

            String title = "\nObjective 2.1. Create Types";
            demo.Obj21_ChooseType(title + ": Choosing a type"); // p89
            demo.Obj21_BodyType(title + ": Giving your types some body"); //p93
            demo.Obj21_DesigningClasses(title + ": Designing Classes"); //p99
                 //using generic types   p101
                 //extending existing types  //p103


           // TODO 
           title = "\nObjective 2.2. Consume Types";
            title = "\nObjective 2.3. Enforce Encapsulation";
            title = "\nObjective 2.4. Create and implement a class hierarchy";
            title = "\nObjective 2.5. Find, execute, and create types at runtime by using reflection";
            title = "\nObjective 2.6. Manage the object lifecycle";
            title = "\nObjective 2.7. Manipulate strings";
        }


        private void Obj21_ChooseType(String title)
        {
            Console.WriteLine(title);
            /* C# types fall into three categories:
             * 1. Value types       // includes enums
             * 2. Reference types   // objects of our desire
             * 3. Pointer types - rarely used - pointer arithmetic, unsafe code            
            */

            Console.WriteLine("\nCreating enums");
            // The enums used in this section are defined after this method.
            // enums are value types
            // enums improve readability and maintainabiliyt of your code (compiler does validation of values etc.)
            // No need to capitalise enum values - unlike Java
            // No need to put strings in double quotes.
            
            // Note the enum defined after this method (it could also have be defined inside this method...)
            Gender person = Gender.Male;
            if (person == Gender.Male && person.Equals(Gender.Male))  // you can test for equality in different ways
                Console.WriteLine("enum - you da man!");
            // by default first element in an enum is assigned a value of 0, next element is 1 and so on
            person = Gender.Female;
            if ((int) person == 1) //need the cast
                Console.WriteLine("enum - and you da woman!");
            // you can change the assigned values of the enum elements:
            Bearing bear = Bearing.East;
            if((int) bear == 2 ) 
                Console.WriteLine("enum - You're bearing East");

            // you can use the Flags attribute with enums, allows you to set multiple values
            Status status = Status.FanOn | Status.Warning;
            Console.WriteLine(status);
            if ((int) status == ((int) Status.FanOn) + ((int) Status.Warning))
                Console.WriteLine("The Fan is on and there is a Warning!");


            Console.WriteLine("\nValue and Reference Types");
            // In the Common Language Runtime(CLR) that underpins C# (and similar with Java and the Java Virtual Machine):
            // Value types are stored on the Stack      -this is an actual value e.g. 5, true, 
            // Reference types are stored on the Heap - this is a reference to an actual object e.g. new Device()
            // - note that reference types which contain value types, will have those value types stored with the object on the Heap.
            // the Stack is faster, smaller, and no Garbage Collector
            // C# allows you to create a 'struct', which is a value datatype, you should use a value type when:
            // 1.the object is small
            // 2.the object is logically immutable
            // 3.there are a lot of objects
            // Typically your motivation to avoid Reference types is a need for speed and/or minimising memory usage.
            // Reference types inherit directly from System.Object
            // Value types inherit from System.ValueType, which inherits from System.Object
            // - System.ValueType overrides e.g. GetHashCode, Equals, ToString to be meaningful for value types
            // - you can't directly inherit from System.ValueType, but by defining a 'struct' you will have a value type
            // 
            // Refer to the struct defined after this method
            // structs they can have state, behaviour and constructors*, but they do not inherit => saves memory
            // * - you can't define a no-args constructor for a struct
            Point myPoint;// = new Point();
            myPoint.x = 4;
            myPoint.y = 3;
            Console.WriteLine("myPoint struct Point has x and y values of " + myPoint.x +" and "+ myPoint.y +" respectively.");
        }

        // ~~~~~~~~~~ Here be enums ~~~~~~~~~~
        public enum Gender { Male, Female, Other }; //semicolon is not required

        // Change the element index to begin at 1 (0 is default)
        public enum Bearing { North = 1, East, South, West }

        //Change the underlying datatype to byte:
        public enum Suit : byte { Hearts, Diamonds, Spades, Clubs }

        // The Flags attribute can be used with enums, it allows you to set multiple values, note these are ADDED together
        [Flags]
        enum Status
        {
            FanOff = 0x0,
            FanOn = 0x1,
            Warning = 0x2,
            Error = 0x4
        }
        // ~~~~~~~~~~ Here be no more enums ~~~~~~~~~~

        // ~~~~~~~~~~ Here be structs ~~~~~~~~~~
        public struct Point
        {
            public int x, y;
            public Point(int p1, int p2){x = p1; y = p2;}
        }
        // ~~~~~~~~~~ Here be no more structs ~~~~~~~~~~


        private void Obj21_BodyType(String title)
        {
            Console.WriteLine(title);
            // Encapsulation is one of the principles of OOP
            // Encapsulation means keeping data and related behaviour together (state & behaviour)
            // Aside: Encapsulation can also be done with structs which are value types (not reference types i.e. not objects)
            // use methods to bundle together a block of code or piece of functionality that you or others want to use regularly
            //  - e.g. how many times have I reused the Console.WriteLine() method!
            // Method names should be meaningful and unambiguous (this is true for all your identifiers)
            // - ok this method doesn't fit that bill, but in the context of the 70-483 exam objectives it is somewhat meaningful :^)
            // Methods should be somewhat atomic, don't make a method a "Swiss army knife" - that reduces reusability (Law of Demeter)


            // Since C# 4 methods can have named and optional arguments
            // Methods, constructors, indexers, and constructors can use named and optional arguments
            Connect();
            //Overloaded methods have the same method name and same argument list (number, order, and type of parameters). 
            Connect("192.168.1.1"); // call the overloaded Connect method

            // Can use read-only and const in classes (see Student class below)
            Student stu = new Student(12345678, "01-01-2000");
            // stu.id = "666"; // can't do this, id is read-only
            Console.WriteLine("Student id is " + stu.Id +". DOB is "+ stu.dateOfBirth);

            //indexer property - see the College and Student classes in separate files in this project
            College col = new College(10);
            for (int i = 0; i < College.NumStudents; ++i)
                Console.WriteLine("ID " + col[i].Id + ". DOB: " + col[i].dateOfBirth);

            Console.WriteLine("\n");
        }

        void IPConnection(String ipAddress, bool isUDP, int portNumber = 80) // optional parameters must appear after all other parameters
        {
            Console.WriteLine(ipAddress +" "+ isUDP +" "+ portNumber);
        }
        void Connect()
        {
            IPConnection("127.0.0.1", true);
            IPConnection("127.0.0.1", false, 8080);
        }
        void Connect(String ipAddress) //Connect() is overloaded
        {
            IPConnection(ipAddress, true);
            IPConnection(ipAddress, false, 8080);
        }


        private void Obj21_DesigningClasses(String title)
        {
            Console.WriteLine(title);


            Console.WriteLine("\n");
        }




        } //class

    } //namespace
