using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_70_483_01_ManageProgFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MS 70-483 #2 Manage Program Flow");
            Program demo = new Program();
            String title = "\nObjective 1.3 Implement Program Flow";
            demo.Obj13_BooleanExpressions(title + ": Boolean Expressions");
            demo.Obj13_MakingDecisions(title + ": Making Decisions");
            demo.Obj13_IteratingCollections(title + ": Iterating Across Collections");


        }

        void Obj13_BooleanExpressions(String title)
        {
            Console.WriteLine(title);

            //C and C++ devs note that, as with Java, there is no numeric equivalence with bool or Boolean types in C#
            // bool value = 0; //compiler will complain

            //Equality operator ==
            int x = 42;
            int y = 1;
            int z = 42;
            Console.WriteLine(x == y); // false
            Console.WriteLine(x == z); // true

            //Relational and equality operators < > <= >= == !=

            //Logical operators || && ^ i.e. OR AND XOR respectively
            bool connection = true;
            bool credit = false;
            bool result = connection && credit;
            Console.WriteLine(result);

            //Both || and && are 'short-circuit' operators

            //^ is XOR - i.e. one and only one operand can be true for a return of frue
            Console.WriteLine("XOR...");
            Console.WriteLine(connection ^ true);   //false
            Console.WriteLine(connection ^ false);  //true
            Console.WriteLine(credit ^ true);       //true
            Console.WriteLine(credit ^ false);      //false            
        }

        void Obj13_MakingDecisions(String title)
        {
            Console.WriteLine(title);
            //if, Null Calescing Operator ??, Conditional Operator ?:, switch, goto, break
            int result = 90;
            String msg = "No message";

            if (result >= 55)
            {
                msg = "Honour";
            }
            else if (result >= 40)
            {
                msg = "Pass";
            }
            else
            {
                msg = "Fail";
            }
            Console.WriteLine("Your result is " + msg);

            // ?? operator i.e. Null-coalescing operator
            int? x = null;  //note that placing a ? after a value datatype allows it hold a null value i.e. it's Nullable
            int y = x ?? -1;    //i.e. if x is null then assign y a value of -1, otherwise assign it the (non-null) value of x
            Console.WriteLine("Nullable\n " + y);   // -1
            x = 99;
            y = x ?? -10;
            Console.WriteLine(y);   // 99
            // Nested null-coalescing operator
            int? a = null;
            int? b = null;
            int c = a ?? b ?? -1;   // c is assigned a - but if a is null - then c is assigned b - but if b is null - then c is assigned -1.
            Console.WriteLine(c);   // -1 (because a is null - and b is null)

            // conditional oeprator - just like Java - can be used in place of an if-else statement
            bool isValid = true;
            string message = "N/A";
            if (isValid)
                message = "valid";
            else
                message = "invalid";
            Console.WriteLine(message);
            message = "N/A";
            message = isValid ? "valid" : "invalid"; //functionally the same as the if-else above
            Console.WriteLine(message);


            Console.WriteLine("switch statement, including 'goto'");
            // switch statement must end in a break, return, or throw an exception.
            // fall-through behavior is different than Java and C++
            // - you CANNOT fall through from one case label to another (if the case label contains a statement)
            // - you CAN use the "goto" statement explicitly
            // All the above allows the order of the case statements to be in any order without affecting functional behaviour of code
            // valid types typically used in switch are: char, int, string, enum, ...
            // "The governing type of a switch statement is established by the switch expression. If the type of the switch expression is 
            // sbyte, byte, short, ushort, int, uint, long, ulong, char, string, or an enum-type, then that is the governing type
            // of the switch statement. Otherwise, exactly one user-defined implicit conversion (Section 6.4) must exist from the type 
            // of the switch expression to one of the following possible governing types: 
            // sbyte, byte, short, ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, 
            // or if more than one such implicit conversion exists, a compile-time error occurs."
            // - Ref: https://msdn.microsoft.com/en-us/library/aa664749(v=vs.71).aspx
            string grade = "a";
            int points = 0;
            grade = grade.ToUpper();
            switch (grade)
            {
                case "A": points += 15; goto case "B";
                case "B": points += 15; goto case "C";
                case "C": points += 15; goto case "D";
                case "D": points += 55; break;
                default: Console.WriteLine("Error: Unknown grade."); break;
            }
            Console.WriteLine("Your grade of " +grade+ " gives you " +points+ " points");
        }


        void Obj13_IteratingCollections(String title)
        {
            Console.WriteLine(title);
            //for, while, do while, foreach, continue, break

            Console.WriteLine("The for loop");  // just like Java
            // you can end a for loop using the condition, a break, or return statement
            int[] grades = { 83, 90, 66, 81, 78, 100, 83, 99};
            for (int i = 0; i < grades.Length; ++i)
                Console.Write(grades[i] + " ");
                Console.WriteLine();    // this is not part of the for loop ;)

            for (int i = 0; i < grades.Length; ++i)
            {
                if (grades[i] < 70) continue;   //only display passing grades (continue skips to the next iteration part)
                Console.Write(grades[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The while loop");  // just like Java
            // you can end a while loop using the condition, a break, or return statement
            int index = 0;
            while(index < grades.Length)
            {
                Console.Write(grades[index++] + " ");

            }
            Console.WriteLine();

            Console.WriteLine("The do-while loop");  // just like Java
            // you can end a do-while loop using the condition, a break, or return statement
            index = 0;
            // not a great idea to use a do-while here (why?), however for demo purposes...
            do
            {
                Console.Write(grades[index++] + " ");

            } while (index < grades.Length);    // don't forget the semicolon
            Console.WriteLine();

            Console.WriteLine("The foreach loop");  // similar but slightly different syntax to Java
            // you can end a foreach loop using a break, or return statement
            // Note the loop variable cannot be modified (it's automatic), but you can change the state of object referred to 
            foreach (int grade in grades)
                Console.Write(grade + " ");
                Console.WriteLine();    // this is not part of the foreach loop ;)


            Console.WriteLine("The jump statements");
            // break and continue we have already seen
            // goto we have already seen in the switch statement, but we can also use goto elsewhere in code - but it's BAD PRACTICE
            int x = 2;
            if (2 == x) goto customLabel;
            ++x;

            customLabel:
            Console.WriteLine("Might aswell jump " + x);    // 2

        }




    }
}
