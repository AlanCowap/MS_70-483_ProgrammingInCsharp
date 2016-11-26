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
            String title = "Objective 1.3 Implement Program Flow";
            demo.Obj13_BooleanExpressions(title + ": Boolean Expressions");
            demo.Obj13_MakingDecisions(title + ": Making Decisions");
            demo.Obj13_IteratingCollections(title + ": Iterating Collections");


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
            Console.WriteLine("Nullable\n " + y);
            x = 99;
            y = x ?? -10;
            Console.WriteLine(y);

            Console.WriteLine("switch statement");


        }

        void Obj13_IteratingCollections(String title)
        {
            Console.WriteLine(title);
            Console.WriteLine("TBC");
            //for, while, do while, foreach, continue, break
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

    }
}
