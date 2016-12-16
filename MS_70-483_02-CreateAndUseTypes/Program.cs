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
            demo.Obj21_GenericTypes(title + ": Using Generic Types"); //p101
            demo.Obj21_ExtendingExistingTypes(title + ": Extending Existing Types");  //p103


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
            // Code should have:
            // 1. High Cohesion
            // 2. Low Coupling
            // SOLID Principles (see Moodle for more)
            // - Single repsonsibility
            // - Open/closed
            // - Liskov substituion
            // - Interface segregation
            // - Dependency inversion
            Console.WriteLine("High Cohesion & Low Coupling. SOLID Design Principles.");
            Console.WriteLine();
        }


        private void Obj21_GenericTypes(String title)
        {
            Console.WriteLine(title);
            // Generics were added in C# 2, great for code reuse
            // Use generics when you (designiner, programmer) don't know the type that will be used
            // - e.g. How does the Programmer of the List class know what types you'll create and want to store in a List?
            // - they don't know, so instead of a specified type they can use a generic type.
            //             
            List<Student> oddList = new List<Student>(); // 'Student' is substitued for the Generic type in the List class List<T>
            // Generic collections can be found in: System.Collections.Generic.*

            // Not all Collections use generics, you can have a collection of type System.Object
            System.Collections.ArrayList al = new System.Collections.ArrayList(); // this is a nongeneric collection
                                                                                  // Nongeneric collections can be found in: System.Collections.*

            // Generics can be used on structs, classes, interfaces, methods, properties, and delegates (~ S.C.I.M.P.D)
            // Multiple Generic type parameters are allowed, by convention use T, U, V, ... to denote the generic type
            // Generic types can be constrained see p. 102
            // - e.g. to struct, or class, new constructor, base or derived class, implement an interface
            // Can set a default value for the generic type (should it be null, 0, 0.0, false, '' etc).

            // Go and have a look at Catalogue.cs to see a custom Generic class
            // Now let's see how we might use it

            //Catalogue cat = new Catalogue();    // Compiler won't allow this, generic types are strongly-typed
            Catalogue<College> cat = new Catalogue<College>();    // That's better :)
            // Now I have a Catalogue of Colleges
            cat.Add(new College(12));
            // What if I want a Catalogue of students, let's try to avoid The Facebook
            Catalogue<Student> students = new Catalogue<Student>();
            for (int i=0; i < 10; ++i)
                students.Add(new Student(i));
            //students.Add(new College(12));  // Compiler won't allow this, incompatible types (Student vs College)
            // Let's remove a couple of students...
            students.RemoveAt(-1); //our Catalogue validates input so this is handled
            students.RemoveAt(100000); //our Catalogue validates input so this is handled
            students.RemoveAt(5); // remove Student at Catalgoue index 5
            students.Pop();     // remove Student at Catalogue last index
            // So let's iterate through our Catalogue of Students and output each Students ID
            for (int i = 0; i < students.Size; ++i)
                Console.WriteLine(students.GetItemAt(i).Id);

            Console.WriteLine("\n");
        }

        private void Obj21_ExtendingExistingTypes(String title)
        {
            Console.WriteLine(title);
            //Check out the Vehicle and Car classes
            // use the virtual and override keywords in the Base and Derived classes respectively
            // if you don't want a class extended, or a method overriden, use the 'sealed' keyword (like 'final' in Java)

            //Overriding a Base class method in a Derived class method
            Vehicle v1 = new Vehicle();
            v1.StartEngine();
            v1.StopEngine();
            Car c1 = new Car();
            c1.StartEngine();
            c1.StopEngine();

            //We'll get to this later...
            //v1 = c1;
            //v1.StartEngine();
            //v1.StopEngine();

            // Extension Methods
            // - introduced in .NET 4.0
            // - allow you to add additional functionality to existing classes without modifying them
            // - must be declared in nongeneric non-nested static class (see class "Revving" below)

            v1.Rev();
            c1.Rev();

            //We can even add Extension Methods to classes we don't own e.g. String
            // Check out the Revving class below
            String str = "Life is full of ups and downs";
            Console.WriteLine("The String is: " + str);
            str = str.StringThing(); // let's call our Extension Method
            Console.WriteLine(str);

            Console.WriteLine("\n");
        }

    } //class

    // Top level static class for the purpose of an "Extension Method".
    static class Revving
    {
        public static void Rev(this Vehicle vehicle) // the "this" keyword indicates an "Extension Method"
        {
            Console.WriteLine("I'm Revving a Vehicle...");
        }


        //We can even add Extension Methods to classes we don't own e.g. String
        public static String StringThing(this String myString)
        {
            char[] charry = myString.ToCharArray();
            char[] tempCharry = new char[charry.Length];
            for (int i = 0; i < tempCharry.Length; ++i)
            {
                tempCharry[i] = i % 2 == 0 ? char.ToUpper(charry[i]) : char.ToLower(charry[i]);
            }
                return new String(tempCharry);
        }

    }


} //namespace
